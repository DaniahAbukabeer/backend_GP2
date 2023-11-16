using Microsoft.EntityFrameworkCore;

namespace WebAppTry1.Models
{
    internal class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<UserProduct>()
                .HasKey(b => new { b.UserId, b.ProductId });

            modelBuilder.Entity<Comment>()
                .HasKey(b => new { b.UserId, b.PharmacyId });

          
        }
        //protected override void onConfiguring(DbContextOptionsBuilder options) { 

        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set;}
        public DbSet<Product> Products { get; set; }
        //public DbSet<CommentModel> Comments { get; set; }
        //puclic DbSet<>
    }
}
