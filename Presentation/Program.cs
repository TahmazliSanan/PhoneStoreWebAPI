using AutoMapper;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Abstracts;
using ServiceLayer.Configs;
using ServiceLayer.Implementations;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IPhoneService, PhoneService>();

            builder.Services.AddDbContext<WebAppDatabaseContext>(options => options
            .UseNpgsql(builder.Configuration
            .GetConnectionString("Connection")));

            var mapperConfig = new MapperConfiguration(mc => mc
            .AddProfile(new MapperProfile()));

            builder.Services.AddSingleton(mapperConfig.CreateMapper());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}