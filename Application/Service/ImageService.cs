using Application.IService;
using Infrastructure.IRepository;
using Microsoft.AspNetCore.Http;
using QRCoder;
using Domain.Base;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Application.Service
{
    public class ImageService : IImageService
    {
        readonly IBaseRepository<Image> repository;
        readonly IConfiguration Configuration;

        public ImageService(IBaseRepository<Image> repository, IConfiguration configuration)
        {
            this.repository = repository;
            Configuration = configuration;
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

        public async Task<Image> UploadToAzureAsync(IFormFile file)
        {
            string storageConnectionString = Configuration["Storage:ConnectionString"];
            string containerName = Configuration["Storage:ContainerName"];

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();

            string imageName = $"Post-{DateTime.Now.ToString("ddmmyyyyHHMMss")}-{file.FileName}"; 
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(imageName);
            using (Stream stream = file.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(stream);
                if (file == null)
                {
                    throw new Exception($"Failed to process image");
                }
                var url = $"https://bloodbank2023.blob.core.windows.net/bloodbank2023/{imageName}";
                Image Image = new Image(file.FileName, file.ContentType, url);
                repository.Add(Image);
                return Image;
            }
        }
    }
}
