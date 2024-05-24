using Microsoft.AspNetCore.Identity;

namespace Mamba.Models
{
    public class AppUser : IdentityUser
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
