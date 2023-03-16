using Application.IService;
using Domain.Model.Base;
using Infrastructure.IRepository;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System;
using ZXing;
using ZXing.QrCode;

namespace Application.Service
{
    public class ImageService : IImageService
    {
        readonly IBaseRepository<Image> repository;

        public ImageService(IBaseRepository<Image> repository)
        {
            this.repository = repository;
        }
        public async Task<Image> ConvertImageToProductImageAsync(IFormFile file)
        {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "posts");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            var fileName = $"Post-{DateTime.Now:yyyyMMddHHmmss}-{file.FileName}";
            var filePath = Path.Combine(uploadPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                if (file == null)
                {
                    throw new Exception($"Failed to process image");
                }
                var url = $"/uploads/posts/{fileName}";
                Image Image = new Image(file.FileName, file.ContentType, url);
                repository.Add(Image);
                return Image;
            }
        }

        public Image GenerateQRCode(string data)
        {
            var options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 200,
                Height = 200
            };
            var writer = new BarcodeWriterSvg();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;

            var svgResult = writer.Write(data);
            // Create directory if it doesn't exist
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "qr");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            var fileName = $"QR-{DateTime.Now:yyyyMMddHHmmss}-{Guid.NewGuid()}.svg";
            var contentType = "image/svg+xml";
            var filePath = Path.Combine(uploadPath, fileName);
            File.WriteAllText(filePath, svgResult.ToString());
            var url = $"/uploads/qr/{fileName}";
            Image Image = new Image(fileName, contentType, url);
            return Image;
        }
    }
}
