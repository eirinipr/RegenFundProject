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
        private readonly IProjectService _projectService;

        public CreatorController(IProjectService projectService)
        {
            this._projectService = projectService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Projects()
        {
            Task<List<ProjectDto>> projects =  _projectService.GetAllProjects();
            return View(await projects);
        }

        public async Task<IActionResult> SearchProjects(string searchString)
        {
            Task<List<ProjectDto>> projects = _projectService.GetAllProjects();
                //.Where(project => project.Title.Contains(searchString))
                //.ToListAsync();
            return View(await projects);
        }

    }
}
