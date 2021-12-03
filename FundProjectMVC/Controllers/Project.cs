using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjectMVC.Controllers
{
    public class Project : Controller
    {
        public IActionResult CreateProject()
        {
            return View();
        }
    }
}
