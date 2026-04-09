using Microsoft.AspNetCore.Mvc;
using Photography_WebAPI.Services.Interfaces;

namespace Photography_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IS3Service _s3Service;

        public UploadController(IS3Service s3Service)
        {
            _s3Service = s3Service;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(
            [FromForm] IFormFile file,
            [FromForm] int photographerId,
            [FromForm] string title)
        {
            if (file == null)
                return BadRequest("No se recibió ningún archivo.");

            //Generar nombre seguro para el archivo

            var safeTitle = string.Concat(title.Split(System.IO.Path.GetInvalidFileNameChars()));
            safeTitle = safeTitle.Replace(" ", string.Empty);

            var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            var fileName = $"{photographerId}_{timestamp}_{safeTitle}";

            // Subimos el archivo a S3 con el nombre personalizado
            var url = await _s3Service.UploadFileAsync(file, fileName);

            return Ok(new
            {
                message = "Archivo subido correctamente",
                url
            });
        }
    }
}