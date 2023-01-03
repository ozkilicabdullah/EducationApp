
using Microsoft.AspNetCore.Http;

namespace Education.Core.Services
{
    public interface IFirebaseStorageService
    {
        Task<string> UploadFile(IFormFile file);
    }
}
