using Microsoft.AspNetCore.Mvc;
using Photography_WebAPI.Context;
using Photography_WebAPI.Models;

namespace Photography_WebAPI.Controllers
{
    [Route("api/photos")]
    [ApiController]

    public class PhotosController : Controller
    {
        private readonly AppDbContext context;

        public PhotosController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get() 
        {
            try
            {
                return Ok(context.Photos.ToList());
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetPhotos")]
        public ActionResult Get(int id) 
        {
            try 
            {
                var photo = context.Photos.FirstOrDefault(photo => photo.Id == id);
                return Ok(photo);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] PhotosModels photos)
        {
            try
            {
                context.Photos.Add(photos);
                context.SaveChanges();
                return CreatedAtRoute("GetPhotos", new { id = photos.Id }, photos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] PhotosModels photos)
        {
            try
            {
                if(photos.Id == id)
                {
                    context.Entry(photos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetPhotos", new { id = photos.Id }, photos);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            try
            {
                var photos = context.Photos.FirstOrDefault(p => p.Id == id);

                if (photos != null)
                {
                    context.Photos.Remove(photos);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            
            }
        }
    }
}
