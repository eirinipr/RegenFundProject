using FundProjectAPI.DTOs;
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

        public ProjectController(IProjectService projectService, IProjectCreatorService projectcreatorService, IHostEnvironment hostEnvironment)
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
        public IActionResult Create(int projectcreatorId, ProjectWithImage projectWithImage)
        {
            ProjectDto projectDto = projectWithImage.ProjectDto;
            var img = projectWithImage.ProjectImage;
            if (img != null)
            {
                var uniqueFileName = GetUniqueFileName(img.FileName);
                var uploads = Path.Combine(hostEnvironment.ContentRootPath + "\\wwwroot", "image");
                var filePath = Path.Combine(uploads, uniqueFileName);
                img.CopyTo(new FileStream(filePath, FileMode.Create));

                projectDto.Description = uniqueFileName;
            }

            projectcreatorService.AddProjectToProjectCreator(projectcreatorId, projectDto);

            return RedirectToAction("Creator", "Projects");
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }


    }
}
