global using vabalas_api.Data;
global using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using vabalas_api.Service;
using vabalas_api.Service.Impl;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using vabalas_api.Configs;
using vabalas_api.Exceptions;
using vabalas_api.Models;
using vabalas_api.Service.Jwt;


namespace vabalas_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            var config = EnvConfig.InitializeEnvironemnt(); 

            builder.Services.AddIdentity<VabalasUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>();
            
            builder.Services.Configure<JwtConfig>(jwt =>
            {
                jwt.Secret = config["JwtSettings:Key"]!;
                jwt.ExpirationInHours = 2;
            });
            
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;     
            }).AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = config["JwtSettings:Issuer"],
                    ValidAudience = config["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
            
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(config["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(config["ConnectionStrings:DefaultConnection"]));
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            
            // Services
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<IJobService, JobService>();
            builder.Services.AddScoped<IStatisticsService, StatisticsService>();
            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddScoped<IReviewService,ReviewSevice>();
            // builder.Services.AddScoped<IJobOfferService, JobOfferService>();
            
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

            app.UseExceptionHandler(c => c.Run(GlobalExceptionHandler.InvokeAsync));
            
            app.UseCors(cpb => cpb
                .AllowAnyOrigin().
                AllowAnyMethod().
                AllowAnyHeader()
            );
            
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}