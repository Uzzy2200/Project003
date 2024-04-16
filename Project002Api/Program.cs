using Microsoft.EntityFrameworkCore;
using Project002.Repository.Models;
using Project002Repository.Interfaces;
using Project002Repository.Repositories;

namespace Project001
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region add features
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            string conStr = @"Server=SKAB3-PC1; Database=Project002; Trusted_Connection=true";
            builder.Services.AddDbContext<Dbcontext>(obj => obj.UseSqlServer(conStr));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //DI - ACTIVATIONS
            builder.Services.AddScoped<ISamuraiRepository, SamuraiRepo>();
            builder.Services.AddScoped<IWarRepository, WarRepo>();
            builder.Services.AddScoped<ICountryRepository, CountryRepo>();
            builder.Services.AddScoped<IWeaponRepository, WeaponRepo>();
            builder.Services.AddScoped<IHorseRepository, HorseRepo>();
            builder.Services.AddScoped<IClothingRepository, ClothingRepo>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            #endregion add features
        }
    }
}