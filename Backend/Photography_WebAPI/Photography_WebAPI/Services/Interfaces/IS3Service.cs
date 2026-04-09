namespace Photography_WebAPI.Services.Interfaces
{
    public interface IS3Service
    {
        Task<string> UploadFileAsync(IFormFile file, string fileName);
    }
}
