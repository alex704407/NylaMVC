using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Identity;
using NylaMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NylaMVC.Models
{
    public class database : IDatabase
    {
        private readonly SqlConnection _con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=NylaUI_Test_DB;Integrated Security=True");
        private SqlCommand cmd;
        private SqlDataReader reader;
        Random id;
        public List<Courses> Courses;

        public async Task<List<Courses>> GetCourses()
        {
            Courses = new List<Courses>();
            _con.Open();
            cmd = new SqlCommand("Select * from Courses", _con);
            reader = await cmd.ExecuteReaderAsync();
         
            while (reader.Read())
            { 
                Courses.Add(new Courses { Course_id = reader["course_id"].ToString(), Course_name = reader["course_name"].ToString() });
            }
            reader.Close();
            _con.Close();

            return Courses;
        
        }

        public Tuple<int,string> SignUp(SignUpViewModel model)
        {
            id = new Random();
            int id_val = id.Next(00000, 99999);
       
            _con.Open();
            cmd = new SqlCommand("insert into Accounts(user_id, Fname, Lname, email, contact, password) values(@id, @fname, @lname, @em, @contact, @password)", _con);
            cmd.Parameters.AddWithValue("@id", id_val);
            cmd.Parameters.AddWithValue("@fname", model.FName);
            cmd.Parameters.AddWithValue("@lname", model.LName);
            cmd.Parameters.AddWithValue("@em", model.Email);
            cmd.Parameters.AddWithValue("@contact", model.Contact);
            cmd.Parameters.AddWithValue("@password", StringToBinary(model.ConfirmPassword.ToString()));
            cmd.ExecuteNonQuery();
            _con.Close();

            return new Tuple<int, string>(id_val, model.FName);
        }

        public int Login(SignInViewModel model)
        {
            int id;
            _con.Open();
            cmd = new SqlCommand("select user_id from Accounts where email=@em and password=@pass", _con);
            cmd.Parameters.AddWithValue("@em", model.Username);
            cmd.Parameters.AddWithValue("@pass", StringToBinary(model.Password));
            reader = cmd.ExecuteReader();
            reader.Read();
            id = int.Parse(reader["user_id"].ToString());
            reader.Close();
            _con.Close();

            return id;
        }

        public string JoinCourse(string user_id, string username, string tbl_name)
        {
            string msg;
            try
            {
                _con.Open();
                cmd = new SqlCommand($"insert into {tbl_name}(user_id, username) values(@user_id, @user)", _con);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.ExecuteNonQuery();
                _con.Close();
                msg = "Enrolled Successfully";
            }
            catch(SqlException e)
            {
                msg = "You have already enrolled into this course";
            }

            return msg;

        }

        private string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        private string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        
    }
}
