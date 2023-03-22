using Application.IService;
using BloodBank.Mapper;
using BloodBank.ViewModels;
using Domain.Model.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using Newtonsoft.Json;
using System;
using System.Data;

namespace BlogBank.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        readonly IBlogService BlogService;
        readonly IImageService ImageService;
        readonly MappingService<Blog, BlogViewModel> mapper;
        public BlogController(IBlogService BlogService,IImageService ImageService)
        {
            this.BlogService = BlogService;
            this.ImageService = ImageService;
            this.mapper = new MappingService<Blog, BlogViewModel>();
        }

        [HttpGet]
        public IActionResult Get(string? key, int? pageSize, int? page)
        {
            try
            {
                var rs = BlogService.GetList(key, pageSize, page);
                return Ok(new PagingResponse()
                {
                    Count = rs.data.Count(),
                    TotalCount = rs.total,
                    Data = mapper.Map(rs.data)
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            try
            {
                var rs = BlogService.GetById(id);
                if (rs == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map(rs));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Insert([FromForm] string jsonString, IFormFile file)
        {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No image uploaded");
                }
                if (jsonString == null)
                {
                    return BadRequest("No jsonString uploaded");
                }
                try
                {
                        BlogViewModel blog = JsonConvert.DeserializeObject<BlogViewModel>(jsonString);
                        if (!TryValidateModel(blog))
                        {
                            var errors = ModelState.Values.SelectMany(v => v.Errors);
                        }
                        var productImage = await ImageService.ConvertImageToProductImageAsync(file);
                        if (ModelState.IsValid)
                        {
                            BlogService.Add(blog.Title,blog.Description,blog.Content, productImage.Id);
                            return Ok();
                        }
                        return UnprocessableEntity(ModelState);

                     }
                catch (JsonException ex)
                {
                        return BadRequest(ex.Message);
                }
                catch (Exception e)
                {
                            return BadRequest(e.Message);
                }
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Update(int id, [FromForm] string jsonString, IFormFile? file)
        {
            var idImage = 0;
            if (file == null || file.Length == 0)
            {
                idImage= BlogService.GetById(id).ImageId;
            }
            else
            {
                var productImage = await ImageService.ConvertImageToProductImageAsync(file);
                idImage=productImage.Id;
            }
            if (jsonString == null)
            {
                return BadRequest("No jsonString uploaded");
            }
            try
            {
                BlogViewModel blog = JsonConvert.DeserializeObject<BlogViewModel>(jsonString);
                if (!TryValidateModel(blog))
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                }
                if (ModelState.IsValid)
                {
                    BlogService.Update(id,blog.Title, blog.Description, blog.Content, idImage);
                    return Ok();
                }
                return UnprocessableEntity(ModelState);

            }
            catch (JsonException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete(int id)
        {
            try
            {
                BlogService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
