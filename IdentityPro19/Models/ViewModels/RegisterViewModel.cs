using System.ComponentModel.DataAnnotations;

namespace IdentityPro19.Models.ViewModels
{
    public class RegisterViewModel 
    {
     
        [Required(ErrorMessage = "Enter Email Address")]
        [EmailAddress]
        [MinLength(6)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Confirm Email Address")]
        [EmailAddress]
        [Compare("Email",ErrorMessage ="Email not match")]
        public string ConfirmEmail { get; set; }


        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not match")]

        public string ConfirmPassword { get; set; }

        public string? Mobile { get; set; }
        public string? G { get; set; }
    }
}
