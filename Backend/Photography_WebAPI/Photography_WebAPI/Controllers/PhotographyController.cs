using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Photography_WebAPI.Context;
using Photography_WebAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Photography_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PhotographyController : Controller
    {

        private readonly AppDbContext context;

        public PhotographyController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Photographers.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}",Name ="GetPhotography")]

        public ActionResult Get(int id)
        {
            try
            {
                var photography = context.Photographers.FirstOrDefault(pohotographers => pohotographers.Id == id);
                return Ok(photography);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] PhotographersModels photographers)
        {
            try
            {
                context.Photographers.Add(photographers);
                context.SaveChanges();
                return CreatedAtRoute("GetPhotography", new { id = photographers.Id }, photographers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PhotographersModels photographers)
        {
            try
            {
                if (photographers.Id == id)
                {
                    context.Entry(photographers).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetPhotography", new { id = photographers.Id }, photographers);
                }
                else {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            try
            {
                var photographers = context.Photographers.FirstOrDefault(g => g.Id == id);

                if(photographers != null)
                {
                    context.Photographers.Remove(photographers);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
