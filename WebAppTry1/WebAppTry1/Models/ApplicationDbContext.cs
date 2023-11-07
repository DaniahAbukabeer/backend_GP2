using Microsoft.EntityFrameworkCore;

namespace WebAppTry1.Models
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<PharmacyModel> Pharmacies { get; set;}
        public DbSet<ProdoctModel> Products { get; set; }
        //public DbSet<CommentModel> Comments { get; set; }
        //puclic DbSet<>
    }
}
