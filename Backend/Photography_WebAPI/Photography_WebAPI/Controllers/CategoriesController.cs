using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photography_WebAPI.Context;
using Photography_WebAPI.Models;

namespace Photography_WebAPI.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]

    public class CategoriesController : Controller
    {
        private readonly AppDbContext context;

        public CategoriesController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Categories.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getgaleria")]
        public ActionResult GetListCategories()
        {
            try
            {
                var result = context.Categories
                    .Select(c => new
                    {
                        c.Id,
                        c.Name,
                        Url = context.Photos
                            .Where(p => p.Category_Id == c.Id)
                            .OrderByDescending(p => p.Id)
                            .Select(p => p.Url_Photo)
                            .FirstOrDefault()
                    })
                    .ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
