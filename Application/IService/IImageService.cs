using Domain.Model.Base;
using Domain.Model.BloodRegister;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IImageService
    {
        Task<Image> ConvertImageToProductImageAsync(IFormFile file);
        Image GenerateQRCode(string data);
    }
}
