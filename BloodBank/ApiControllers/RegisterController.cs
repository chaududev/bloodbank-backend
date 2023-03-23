using Application.IService;
using BloodBank.Mapper;
using BloodBank.ViewModels.Base;
using BloodBank.ViewModels.Registers;
using Domain.Model.Base;
using Domain.Model.BloodRegister;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        readonly IRegisterService RegisterService;
        readonly IImageService ImageService;
        readonly MappingService<Register, RegisterViewModel> mapper;
        public RegisterController(IRegisterService RegisterService, IImageService ImageService)
        {
            this.RegisterService = RegisterService;
            this.ImageService = ImageService;
            this.mapper = new MappingService<Register, RegisterViewModel>();
        }

        [HttpGet]
        [Authorize(Policy = "Roles")]
        public IActionResult Get(string? key, int? pageSize, int? page)
        {
            try
            {
                var rs = RegisterService.GetList(key, pageSize, page);
                return Ok(new PagingResponse<RegisterViewModel>()
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
        [HttpGet("user")]
        [Authorize(Policy = "AllRoles")]
        public IActionResult GetUser(string userName, int? pageSize, int? page)
        {
            try
            {
                var rs = RegisterService.GetListByUser(userName, pageSize, page);
                return Ok(new PagingResponse<RegisterViewModel>()
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
        [Authorize(Policy = "AllRoles")]
        public IActionResult GetId(int id)
        {
            try
            {
                var rs = RegisterService.GetById(id);
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
        [Authorize(Policy = "AllRoles")]
        public IActionResult Insert(RegisterAddViewModel Register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string data = $"{Register.UserId}-{DateTime.Now}";
                    Image QR = ImageService.GenerateQRCode(data);
                    if (QR != null)
                    {
                        RegisterService.Add(Register.Note, Register.Status, Register.BloodId, Register.UserId, Register.TimeSign ?? DateTime.MaxValue, QR.Id, Register.HospitalId);
                        return Ok();
                    }
                    return BadRequest("Faild create QR");
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
        public IActionResult Update(int id, RegisterUpdateViewModel Register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RegisterService.Update(id, Register.Note, Register.Status, Register.BloodId, Register.TimeSign??DateTime.MaxValue, Register.HospitalId);
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
                RegisterService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}


