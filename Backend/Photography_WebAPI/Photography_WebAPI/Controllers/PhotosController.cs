using Microsoft.AspNetCore.Mvc;
using Photography_WebAPI.Context;
using Photography_WebAPI.Models;
using Photography_WebAPI.Services.Interfaces;
using System.IO;

namespace Photography_WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PhotosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IS3Service _s3Service;

        public PhotosController(AppDbContext context, IS3Service s3Service)
        {
            _context = context;
            _s3Service = s3Service;
        }

        // GET: api/photos
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.Photos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/photos/5
        [HttpGet("{id}", Name = "GetPhotos")]
        public ActionResult Get(int id)
        {
            try
            {
                var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
                if (photo == null) return NotFound();
                return Ok(photo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/photos
        [HttpPost]
        public async Task<ActionResult> Post(
            [FromForm] IFormFile file,
            [FromForm] string title,
            [FromForm] int photographerId,
            [FromForm] int categoryId,
            [FromForm] string? description)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("No se recibió ningún archivo.");

                // Creamos el registro en la BD sin la URL
                var photo = new PhotosModels
                {
                    Title = title,
                    Created_date = DateTime.UtcNow,
                    Photographer_Id = photographerId,
                    Category_Id = categoryId,
                    Description = description,
                    Url_Photo = ""
                };

                _context.Photos.Add(photo);
                _context.SaveChanges(); // obtenemos el ID autoincremental

                // Generamos el nombre seguro: photographerId_photoId_title_timestamp
                var safeTitle = string.Concat(title.Split(Path.GetInvalidFileNameChars())).Replace(" ", "");
                var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
                var fileNameWithoutExt = $"{photographerId}_{photo.Id}_{safeTitle}_{timestamp}";

                // Subimos a S3
                var url = await _s3Service.UploadFileAsync(file, fileNameWithoutExt);

                // Actualizamos la URL en la BD
                photo.Url_Photo = url;
                _context.SaveChanges();

                return CreatedAtRoute("GetPhotos", new { id = photo.Id }, photo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/photos/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(
            int id,
            [FromForm] IFormFile? file,
            [FromForm] string? title,
            [FromForm] int? categoryId,
            [FromForm] string? description,
            [FromForm] int? photographerId)
        {
            try
            {
                var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
                if (photo == null) return NotFound();

                // Actualizamos datos si se proporcionan
                if (!string.IsNullOrEmpty(title)) photo.Title = title;
                if (categoryId.HasValue) photo.Category_Id = categoryId.Value;
                if (!string.IsNullOrEmpty(description)) photo.Description = description;
                if (photographerId.HasValue) photo.Photographer_Id = photographerId.Value;

                // Si enviaron un archivo nuevo, lo subimos a S3
                if (file != null && file.Length > 0)
                {
                    var safeTitle = string.Concat(photo.Title.Split(Path.GetInvalidFileNameChars())).Replace(" ", "");
                    var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
                    var fileNameWithoutExt = $"{photo.Photographer_Id}_{photo.Id}_{safeTitle}_{timestamp}";

                    var url = await _s3Service.UploadFileAsync(file, fileNameWithoutExt);
                    photo.Url_Photo = url;
                }

                _context.Entry(photo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                return CreatedAtRoute("GetPhotos", new { id = photo.Id }, photo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/photos/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
                if (photo == null) return NotFound();

                _context.Photos.Remove(photo);
                _context.SaveChanges();

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}