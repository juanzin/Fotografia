using Microsoft.AspNetCore.Mvc;
using Photography_WebAPI.Context;

namespace Photography_WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class TypeUsersController : Controller
    {
        private readonly AppDbContext context;

        public TypeUsersController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.TypeUsers.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
