using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models.Identity
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]        //Ajax call to check whether Email available or not
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
    }
}