using Mamba.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mamba.DAL
{
    public class MambaDdContext : IdentityDbContext
    {
        public MambaDdContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Team> Teams { get; set; }

    }
}
