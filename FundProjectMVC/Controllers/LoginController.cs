using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjectsMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginCreator()
        {
            return View();
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


        //Creates a backer
        public IActionResult AddBacker()
        {
            return View();
        }

    }
}
