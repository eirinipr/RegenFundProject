using FundProjectAPI.Data;
using FundProjectAPI.DTOs;
using FundProjectAPI.Model;
using FundProjectAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjectsMVC.Controllers
{
    public class LoginController : Controller
    {

        private readonly IProjectCreatorService _projectcreatorService;
        private readonly IBackerService _backerService;
        private readonly FundContext _context;

        public LoginController(IProjectCreatorService projectcreatorService, IBackerService backerService, FundContext context)
        {
           _projectcreatorService = projectcreatorService;
            _backerService = backerService;
            _context = context;
        }

        public IActionResult LoginCreator()
        {
            return View();
        }

        public async Task<IActionResult> GetCreator(int id)
        {
            Task<ProjectCreatorDto> projectCreator = _projectcreatorService.GetProjectCreator(id);
            return await Task.Run<IActionResult>(() =>
            {
                if (true)
                {
                    return RedirectToAction("Index", "Creator");
                }
                
            });

        }

        public async Task<IActionResult> GetBacker(int id)
        {
            Task<BackerDto> backer = _backerService.GetBacker(id);
            return await Task.Run<IActionResult>(() =>
            {
                if (true)
                {
                    return RedirectToAction("Index", "Backer");
                }
                
            });

        }

        public IActionResult LoginBacker()
        {
            return View();
        }

        public IActionResult CreateProjectCreator()
        {
            return View();
        }
        public IActionResult CreateBacker()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCreator([Bind("Id,FirstName,LastName,Email,PhoneNumber")] ProjectCreator projectCreator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectCreator);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Creator");
            }
            return View(projectCreator);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBacker([Bind("Id,FirstName,LastName,Email,PhoneNumber")] Backer backer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(backer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Backer");
            }
            return View(backer);
        }


    }
}
