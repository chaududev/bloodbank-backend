using Application.IService;
using BloodBank.Mapper;
using BloodBank.ViewModels.Base;
using BloodBank.ViewModels.Charities;
using Domain.Model.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharityController : ControllerBase
    {
        readonly ICharityService CharityService;
        readonly IImageService ImageService;
        readonly MappingService<Charity, CharityViewModel> mapper;
        public CharityController(ICharityService CharityService, IImageService ImageService)
        {
            this.CharityService = CharityService;
            this.ImageService = ImageService;
            this.mapper = new MappingService<Charity, CharityViewModel>();
        }

        [HttpGet]
        public IActionResult Get(string? key, int? pageSize, int? page)
        {
            try
            {
                var rs = CharityService.GetList(key, pageSize, page);
                return Ok(new PagingResponse<CharityViewModel>()
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
        [HttpGet("money")]
        public IActionResult GetMoney(int? pageSize, int? page)
        {
            try
            {
                var rs = CharityService.GetListHaveMoney(pageSize, page);
                return Ok(new PagingResponse<CharityViewModel>()
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
                var rs = CharityService.GetById(id);
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
        public async Task<IActionResult> Insert([FromForm] CharityAddViewModel entity, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No image uploaded");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    var productImage = await ImageService.ConvertImageToProductImageAsync(file);
                    CharityService.Add(entity.Name, entity.Situation, entity.Content,entity.Money??0, productImage.Id);
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
        public async Task<IActionResult> Update(int id, [FromForm] CharityAddViewModel entity, IFormFile? file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int imageId;
                    if (file == null || file.Length == 0)
                    {
                        imageId = CharityService.GetById(id).ImageId;
                    }
                    else
                    {
                        var productImage = await ImageService.ConvertImageToProductImageAsync(file);
                        imageId = productImage.Id;
                    }
                    CharityService.Update(id, entity.Name, entity.Situation, entity.Content, entity.Money??0, imageId);
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
                CharityService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
