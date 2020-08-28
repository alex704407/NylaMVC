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
        public List<Courses> Course_names;
        private readonly IDatabase _database;

        public StudentHomeController()
        {
            _database = new database();


        }

        [HttpPost]
        public IActionResult StudentHome(string enrollbtn)
        {
            Course_names = new List<Courses>() 
            { 
                new Courses(){Course_id="cs", Course_name="Computer Science Units 1 & 2"},
                new Courses(){Course_id="csecmath", Course_name="Mathematics - CSEC"},
                new Courses(){Course_id="fin", Course_name="Finances"},
                new Courses(){Course_id="math", Course_name="Mathematics"}
            };
            string [] course_code = enrollbtn.Split("-");
            ViewBag.MSG = _database.JoinCourse(Request.Query["userid"], Request.Query["username"], course_code[0]);
            ViewBag.user = Request.Query["username"];
            Course_names.RemoveAll(item => item.Course_id == course_code[0]);
            ViewBag.Courses = Course_names;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> StudentHome()
        {
            Course_names = new List<Courses>();
            ViewBag.id = Request.Query["userid"];
            ViewBag.user = Request.Query["username"];
            Course_names = await _database.GetCourses();
            ViewBag.Courses = Course_names;
            return View();
        }
    }
}
