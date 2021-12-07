using FundProjectAPI.Data;
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
        private readonly IBackerService _backerService;
        private readonly FundContext _context;

        public BackerController(IProjectService projectService, IBackerService backerService, FundContext context)
        {
            this._projectService = projectService;
            this._backerService = backerService;
            this._context = context;
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
