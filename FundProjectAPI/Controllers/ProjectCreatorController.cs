using FundProjectAPI.DTOs;
using FundProjectAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FundProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCreatorController : ControllerBase
    {
        private readonly IProjectCreatorService _service;

        public ProjectCreatorController(IProjectCreatorService service)
        {
            _service = service;
        }

        //Read projectCreator by id
        [HttpGet, Route("{id}")]
        public async Task<ActionResult<ProjectCreatorDto>> Get(int id)
        {
            var projectCreator = await _service.GetProjectCreator(id);
            if (projectCreator == null) return NotFound("There is not Project Creator with id " + id);
            return Ok(projectCreator);
        }

        //Create projectCreator
        [HttpPost]
        public async Task<ActionResult<ProjectCreatorDto>> Post(ProjectCreatorDto dto)
        {
            ProjectCreatorDto result = await _service.AddProjectCreator(dto);
            if (result == null) return BadRequest("");
            return Ok(result);
        }

        //Update projectCreator rewardPackages
        [HttpPatch, Route("{id}/rewards-packages")]
        public async Task<ActionResult<ProjectCreatorDto>> UpfateProjectCreatorRewardPackages([FromRoute] int id, [FromBody] ProjectCreatorDto dto)
        {
            try
            {
                var response = await _service.Update(id, dto);
                return Ok(response);
            }
            catch (AggregateException e)
            {
                foreach (var exception in e.InnerExceptions)
                {
                    if (exception is NotFoundException)
                        return BadRequest(e.Message);
                }
            }
            return StatusCode(500);
        }

        [HttpPut, Route("{id}")]
        public async Task<ActionResult<ProjectCreatorDto>> Put(int id, ProjectCreatorDto dto)
        {
            try
            {
                return await _service.Replace(id, dto);
            }

            catch (AggregateException e)
            {
                foreach (var exception in e.InnerExceptions)
                {
                    if (exception is NotFoundException)
                        return BadRequest(e.Message);
                }
            }

            return StatusCode(500);
        }


        [HttpDelete, Route("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}
