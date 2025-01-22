using Microsoft.AspNetCore.Identity;

namespace IdentityPro19.Models
{

    public class ApplicationUser:IdentityUser
    {
        public string? Gender { get; set; }

    }
}
