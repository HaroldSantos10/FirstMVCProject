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
            personal.email= "haroldsan9.9@gmail.com";
            personal.phoneNumber=71980278;
            personal.address="Cnt. El Jobo, Moncagua, Departamento de San Miguel";
            return View(personal);
        }

    }
}