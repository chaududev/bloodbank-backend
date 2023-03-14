﻿using Application.IService;
using BloodBank.Mapper;
using BloodBank.ViewModels;
using Domain.Model.BloodRegister;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BloodGroupController : ControllerBase
    {
        readonly IBloodGroupService BloodGroupService;
        readonly MappingService<BloodGroup, BloodGroupViewModel> mapper;
        public BloodGroupController(IBloodGroupService BloodGroupService)
        {
            this.BloodGroupService = BloodGroupService;
            this.mapper = new MappingService<BloodGroup, BloodGroupViewModel>();
        }

        [HttpGet]
        public IActionResult Get(string? key, int? pageSize, int? page)
        {
            try
            {
                var rs = BloodGroupService.GetList(key, pageSize, page);
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
                var rs = BloodGroupService.GetById(id);
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
        public IActionResult Insert(BloodGroupViewModel BloodGroup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BloodGroupService.Add(BloodGroup.Name, BloodGroup.Description);
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
        public IActionResult Update(int id, BloodGroupViewModel BloodGroup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BloodGroupService.Update(id, BloodGroup.Name, BloodGroup.Description);
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
                BloodGroupService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
