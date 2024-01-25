﻿namespace vabalas_api.Configs;

public static class EnvConfig
{
    
    public static IConfiguration InitializeEnvironemnt()
    {
        DotNetEnv.Env.Load();
        
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        
        config["ConnectionStrings:DefaultConnection"] = config["ConnectionStrings:DefaultConnection"]!
            .Replace("{DB_SERVER}", Environment.GetEnvironmentVariable("DB_SERVER"))
            .Replace("{DB_NAME}", Environment.GetEnvironmentVariable("DB_NAME"))
            .Replace("{DB_USER}", Environment.GetEnvironmentVariable("DB_USER"))
            .Replace("{DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD"));

        config["AppSettings:Token"] = config["AppSettings:Token"]!
            .Replace("{JWT_SECRET}", Environment.GetEnvironmentVariable("JWT_SECRET"));

        return config;
    }
}