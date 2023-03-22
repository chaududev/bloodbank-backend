using Application.IService;
using Application.Service;
using BloodBank.Mapper;
using BloodBank.ViewModels;
using Domain.Model.Base;
using Domain.Model.BloodRegister;
using Domain.Model.Posts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BloodBank.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        readonly IRegisterService RegisterService;
        readonly IImageService ImageService;
        readonly MappingService<Register, RegisterBloodViewModel> mapper;
        public RegisterController(IRegisterService RegisterService, IImageService ImageService)
        {
            this.RegisterService = RegisterService;
            this.ImageService = ImageService;
            this.mapper = new MappingService<Register, RegisterBloodViewModel>();
        }

        [HttpGet]
        public IActionResult Get(string? key, int? pageSize, int? page)
        {
            try
            {
                var rs = RegisterService.GetList(key, pageSize, page);
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
        [HttpGet("user")]
        public IActionResult GetUser(string userName, int? pageSize, int? page)
        {
            try
            {
                var rs = RegisterService.GetListByUser(userName, pageSize, page);
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
        public IActionResult Insert(RegisterBlood2ViewModel Register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        string data = $"{Register.UserId}-{DateTime.Now}";
                        Image QR = ImageService.GenerateQRCode(data);
                        if (QR != null)
                        {
                            RegisterService.Add(Register.Note, Register.Status, Register.BloodId, Register.UserId, Register.TimeSign??DateTime.MaxValue, QR.Id, Register.HospitalId);
                            return Ok();
                        }
                        return BadRequest("Faild create QR");
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                }
                return UnprocessableEntity(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, RegisterBlood2ViewModel Register)
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


