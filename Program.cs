global using vabalas_api.Data;
global using Microsoft.EntityFrameworkCore;
using vabalas_api.Repositories;
using vabalas_api.Repositories.Impl;
using vabalas_api.Service;
using vabalas_api.Service.Impl;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;


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
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            // repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IJobRepository, JobRepository>();

            // services
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<IJobService, JobService>();
            builder.Services.AddScoped<IStatisticsService, StatisticsService>();

            // Authentication
            builder.Services.AddAuthentication().AddJwtBearer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

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