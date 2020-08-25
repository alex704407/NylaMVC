using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NylaMVC.Models;
using NylaMVC.ViewModels;

namespace NylaMVC.Controllers
{
    public class SignupController : Controller
    {

        private database instance;
        Tuple<int, string> id;

        public SignupController()
        {
            instance = new database();
        }

      
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp( SignUpViewModel model)
        {

            if (ModelState.IsValid)
            {
                id = instance.SignUp(model);
            }
            else
            {
                return View();
            }
            //ViewBag.UserDetails = model;
            return RedirectToAction("StudentHome", "studenthome", new { userid = id.Item1.ToString(), username = id.Item2});
        }

       
    }
}
