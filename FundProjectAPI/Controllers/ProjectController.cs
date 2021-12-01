using FundProjectAPI.DTOs;
using FundProjectAPI.Model;
using FundProjectAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }


        //Read project by id
        [HttpGet, Route("{id}")]
        public async Task<ActionResult<ProjectDto>> Get(int id)
        {
            var dto = await _service.GetProject(id);
            if (dto == null) return NotFound("The project Id is invalid or the project has been removed.");
            return Ok(dto);

        }



        //Search project by title or category
        [HttpGet, Route("Search")]
        public ActionResult<List<ProjectDto>> Search(string title, ProjectCategory category)
        {
            var response = _service.Search(title, category);
            if (response.Result == null) return NotFound("Could not find a project that matches the specified criteria.");
            return response.Result;
        }


        //Create project
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> Post(ProjectDto dto)
        {

            ProjectDto result = await _service.AddProject(dto);
            if (result == null) return NotFound("The specified project Id is invalid or the project creator has been removed. Could not create project.");
            return Ok(result);
        }


        
        //Update project
        [HttpPatch, Route("{id}")]
        public async Task<ActionResult<ProjectDto>> Patch([FromRoute] int id, [FromBody] ProjectDto dto)
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
                    //if (exception is NotFoundException) //ask how to fix NotFoundException Error
                        return BadRequest("Could not find the book. Ensure the book id is correct and try again.");
                }
            }

            return StatusCode(500);
        }


        //Replace project
        [HttpPut, Route("{id}")]
        public async Task<ActionResult<ProjectDto>> Put([FromRoute] int id, [FromBody] ProjectDto dto)
        {
            try
            {
                var response = await _service.Replace(id, dto);
                return Ok(response);
            }

            catch (AggregateException e)
            {
                foreach (var exception in e.InnerExceptions)
                {
                    //if (exception is NotFoundException) //ask how to fix NotFoundException Error
                    return BadRequest(e.Message);
                }
            }

            return StatusCode(500);
        }


        //Deletes a project
        [HttpDelete, Route("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}
