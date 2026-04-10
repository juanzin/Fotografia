using Amazon.S3;
using Amazon.S3.Model;
using Photography_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Photography_WebAPI.Services
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly IConfiguration _configuration;

        public S3Service(IAmazonS3 s3Client, IConfiguration configuration)
        {
            _s3Client = s3Client;
            _configuration = configuration;
        }

        // Método actualizado para aceptar nombre personalizado
        public async Task<string> UploadFileAsync(IFormFile file, string fileName)
        {
            if (file == null || file.Length == 0)
                throw new Exception("Archivo inválido.");

            var bucketName = _configuration["S3:BucketName"];
            var region = _configuration["AWS:Region"];

            // Mantener la extensión original
            var extension = Path.GetExtension(file.FileName);
            var key = $"{fileName}{extension}"; // nombre personalizado + extensión

            using var stream = file.OpenReadStream();

            var request = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = key,
                InputStream = stream,
                ContentType = file.ContentType,
            };

            await _s3Client.PutObjectAsync(request);

            return $"https://{bucketName}.s3.{region}.amazonaws.com/{key}";
        }
    }
}