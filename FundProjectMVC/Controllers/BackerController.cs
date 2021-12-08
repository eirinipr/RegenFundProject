using FundProjectAPI.DTOs;
using FundProjectAPI.Model;
using FundProjectAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjectMVC.Controllers
{
    public class BackerController : Controller
    {

        private readonly IProjectService _projectService;
        private readonly IBackerService _backerService;

        public BackerController(IProjectService projectService, IBackerService backerService)
        {
            this._projectService = projectService;
            this._backerService = backerService;
        }
        public async Task<IActionResult> Index()
        {
            int backerId = int.Parse(Request.Cookies["name"]);


            BackerDto backerDto = await _backerService.GetBacker(backerId);
            Backer backer =backerDto.Convert();
            List<ProjectDto>  projects = backer.Projects.Select(p=>p.Convert()).ToList();

            //List<ProjectDto> allProjects = await _projectService.GetAllProjects();
            //List<ProjectDto> projects = allProjects.Where(p => p. == backerDto.Id)
            //    .ToList();
            return View(projects);
        }


        public async Task<IActionResult> Projects()
        {
            Task<List<ProjectDto>> projects = _projectService.GetAllProjects();
            return View(await projects);
        }

        public async Task<IActionResult> Profile(int id)
        {
            Task<BackerDto> backer = _backerService.GetBacker(id);
            return View(await backer);
        }

        public async Task<IActionResult> FundedProjects(int Id)
        {
            Task<List<ProjectDto>> projects  = _projectService.FundedProjects(Id);
            return View(await projects);
        }



    }
}
