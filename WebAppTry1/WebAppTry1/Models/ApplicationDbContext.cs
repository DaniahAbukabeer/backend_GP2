using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;

namespace WebAppTry1.Models
{
    public class ApplicationDbContext : DbContext 
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
                    PhoneNumber = "0791234567",
                    UserName = "Test1",
                    Password = "password12345678",
                    Latitude = 32.234524,
                    Longitude = 23.234632,


                });

            //modelBuilder.Entity<Product>().HasData(
            //        new Product
            //        {
            //            Id = 3,
            //            UserId = 1,
            //            TName = "Trade name",
            //            SName = "Scientific name",
            //            number = "12345",
            //            Provider = "test provider",
            //            LocalAgent = "test agent",
            //            Country = "test country",
            //            PublicPrice = 3,
            //            PulbicPriceWTax = 3.5,
            //            BarCode = "1234567890123",
            //            Quantity = 10,
            //            Dosage = 500,
            //            ATCCODE = "12345",
            //            Amount = 24,
            //            PrivatePrice = 2,
            //            Discreption = "test discreption",
            //            PharmacyId= 3,
            //            //UserProducts = new List<UserProduct> { 
            //            //    new UserProduct { 
            //            //        UserId =1,
            //            //        ProductId = 3,
            //            //        user
            //            //    }
            //            //}




            //        }
            //    );
            //modelBuilder.Entity<Pharmacy>().HasData(
            //    new Pharmacy
            //    {
            //        Id = 2,
            //        Name = "al shefa",
            //        PhoneNumber = "0791234567",
            //        Latitude = 34.2334,
            //        Longitude = 22.233,
            //        Description = "in our pharmacy we belive in the max max pro max altra delux service",
            //        FeedBack = new List<FeedBack>
            //        {
            //                        new FeedBack {
            //                        Statues = true,
            //                        Text = "i like this pharmacy",
            //                        Title = "visited al shefa",
            //                        Ratting = 3.02,
            //                        UserId = 1,
            //                        PharmacyId= 2,
            //                        }
            //        },
            //        Product = new List<Product> { 
            //            new Product {
            //                Id = 1,
            //                TName = "Panadol",
            //                SName = "Paracenaol",
            //                number = "33728",//this is هبد
            //                Provider = "panadol provider",
            //                LocalAgent = "da person who get it",
            //                Country = "idk",
            //                PublicPrice = 2.12,
            //                PulbicPriceWTax = 3.12,
            //                //BarCode = 123454324512, fix the barcode min length and max length properties
            //                Quantity= 5,
            //                Amount= 24,
            //                PrivatePrice = 1.5,
            //                ExpireDate= DateTime.Now,
            //                Discreption = "panadol is used as a general pain killer"
            //            } 
            //        }
            //    }
            //    );

            //modelbuilder.entity<pharmacy>.hasdata(
            //   new pharmacy
            //   {
            //       id = 2,
            //       name = "al shefa",
            //       phonenumber = "0791234567",
            //       latitude = 34.2334,
            //       longitude = 22.233,
            //       description = "in our pharmacy we belive in the max max pro max altra delux service",
            //       feedback = new list<feedback> {
            //            new feedback {
            //            statues = true,
            //            text = "i like this pharmacy",
            //            title = "visited al shefa",
            //            ratting = 3.02,

            //            }
            //       }

            //   }
            //  );

            modelBuilder.Entity<ReceiptsProducts>()
                .HasKey(e => new { e.Id, e.ProductId });

            //modelBuilder.Entity<ReceiptsProducts>()
            //    .HasOne(e=>e.ProductInfo)
            //    .WithOne(e=>e.)

            //.HasOne(e=>e.Receipt)
            //.WithMany(e=>e.ReceiptsProducts)
            //.HasForeignKey()

            modelBuilder.Entity<PharmaysProducts>()
                .HasKey(e => new { e.PharmacyId, e.ProductId });

            modelBuilder.Entity<PharmaysProducts>()
                .HasOne(e => e.Product)
                .WithMany(ex => ex.PharmaysProducts)
                .HasForeignKey(e => e.ProductId);

            modelBuilder.Entity<PharmaysProducts>()
                .HasOne(e=>e.Pharmacy)
                .WithMany(ex=>ex.PharmaysProducts)
                .HasForeignKey(e => e.PharmacyId);


            //modelBuilder.Entity<Product>()
            //    .HasMany(x => x.Pharmacy)
            //    .WithMany(x => x.Product)
            //    .HasForignKey(x => x.PharmacyId);

        }
        //protected override void onConfiguring(DbContextOptionsBuilder options) { 

        //}

        //public DbSet<Receipt> receipts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }

        public DbSet<PharmaysProducts> pharmaysProducts { get; set; }
        //public DbSet<>
        //puclic DbSet<>
    }
}
