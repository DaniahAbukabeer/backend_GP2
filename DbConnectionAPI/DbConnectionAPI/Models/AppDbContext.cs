using Microsoft.EntityFrameworkCore;

namespace DbConnectionAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProduct>()
                .HasKey(b => new { b.UserId, b.ProductId });
            modelBuilder.Entity<FeedBack>()
                .HasKey(b => new { b.UserId, b.PharmacyId });

            modelBuilder.Entity<ReceiptsProducts>()
                .HasKey(e => new { e.Id, e.ProductId });
            modelBuilder.Entity<PharamaysProducts>()
                .HasKey(e => new { e.PharmacyId, e.ProductId });
            modelBuilder.Entity<PharamaysProducts>()
                .HasOne(e => e.Product)
                .WithMany(ex => ex.PharmacyProducts)
                .HasForeignKey(e => e.ProductId);
            modelBuilder.Entity<PharamaysProducts>()
                .HasOne(e => e.Pharmacy)
                .WithMany(ex => ex.PharamaysProducts)
                .HasForeignKey(e => e.PharmacyId);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pharmacy> pharmacies { get; set; } 
        public DbSet<Product> Products { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<PharamaysProducts> PharamaysProducts { get;}
        public DbSet<UserProduct> UserProducts { get; set; }
        public DbSet<ReceiptInfo> ReceiptInfo { get; set; } 
        public DbSet<ReceiptsProducts> ReceiptsProducts { get; set;
        }

    }
}
