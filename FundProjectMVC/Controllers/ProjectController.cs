using FundProjectAPI.DTOs;
using FundProjectAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjectMVC.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(ProjectDto project)
        {
            projectService.AddProject(project);
            return RedirectToAction("Creator", "Projects");
        }
    }
}
