using FundProjectAPI.DTOs;
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

        public BackerController(IProjectService projectService)
        {
            this._projectService = projectService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Projects()  //den moy thn emfanizei
        {
            Task<List<ProjectDto>> projects = _projectService.GetAllProjects();
            return View(await projects);
        }


    }
}
