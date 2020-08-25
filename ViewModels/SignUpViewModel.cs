using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NylaMVC.ViewModels
{
    public class SignUpViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="A correct email is required")]
        public string Email { get; set; }

        [Phone(ErrorMessage ="A correct phone# format is required")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "A first name must be entered")]
        public string FName { get; set; }

        [Required(ErrorMessage ="A last name must be entered")]
        public string LName { get; set; }

        [Required(ErrorMessage = "A password name must be entered")]
        [StringLength(20, ErrorMessage ="Password must be between 7 and 20 characters lenght", MinimumLength =8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "A confirm password name must be entered")]
        [StringLength(20, ErrorMessage = "Confirm password must be between 7 and 20 characters lenght", MinimumLength = 8)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
