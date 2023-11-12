using Microsoft.EntityFrameworkCore;

namespace WebAppTry1.Models
{
    internal class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<UserProductModel>()
                .HasKey(b => new { b.UserId, b.ProductId });
        }
        //protected override void onConfiguring(DbContextOptionsBuilder options) { 

        //}

        public DbSet<UserModel> Users { get; set; }
        public DbSet<PharmacyModel> Pharmacies { get; set;}
        public DbSet<ProdoctModel> Products { get; set; }
        //public DbSet<CommentModel> Comments { get; set; }
        //puclic DbSet<>
    }
}
