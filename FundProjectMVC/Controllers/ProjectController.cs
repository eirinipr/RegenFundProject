using FundProjectAPI.Data;
using FundProjectAPI.DTOs;
using FundProjectAPI.Model;
using FundProjectAPI.Service;
using FundProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjectMVC.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IProjectCreatorService projectcreatorService;
        private readonly IHostEnvironment hostEnvironment;

        public ProjectController(IProjectService projectService, IProjectCreatorService projectcreatorService, IHostEnvironment hostEnvironment, FundContext context)
        {
            this.projectService = projectService;
            this.projectcreatorService = projectcreatorService;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult CreateProject()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Category,Goal")] Project project, [Bind("FundAmound,Reward")] RewardPackage rewardPackage)
        {

            if (ModelState.IsValid)
            {
                int creatorId = int.Parse(Request.Cookies["name"]);
                if (rewardPackage is not null)
                {
                    project.RewardPackages = new List<RewardPackage>() { rewardPackage };
                }

                await projectcreatorService.AddProjectToProjectCreator(creatorId, project.Convert());
                //_context.Add(project);
                //_context.Add(rewardPackage);
                //await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Creator");
            }
            return View(project);
        }


        // GET: Project/Edit/5
        public async Task<IActionResult> Details(int id)
        {
            var project = await projectService.GetProject(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }


        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var project = await projectService.GetProject(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project.Convert());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProjectDto project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await projectService.Update(id,project);
                return RedirectToAction("Index", "Creator");
            }
            return View(project);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await projectService.Delete(id);
            }
            return RedirectToAction("Index", "Creator");
        }

    }
}
