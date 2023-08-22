using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MotorServicesAndWashApp.Models
{
    public class UserModel:UserEmailModel
    {
        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First Name should only contain letters.")]
        public string? firstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Last Name should only contain letters.")]
        public string? lastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone Number should only contain numbers.")]
        public string? phoneNumber { get; set; }

        public int Cities { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? password { get; set; }

        [Compare("password", ErrorMessage = "Passwords do not match.")]
        [Required(ErrorMessage = "Confirm Password is required.")]
        public string? confirmPassword { get; set; } 
    }
}
