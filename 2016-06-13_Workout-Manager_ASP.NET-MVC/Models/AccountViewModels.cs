using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _2016_06_13_Workout_Manager_ASP.NET_MVC.Models
{
    public class AccountViewModels
    {

        public class LoginViewModel
        {
            [Required]
            [Display(Name = "Username")]
            [DataType(DataType.Text)]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public class RegisterViewModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "The username must be at least {2} characters long.", MinimumLength = 4)]
            [DataType(DataType.Text)]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [StringLength(150, ErrorMessage = "The password must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Range(6, 119, ErrorMessage = "You must be at least {1} years old to use this service!")]
            [DataType(DataType.Password)]
            [Display(Name = "Age")]
            public byte Age { get; set; }

            [Required]
            [Range(51, 299, ErrorMessage = "Please enter a height in the range of {1} to {2} cm.")]
            [Display(Name = "Height")]
            public short Height { get; set; }

            [Required]
            [Range(14, 255, ErrorMessage = "Please enter a weight in the range of {1} to {2} kg.")]
            [Display(Name = "Weight")]
            public byte Weight { get; set; }
        }
    }
}