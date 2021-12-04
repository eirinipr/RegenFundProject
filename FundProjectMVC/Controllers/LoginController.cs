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

        public LoginController(IProjectCreatorService projectcreatorService, IBackerService backerService)
        {
           _projectcreatorService = projectcreatorService;
            _backerService = backerService;
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
                else 
                {
                    return NotFound();
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
                else
                {
                    return NotFound();
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

        public IActionResult CreateCreator(ProjectCreatorDto dto) //den paizei akoma se petaei sth selida alla den ftiaxnei ton creator
        {
            _projectcreatorService.AddProjectCreator(dto);
            return RedirectToAction("Index", "Creator");
        }

        public IActionResult AddBacker(BackerDto dto) //den paizei akoma se petaei sth selida alla den ftiaxnei ton backer
        {
            _backerService.AddBacker(dto);
            return RedirectToAction("Index", "Backer");
        }


    }
}
