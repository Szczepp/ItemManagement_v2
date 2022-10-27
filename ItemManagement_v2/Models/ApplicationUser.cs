using Microsoft.AspNetCore.Identity;

namespace ItemManagement_v2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsActive { get; set; }
    }
}
