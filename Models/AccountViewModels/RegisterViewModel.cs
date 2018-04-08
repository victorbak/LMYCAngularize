using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LmycAPI.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string AddressStreet { get; set; }

        [Required]
        [Display(Name = "City")]
        public string AddressCity { get; set; }

        [Required]
        [Display(Name = "Province")]
        public string AddressProvince { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public string AddressPostalCode { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string AddressCountry { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required]
        [Display(Name = "Sailing Experience")]
        public int SailingExperience { get; set; }
    }
}
