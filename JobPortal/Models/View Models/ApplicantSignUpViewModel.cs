using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Models.View_Models
{
    public class ApplicantSignUpViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string FirstName { get; set; }


        [Required]
        [StringLength(15, MinimumLength = 1)]
        public string LastName { get; set; }



        [Required]
        [EmailAddress]
        public string Email { get; set; }



        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Mobile no not valid")]
        public string Mobile { get; set; }



        [Required]
        [StringLength(10, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [NotMapped] // Does not effect with your database
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
