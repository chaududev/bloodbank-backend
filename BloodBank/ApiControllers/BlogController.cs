using Application.IService;
using BloodBank.Mapper;
using BloodBank.ViewModels.Base;
using BloodBank.ViewModels.Blogs;
using Domain.Model.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                return Ok(new PagingResponse<BlogViewModel>()
                {
                    Total = rs.total,
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
        public async Task<IActionResult> Insert([FromForm] BlogAddViewModel entity, IFormFile? file)
        {
			try
			{
				if (ModelState.IsValid)
				{
					int imageId;
					if (file == null || file.Length == 0)
					{
                        imageId = ImageService.CreateImageIdNotFound();
					}
					else
					{
						var productImage = await ImageService.ConvertImageToProductImageAsync(file);
						imageId = productImage.Id;
					}
					BlogService.Add(entity.Title, entity.Description, entity.Content, imageId);
					return Ok();
				}
				return UnprocessableEntity(ModelState);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Update(int id, [FromForm] BlogAddViewModel entity, IFormFile? file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int imageId;
                    if (file == null || file.Length == 0)
                    {
                        imageId = BlogService.GetById(id).ImageId;
                    }
                    else
                    {
                        var productImage = await ImageService.ConvertImageToProductImageAsync(file);
                        imageId = productImage.Id;
                    }
                    BlogService.Update(id, entity.Title, entity.Description, entity.Content, imageId);
                    return Ok();
                }
                return UnprocessableEntity(ModelState);
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
