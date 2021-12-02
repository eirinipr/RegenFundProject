using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjectMVC.Controllers
{
    public class Backer : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
