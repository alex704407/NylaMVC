using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NylaMVC.ViewModels
{
    public class SignInViewModel
    {
        [Required(ErrorMessage ="A username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage ="A password is required")]
        public string Password { get; set; }
    }
}
