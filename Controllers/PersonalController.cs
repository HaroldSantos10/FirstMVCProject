using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ComputProject.Models;

namespace ComputProject.Controllers
{
    public class PersonalController : Controller
    {

        public IActionResult Index()
        {
            Personal personal = new Personal();
            personal.name = "Harold";
            personal.lastname = "Santos";
            personal.age= 19;

            return View(personal);
        }

    }
}