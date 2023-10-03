global using vabalas_api.Data;
global using Microsoft.EntityFrameworkCore;
using vabalas_api.Repositories;
using vabalas_api.Repositories.Impl;
using Swashbuckle.AspNetCore.Swagger;

namespace vabalas_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            DotNetEnv.Env.Load();

            // Adding dotenv
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            configuration["ConnectionStrings:DefaultConnection"] = configuration["ConnectionStrings:DefaultConnection"]
                .Replace("{DB_SERVER}", Environment.GetEnvironmentVariable("DB_SERVER"))
                .Replace("{DB_NAME}", Environment.GetEnvironmentVariable("DB_NAME"));

            // Add services to the container.
            builder.Configuration.AddConfiguration(configuration);
            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
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