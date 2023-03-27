using Application.IService;
using Domain.Model.Base;
using Infrastructure.IRepository;
using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.Linq;
using QRCoder;
using ZXing.QrCode.Internal;
using Domain.Model.Users;
using static QRCoder.PayloadGenerator;

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
            var fileName = $"Post-{DateTime.Now.ToString("ddmmyyyyHHMMss")}-{file.FileName}";
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
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);
            var fileName = $"Qrcode-{DateTime.Now.ToString("ddmmyyyyHHMMss")}.png";
            bool writeFile = ByteArrayToFile(fileName, "qrcode", qrCodeImage);
            if (writeFile)
            {
                Image Image = new Image(fileName, "image/png", $"/uploads/qrcode/{fileName}");
                repository.Add(Image);
                return Image;

            }
            else
            {
                throw new Exception($"Failed to generate qr");
            }
        }
        public bool ByteArrayToFile(string fileName,string path, byte[] byteArray)
        {
            try
            {
              
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","uploads", path);
                CreateIfMissing(uploadPath);
                using (var fs = new FileStream(uploadPath+"/"+ fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }

        private void CreateIfMissing(string uploadPath)
        {
            bool folderExists = Directory.Exists(uploadPath);
            if (!folderExists)
                Directory.CreateDirectory(uploadPath);
        }

		public int CreateImageIdNotFound()
        {

			Image entity = new Image("notfound.jpg", "image/jpeg", "/uploads/image/notfound.jpg");
			repository.Add(entity);
            return entity.Id;
		}
	}
}
