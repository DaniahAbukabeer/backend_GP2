using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebAppTry1.Models;

namespace WebAppTry1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddSqlServer()
            builder.Services.AddDbContextPool<ApplicationDbContext>(
                options => options.UseSqlServer(
                        builder.Configuration.GetConnectionString("DwaerDawayDBConnection")
                    ));
            //var host = CreateHostBuilder(args).Build();
            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var dbContext = services.GetRequiredService<ApplicationDbContext>();
            //    ApplicationDbContext.SeedData(dbContext);
            //}
            
            //builder.Services.AddSingleton<>

            var app = builder.Build();
            //ApplicationDbContext dbContext;

            //dbContext.

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            

            app.Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //    .ConfigureWebHostDefaults(webBuilder =>
        //    {
        //        //webBuilder.UserStartUp<Startup>();
        //    });
    }
}