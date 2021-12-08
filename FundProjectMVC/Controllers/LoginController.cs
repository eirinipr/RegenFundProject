using FundProjectAPI.Data;
using FundProjectAPI.DTOs;
using FundProjectAPI.Model;
using FundProjectAPI.Service;
using Microsoft.AspNetCore.Http;
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

        public async Task<IActionResult> GetCreator(string email)
        {
            ProjectCreatorDto projectCreator = await _projectcreatorService.GetProjectCreatorByEmail(email);
            if (projectCreator is null) {
                return RedirectToAction("LoginCreator", "Login");
            }

            if (projectCreator != null)
            {
                var options = new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(2)
                };
                Response.Cookies.Append("name", projectCreator.Id.ToString(), options);
                return RedirectToAction("Index", "Creator");
            }

            return View(projectCreator);

        }

        public async Task<IActionResult> GetBacker(string email)
        {
            BackerDto backer = await _backerService.GetBackerByEmail(email);
            if (backer is null)
            {
                return RedirectToAction("LoginBacker", "Login");
            }

            if (backer != null)
            {
                var options = new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(2)
                };
                Response.Cookies.Append("name", backer.Id.ToString(), options);
  
                return RedirectToAction("Index", "Backer");
            }

            return View(backer);

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

                try
                {
                    await _projectcreatorService.AddProjectCreator(projectCreator.Convert());
                }
                catch (Exception ex)
                {
                   return RedirectToAction("CreateProjectCreator", "Login");
                }

            }
            return RedirectToAction("LoginCreator", "Login");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBacker([Bind("Id,FirstName,LastName,Email,PhoneNumber")] Backer backer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(backer);
                await _context.SaveChangesAsync();
                return RedirectToAction("LoginBacker", "Login");
            }
            return View(backer);
        }

        

    }
}
