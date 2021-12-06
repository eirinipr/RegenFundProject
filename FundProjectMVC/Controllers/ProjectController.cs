using FundProjectAPI.Data;
using FundProjectAPI.DTOs;
using FundProjectAPI.Model;
using FundProjectAPI.Service;
using FundProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
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
        private readonly FundContext _context;

        public ProjectController(IProjectService projectService, IProjectCreatorService projectcreatorService, IHostEnvironment hostEnvironment, FundContext context)
        {
            this.projectService = projectService;
            this.projectcreatorService = projectcreatorService;
            this.hostEnvironment = hostEnvironment;
            _context = context;
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
                _context.Add(project);
                _context.Add(rewardPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Creator");
            }
            return View(project);
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

        //    private string GetUniqueFileName(string fileName)
        //    {
        //        fileName = Path.GetFileName(fileName);
        //        return Path.GetFileNameWithoutExtension(fileName)
        //                  + "_"
        //                  + Guid.NewGuid().ToString().Substring(0, 4)
        //                  + Path.GetExtension(fileName);
        //    }


    }
}
