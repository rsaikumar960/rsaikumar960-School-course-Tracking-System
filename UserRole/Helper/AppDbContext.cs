using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserRoles.Models;

namespace UserRoles.Helper
{
    public class AppDbContext : IdentityDbContext<Student>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Page2> page2 { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Languages> languages { get; set; }

    }
}