using Application.IService;
using Domain.Model.Base;
using Domain.Model.BloodRegister;
using Infrastructure.IRepository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            var filePath = Path.Combine("uploads", $"anh-{DateTime.Now:yyyyMMddHHmmss}"+file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                if (file == null)
                {
                    throw new Exception($"Failed to process image");
                }
                Image Image = new Image(file.FileName, file.ContentType, filePath);
                repository.Add(Image);
                return Image;
                
               
                
            }
        }
    }
}
