using Application.IService;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {

            if (file == null || file.Length == 0)
            {
                return BadRequest("No image uploaded");
            }
            try
            {
                var productImage = await _imageService.ConvertImageToProductImageAsync(file);
                return Ok(productImage);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
