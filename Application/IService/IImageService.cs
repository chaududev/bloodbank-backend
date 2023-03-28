
using Domain.Base;
using Microsoft.AspNetCore.Http;

namespace Application.IService
{
    public interface IImageService
    {
        Task<Image> ConvertImageToProductImageAsync(IFormFile file);
        Image GenerateQRCode(string data);
        int CreateImageIdNotFound();
    }
}
