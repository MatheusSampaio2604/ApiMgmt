using Microsoft.AspNetCore.Identity;

namespace Domain.Models.ApplicationUser
{
    public class ApplicationUser : IdentityUser<int>
    {
        public required string Name { get; set; }

        public required DateTime DateRegister { get; set; }
    }
}
