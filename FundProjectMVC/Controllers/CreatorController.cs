using FundProjectAPI.Data;
using FundProjectAPI.DTOs;
using FundProjectAPI.Model;
using FundProjectAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly FundContext _context;

        public CreatorController(IProjectService projectService, IProjectCreatorService projectcreatorService, FundContext context)
        {
            this._projectService = projectService;
            this._projectcreatorService = projectcreatorService;
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

        //public async Task<IActionResult> SelectCategory(ProjectCategory category)
        //{
        //    Task<List<ProjectDto>> categorylist = _projectService.SelectCategory(category);
        //    return View(await categorylist);
        //}

        public async Task<IActionResult> Profile(int id)
        {
            int creatorId = int.Parse(Request.Cookies["name"]);
            Task<ProjectCreatorDto> creator = _projectcreatorService.GetProjectCreator(creatorId);
            return View(await creator);
        }

        //GET
        public async Task<IActionResult> Get(int id)
        {
            Task<ProjectDto> projectDto = _projectService.GetProject(id);

            return View(await projectDto);
        }

        ////POST
        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var project = await _context.Projects.FindAsync(id);
        //    _context.Projects.Update(project);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Projects", "Creator");
        //}

        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Title,Description,Category,Goal")] Project project)
        //{
        //    if (id != project.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(project);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProjectExists(project.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("Projects", "Creator");
        //    }
        //    return View(project);
        //}

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var project = await _context.Projects.FindAsync(id);
            //var project = await _context.Projects
            //    .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Projects", "Creator");
            //return View(project);
        }

        ////POST
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var project = await _context.Projects.FindAsync(id);
        //    _context.Projects.Remove(project);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Projects", "Creator");
        //}

        public IActionResult CreateReward()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRew([Bind("FundAmount,Reward")] RewardPackage rewardPackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rewardPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //return View(rewardPackage);
            return RedirectToAction("Projects", "Creator");
        }
    }
}
