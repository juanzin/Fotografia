using Microsoft.AspNetCore.Mvc;
using Photography_WebAPI.Context;
using Photography_WebAPI.Models;
using Photography_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Photography_WebAPI.Controllers
{
    [Route("api/photographers")]
    [ApiController]
    public class PhotographyController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IS3Service _s3Service;

        public PhotographyController(AppDbContext context, IS3Service s3Service)
        {
            _context = context;
            _s3Service = s3Service;
        }

        // GET: api/photography
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.Photographers.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/photography/5
        [HttpGet("{id}", Name = "GetPhotography")]
        public ActionResult Get(int id)
        {
            try
            {
                var photographer = _context.Photographers.FirstOrDefault(p => p.Id == id);
                if (photographer == null) return NotFound();
                return Ok(photographer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/photography
        [HttpPost]
        public async Task<ActionResult> Post(
            [FromForm] IFormFile? file,
            [FromForm] string name,
            [FromForm] string paterno,
            [FromForm] string materno,
            [FromForm] string username,
            [FromForm] string password,
            [FromForm] string instagram,
            [FromForm] string facebook,
            [FromForm] string email,
            [FromForm] string biography,
            [FromForm] int typeUser,
            [FromForm] string? phone,
            [FromForm] string? location)
        {
            try
            {
                var photographer = new PhotographersModels
                {
                    Name = name,
                    Paterno = paterno,
                    Materno = materno,
                    Username = username,
                    Password = password,
                    Instagram = instagram,
                    Facebook = facebook,
                    Email = email,
                    Biography = biography,
                    Type_User = typeUser,
                    Phone = phone,
                    Location = location,
                    UrlFoto = "" // temporal
                };

                _context.Photographers.Add(photographer);
                _context.SaveChanges(); // obtenemos ID autoincremental

                // Si enviaron un archivo de foto
                if (file != null && file.Length > 0)
                {
                    // Limpiamos caracteres inválidos y espacios del nombre
                    var safeName = string.Concat(name.Split(Path.GetInvalidFileNameChars())).Replace(" ", "");
                    var fileNameWithoutExt = $"{photographer.Id}_{safeName}";

                    var url = await _s3Service.UploadFileAsync(file, fileNameWithoutExt);

                    photographer.UrlFoto = url;
                    _context.SaveChanges();
                }

                return CreatedAtRoute("GetPhotography", new { id = photographer.Id }, photographer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/photography/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(
            int id,
            [FromForm] string instagram,
            [FromForm] string facebook,
            [FromForm] string email,
            [FromForm] string biography,
            [FromForm] string phone,
            [FromForm] string location)
        {
            try
            {
                var photographer = _context.Photographers.FirstOrDefault(p => p.Id == id);
                if (photographer == null) return NotFound();

                // Actualizamos los campos si vienen en la request
                
                if (!string.IsNullOrEmpty(instagram)) photographer.Instagram = instagram;
                if (!string.IsNullOrEmpty(facebook)) photographer.Facebook = facebook;
                if (!string.IsNullOrEmpty(email)) photographer.Email = email;
                if (!string.IsNullOrEmpty(biography)) photographer.Biography = biography;
                if (!string.IsNullOrEmpty(phone)) photographer.Phone = phone;
                if (!string.IsNullOrEmpty(location)) photographer.Location = location;

               

                _context.Entry(photographer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                return CreatedAtRoute("GetPhotography", new { id = photographer.Id }, photographer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/photography/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var photographer = _context.Photographers.FirstOrDefault(p => p.Id == id);
                if (photographer == null) return NotFound();

                _context.Photographers.Remove(photographer);
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