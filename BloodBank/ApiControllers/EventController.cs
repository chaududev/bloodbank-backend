using Application.IService;
using BloodBank.Mapper;
using BloodBank.ViewModels;
using BloodBank.ViewModels.Base;
using BloodBank.ViewModels.Events;
using Domain.Model.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        readonly IEventService EventService;
        readonly IImageService ImageService;
        readonly MappingService<Event, EventViewModel> mapper;
        public EventController(IEventService EventService, IImageService ImageService)
        {
            this.EventService = EventService;
            this.ImageService = ImageService;
            this.mapper = new MappingService<Event, EventViewModel>();
        }

        [HttpGet]
        public IActionResult Get(string? key, int? pageSize, int? page)
        {
            try
            {
                var rs = EventService.GetList(key, pageSize, page);
                return Ok(new PagingResponse<EventViewModel>()
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
                var rs = EventService.GetById(id);
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
        [Authorize(Policy = "Roles")]
        public async Task<IActionResult> Insert([FromForm] EventAddViewModel entity, IFormFile? file)
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
					EventService.Add(entity.EventName, entity.Description, entity.Content, entity.StartTime, entity.EndTime, entity.Status, imageId);
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
        [Authorize(Policy = "Roles")]
        public async Task<IActionResult> Update(int id, [FromForm] EventAddViewModel entity, IFormFile? file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int imageId;
                    if (file == null || file.Length == 0)
                    {
                        imageId = EventService.GetById(id).ImageId;
                    }
                    else
                    {
                        var productImage = await ImageService.ConvertImageToProductImageAsync(file);
                        imageId = productImage.Id;
                    }
                    EventService.Update(id, entity.EventName, entity.Description, entity.Content, entity.StartTime, entity.EndTime, entity.Status, imageId);
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
        [Authorize(Roles ="ADMIN")]
        public IActionResult Delete(int id)
        {
            try
            {
                EventService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

