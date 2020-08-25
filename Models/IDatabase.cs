using NylaMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NylaMVC.Models
{
    interface IDatabase
    {
        public Tuple<int, string> SignUp(SignUpViewModel model);
        public Task<List<Courses>> GetCourses();
        public void JoinCourse(string user_id, string tbl_name);
    }
}
