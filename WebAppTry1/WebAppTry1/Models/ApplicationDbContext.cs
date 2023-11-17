using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace WebAppTry1.Models
{
    internal class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public static void SeedData(ApplicationDbContext context)
        {
            string Path = "~/wwwroot/MOCK_DATA.csv";
            //string csvUserDataPath = "C:\\Users\\dany\\source\\repos\\backend_GP2\\WebAppTry1\\WebAppTry1\\wwwroot\\MOCK_DATA.csv";

            using (var reader = new StreamReader(Path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<User>().ToList();

                context.Users.AddRange(records);
                context.SaveChanges();
            }


            //var mockUserData = 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<UserProduct>()
                .HasKey(b => new { b.UserId, b.ProductId });

            modelBuilder.Entity<FeedBack>()
                .HasKey(b => new { b.UserId, b.PharmacyId });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    PhoneNumber= "0791234567",
                    UserName= "Test1",
                    Password= "password12345678",
                    Latitude= 32.234524,
                    Longitude= 23.234632,
                    
                    
                });


           
        }
        //protected override void onConfiguring(DbContextOptionsBuilder options) { 

        //}

        public DbSet<Receipt> receipts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set;}
        public DbSet<Product> Products { get; set; }
        //public DbSet<FeedBackModel> FeedBacks { get; set; }
        //puclic DbSet<>
    }
}
