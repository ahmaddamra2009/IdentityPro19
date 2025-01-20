using System.ComponentModel.DataAnnotations;

namespace IdentityPro19.Models.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Enter Email Address")]
        [EmailAddress]
        [MinLength(6)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
