using FundProjectAPI.Data;
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
    public class BackerController : Controller
    {

        private readonly IProjectService _projectService;
        private readonly IBackerService _backerService;
        private readonly FundContext _context;

        public BackerController(IProjectService projectService, IBackerService backerService, FundContext context)
        {
            this._projectService = projectService;
            this._backerService = backerService;
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            int backerId = int.Parse(Request.Cookies["name"]);


            BackerDto backerDto = await _backerService.GetBacker(backerId);
            Backer backer =backerDto.Convert();
            List<ProjectDto>  projects = backer.Projects.Select(p=>p.Convert()).ToList();

            //List<ProjectDto> allProjects = await _projectService.GetAllProjects();
            //List<ProjectDto> projects = allProjects.Where(p => p. == backerDto.Id)
            //    .ToList();
            return View(projects);
        }


        public async Task<IActionResult> Projects()
        {
            Task<List<ProjectDto>> projects = _projectService.GetAllProjects();
            return View(await projects);
        }

        public async Task<IActionResult> Profile()
        {
            int backerId = int.Parse(Request.Cookies["name"]);
            Task<BackerDto> backer = _backerService.GetBacker(backerId);
            return View(await backer);
        }

        public async Task<IActionResult> FundedProjects()
        {
            int backerId = int.Parse(Request.Cookies["name"]);
            Task<List<ProjectDto>> projects  = _projectService.FundedProjects(backerId);
            return View(await projects);
        }

        public async Task<IActionResult> DeleteBacker(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var backer = await _context.Backers.FindAsync(id);
            //var project = await _context.Projects
            //    .FirstOrDefaultAsync(m => m.Id == id);
            if (backer == null)
            {
                return NotFound();
            }
            _context.Backers.Remove(backer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
            //return View(project);
        }

    }
}
