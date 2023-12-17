using Microsoft.AspNetCore.Identity;

namespace NerdFlixApplication.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
