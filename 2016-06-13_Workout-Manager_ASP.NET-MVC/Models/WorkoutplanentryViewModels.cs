using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _2016_06_13_Workout_Manager_ASP.NET_MVC.Models
{
    public class WorkoutplanentryViewModels
    {
        public class CreateViewModel
        {
            [Required]
            [Display(Name = "Workout")]
            [DataType(DataType.Text)]
            public string Workout { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Schedule Date")]
            public string ScheduleDate { get; set; }

            [Display(Name = "Repeat")]
            public bool Repeat { get; set; }
        }

        /*public class DetailsViewModel
        {
            [Display(Name = "Creation date")]
            [DataType(DataType.Date)]
            public string CreationDate { get; }

            [Display(Name = "Schedule date")]
            [DataType(DataType.Date)]
            public string ScheduleDate { get; }

            [Display(Name = "Repeat")]
            public string Repeat { get; }

            [Display(Name = "Password")]
            [DataType(DataType.Password)]
            public string Password { get; }

            [Display(Name = "Username")]
            [DataType(DataType.Text)]
            public string Username { get; }
        }*/

        /*public class DeleteViewModel
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

        public class EditViewModel
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
        }*/
    }
}