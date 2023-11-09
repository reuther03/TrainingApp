﻿using System.Text;
using Application.Abstractions.Services;
using Application.Abstractions.Settings;
using Application.Features.TrainingPlanExercises;
using Application.Features.TrainingPlans;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Application;

public static class Extensions
{
    /// <summary>
    /// Metoda rozszerzająca IServiceCollection, która dodaje wszystkie serwisy z Application
    /// </summary>
    /// <param name="services">Kolekcja serwisów</param>
    /// <param name="configuration">Konfiguracja</param>
    /// <returns>Kolekcja serwisów z dodanymi serwisami z Application</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var authSettings = new AuthSettings();
        configuration.GetSection(AuthSettings.SectionName).Bind(authSettings);
        services.AddSingleton(authSettings);
        services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = authSettings.JwtIssuer,
                ValidAudience = authSettings.JwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.JwtKey))
            };
        });

        services.AddAuthorization();

        // TODO: tutaj dodawac servisy
        services.AddScoped<ITrainingPlanService, TrainingPlanService>();
        services.AddScoped<ITrainingPlanExerciseService, TrainingPlanExerciseService>();
        return services;
    }
}