using keepr.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace keepr
{
    public class KeeprContext : IdentityDbContext<User>
    {
        // DONT FORGET TO REGISTER YOUR MODELS TO THE DATABASE
        new DbSet<User> Users { get; set; }
        public DbSet<Keep> Keeps { get; set; }
        public DbSet<Vault> Vaults { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:anker.database.windows.net,1433;Initial Catalog=anker;Persist Security Info=False;User ID=anker;Password=Anchor123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        public KeeprContext(DbContextOptions<KeeprContext> options) : base(options)
        {
            // Database.EnsureCreated();
            // Database.Migrate();
        }
    }
}