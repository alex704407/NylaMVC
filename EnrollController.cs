using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NylaMVC.Controllers
{
    public class EnrollController : Controller
    {
        public IActionResult Enrolled()
        {
            return PartialView();
        }
    }
}
 