using System.ComponentModel.DataAnnotations;

namespace IdentityPro19.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
