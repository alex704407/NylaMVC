using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NylaMVC.ViewModels;

namespace NylaMVC.Controllers
{
    public class LoginController : Controller
    {
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

            }
            else
            {
                return View();
            }

            return RedirectToAction();
        }
    }
}
