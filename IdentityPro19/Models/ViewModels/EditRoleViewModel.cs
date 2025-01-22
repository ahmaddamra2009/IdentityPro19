using System.ComponentModel.DataAnnotations;

namespace IdentityPro19.Models.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
                Names = new List<string>();
        }
        [Required]
        public string RoleId { get; set; }

        [Required(ErrorMessage = "Enter Role Name")]
        public string RoleName { get; set; }

        public List<string> Names { get; set; }
    }
}
