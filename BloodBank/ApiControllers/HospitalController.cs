using Application.IService;
using BloodBank.Mapper;
using BloodBank.ViewModels;
using BloodBank.ViewModels.Base;
using BloodBank.ViewModels.Hospitals;
using Domain.Model.Users;
using Microsoft.AspNetCore.Authorization;
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
                return Ok(new PagingResponse<HospitalViewModel>()
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
        [Authorize(Roles = "ADMIN")]
        public IActionResult Insert(HospitalAddViewModel Hospital)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HospitalService.Add(Hospital.Name, Hospital.Address, Hospital.Lat??"0",Hospital.Long??"0");
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
        public IActionResult Update(int id, HospitalAddViewModel Hospital)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HospitalService.Update(id, Hospital.Name, Hospital.Address,Hospital.Lat ?? "0", Hospital.Long ?? "0");
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

