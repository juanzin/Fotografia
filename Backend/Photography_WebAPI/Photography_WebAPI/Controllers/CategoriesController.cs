using Microsoft.AspNetCore.Mvc;
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
    }
}
