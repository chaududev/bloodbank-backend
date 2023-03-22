using Application.IService;
using BloodBank.Mapper;
using BloodBank.ViewModels;
using Domain.Model.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

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
                EventViewModel Event = JsonConvert.DeserializeObject<EventViewModel>(jsonString);
                if (!TryValidateModel(Event))
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                }
                var productImage = await ImageService.ConvertImageToProductImageAsync(file);
                if (ModelState.IsValid)
                {
                    EventService.Add(Event.EventName,Event.Description,Event.Content,Event.StartTime,Event.EndTime,Event.Status, productImage.Id);
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
        [Authorize(Policy = "Roles")]
        public async Task<IActionResult> Update(int id, [FromForm] string jsonString, IFormFile? file)
        {
            var idImage = 0;
            if (file == null || file.Length == 0)
            {
                idImage = EventService.GetById(id).ImageId;
            }
            else
            {
                var productImage = await ImageService.ConvertImageToProductImageAsync(file);
                idImage = productImage.Id;
            }
            if (jsonString == null)
            {
                return BadRequest("No jsonString uploaded");
            }
            try
            {
                EventViewModel Event = JsonConvert.DeserializeObject<EventViewModel>(jsonString);
                if (!TryValidateModel(Event))
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                }
                if (ModelState.IsValid)
                {
                    EventService.Update(id, Event.EventName, Event.Description, Event.Content, Event.StartTime, Event.EndTime, Event.Status, idImage);
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

