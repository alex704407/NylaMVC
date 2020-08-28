using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NylaMVC.ViewModels;
using NylaMVC.Models;

namespace NylaMVC.Controllers
{
    public class LoginController : Controller
    {
        int id;
        private readonly IDatabase _database;

        public LoginController()
        {
            _database = new database();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                id = _database.Login(model);
            }
            else
            {
                return View();
            }

            return RedirectToAction("Enrolled", "enroll", new { userid = id.ToString()});
        }
    }
}
