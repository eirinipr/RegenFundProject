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
        private readonly IBackerService _backerService;


        public ProjectController(IProjectService projectService, IProjectCreatorService projectcreatorService, IHostEnvironment hostEnvironment, IBackerService backerService)
        {
            this.projectService = projectService;
            this.projectcreatorService = projectcreatorService;
            this.hostEnvironment = hostEnvironment;
            this._backerService = backerService;

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

        public async Task<IActionResult> Fund(int id)
        {
            var project = await projectService.GetProject(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project.Convert());
        }


        [HttpPost]
        public async Task<IActionResult> AddFund(decimal goalGained, Project project)
        {
            if (project == null)
            {
                return NotFound();
            }
            int backerId = int.Parse(Request.Cookies["name"]);
            //BackerDto backer = await _backerService.GetBacker(backerId);
            await projectService.AddProject2Backer(backerId, goalGained, project.Convert());
            //var project = await projectService.GetProject(project.Id);
          return RedirectToAction("Index", "Backer");
        }

        //    [HttpPost]
        //    public IActionResult Create(int projectcreatorId, ProjectWithImage projectWithImage)
        //    {
        //        ProjectDto projectDto = projectWithImage.ProjectDto;
        //        var img = projectWithImage.ProjectImage;
        //        if (img != null)
        //        {
        //            var uniqueFileName = GetUniqueFileName(img.FileName);
        //            var uploads = Path.Combine(hostEnvironment.ContentRootPath + "\\wwwroot", "image");
        //            var filePath = Path.Combine(uploads, uniqueFileName);
        //            img.CopyTo(new FileStream(filePath, FileMode.Create));

        //            projectDto.Description = uniqueFileName;
        //        }

        //        int creatorId = int.Parse(Request.Cookies["name"]);
        //        projectcreatorService.AddProjectToProjectCreator(creatorId, projectDto);

        //        return RedirectToAction("Index", "Creator");
        //    }

        //private string GetUniqueFileName(string fileName)
        //{
        //    fileName = Path.GetFileName(fileName);
        //    return Path.GetFileNameWithoutExtension(fileName)
        //              + "_"
        //              + Guid.NewGuid().ToString().Substring(0, 4)
        //              + Path.GetExtension(fileName);
        //}



            
       

    }
}
