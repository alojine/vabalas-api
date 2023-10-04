global using vabalas_api.Data;
global using Microsoft.EntityFrameworkCore;
using vabalas_api.Repositories;
using vabalas_api.Repositories.Impl;
using vabalas_api.Service;
using vabalas_api.Service.Impl;

namespace vabalas_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            DotNetEnv.Env.Load();

            // Env variables
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            configuration["ConnectionStrings:DefaultConnection"] = configuration["ConnectionStrings:DefaultConnection"]!
                .Replace("{DB_SERVER}", Environment.GetEnvironmentVariable("DB_SERVER"))
                .Replace("{DB_NAME}", Environment.GetEnvironmentVariable("DB_NAME"));

            configuration["AppSettings:Token"] = configuration["AppSettings:Token"]!
                .Replace("{JWT_SECRET}", Environment.GetEnvironmentVariable("JWT_SECRET"));

            // Add services to the container.
            builder.Configuration.AddConfiguration(configuration);
            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddEndpointsApiExplorer();

            // repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // actual services
            builder.Services.AddScoped<JwtService, JwtServiceImpl>();
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
        }
    }
}