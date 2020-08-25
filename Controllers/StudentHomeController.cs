using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NylaMVC.Models;

namespace NylaMVC.Controllers
{
    public class StudentHomeController : Controller
    {
        private database instance;
        List<Courses> Course_names;

        public StudentHomeController()
        {
            instance = new database();
            Course_names = new List<Courses>();
        }

        [HttpPost]
        public IActionResult StudentHome(string course_code)
        {
            course_code = Request.Query["Course_id"];
            instance.JoinCourse(ViewBag.user, course_code);
            Course_names.RemoveAll(item => item.Course_id == course_code);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> StudentHome()
        {
            Course_names = await instance.GetCourses();
            ViewBag.Courses = Course_names;
            ViewBag.id = Request.Query["userid"];
            ViewBag.user = Request.Query["username"]; 

            return View();
        }
    }
}
