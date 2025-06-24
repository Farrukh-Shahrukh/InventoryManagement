using investmentsManagement.Server.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace investmentsManagement.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Expences> Expences { get; set; }
        public DbSet<Investments> Investments { get; set; }
        public DbSet<Investors> Investors { get; set; }
        public DbSet<ExpenceTypes> ExpenceTypes { get; set; }
        public DbSet<Ladger> Ladger { get; set; }

        public DbSet<Projects> Projects { get; set; }
        public DbSet<SalePurchase> SalePurchase { get; set; }
        public DbSet<SalePurchaseAttachment> SalePurchaseAttachment { get; set; }
        public DbSet<Saller> Saller { get; set; }
        public DbSet<Purchaser> Purchaser { get; set; }
        public DbSet<PurchaserDocuments> PurchaserDocuments { get; set; }

        public DbSet<SallerDocuments> SallerDocuments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
