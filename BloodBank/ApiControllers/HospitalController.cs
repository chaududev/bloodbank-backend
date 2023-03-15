using Application.IService;
using BloodBank.Mapper;
using BloodBank.ViewModels;
using Domain.Model.BloodRegister;
using Domain.Model.Users;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalController : ControllerBase
    {
        readonly IHospitalService HospitalService;
        readonly MappingService<Hospital, HospitalViewModel> mapper;
        public HospitalController(IHospitalService HospitalService)
        {
            this.HospitalService = HospitalService;
            this.mapper = new MappingService<Hospital, HospitalViewModel>();
        }

        [HttpGet]
        public IActionResult Get(string? key, int? pageSize, int? page)
        {
            try
            {
                var rs = HospitalService.GetList(key, pageSize, page);
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
                var rs = HospitalService.GetById(id);
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
        public IActionResult Insert(HospitalViewModel Hospital)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HospitalService.Add(Hospital.Name, Hospital.Address);
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
        public IActionResult Update(int id, HospitalViewModel Hospital)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HospitalService.Update(id, Hospital.Name, Hospital.Address);
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
        public IActionResult Delete(int id)
        {
            try
            {
                HospitalService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

