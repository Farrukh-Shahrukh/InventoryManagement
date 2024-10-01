using InventoryManagement.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Expences> Expences { get; set; }
        public DbSet<Investments> Investments { get; set; }
        public DbSet<Investors> Investors { get; set; }
        public DbSet<ExpenceTypes> ExpenceTypes { get; set; }
        public DbSet<Ladger> Ladger { get; set; }

        public DbSet<Projects> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
