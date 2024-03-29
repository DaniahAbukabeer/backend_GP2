
using DbConnectionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DbConnectionAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(
                options => {
                    options.AddPolicy(name: MyAllowSpecificOrigins,
                        policy =>
                        {
                            policy.WithOrigins();
                        });

                    options.AddDefaultPolicy(builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
                    //options.AddPolicy("AllowAll", builder =>
                    //{
                    //    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    //});
                });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(
                        builder.Configuration.GetConnectionString("DefaultConnection")
                    ));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseCors("AllowAllOrigin");
            app.UseCors("AllowAll");
            app.UseRouting();
            app.UseHttpsRedirection();

           // app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}