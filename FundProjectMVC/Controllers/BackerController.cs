﻿using FundProjectAPI.DTOs;
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
        public IActionResult Index()
        {
            if (Request.Cookies["name"] != null)
            {
                ViewBag.message = Request.Cookies["name"];
            }
            else
            {
                ViewBag.message = "Not available";
            }
            return View();
        }

        public async Task<IActionResult> Projects(string searchString)
        {
            Task<List<ProjectDto>> projects = _projectService.Search(searchString);
            return View(await projects);
        }

        public async Task<IActionResult> Profile(int id)
        {
            Task<BackerDto> backer = _backerService.GetBacker(id);
            return View(await backer);
        }

    }
}
