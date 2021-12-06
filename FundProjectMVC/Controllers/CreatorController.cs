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
        private readonly IProjectCreatorService _projectcreatorService;

        public CreatorController(IProjectService projectService, IProjectCreatorService _projectcreatorService)
        {
            this._projectService = projectService;
            this._projectcreatorService = _projectcreatorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Projects(string searchString)
        {
            Task<List<ProjectDto>> projects = _projectService.Search(searchString);
            return View(await projects);
        }

        //public async Task<IActionResult> SelectCategory(ProjectCategory category)
        //{
        //    Task<List<ProjectDto>> categorylist = _projectService.SelectCategory(category);
        //    return View(await categorylist);
        //}

        public async Task<IActionResult> Profile(int id)
        {
            Task<ProjectCreatorDto> creator = _projectcreatorService.GetProjectCreator(id);
            return View(await creator);
        }

    }
}
