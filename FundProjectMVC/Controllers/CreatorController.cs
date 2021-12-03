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
    public class CreatorController : Controller
    {
        private readonly IProjectService projectService;

        public CreatorController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Projects()
        {
            Task<List<ProjectDto>> projects =  projectService.GetAllProjects();
            return View(await projects);
        }

    }
}
