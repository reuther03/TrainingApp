using System.Runtime.CompilerServices;
using Application.Abstractions.Services;
using Application.Services;
using Domain.TrainingPlans;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Extensions
{
    /// <summary>
    /// Metoda rozszerzająca IServiceCollection, która dodaje wszystkie serwisy z Application
    /// </summary>
    /// <param name="services">Kolekcja serwisów</param>
    /// <returns>Kolekcja serwisów z dodanymi serwisami z Application</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // TODO: tutaj dodawac servisy
        services.AddScoped<ITrainingPlanService, TrainingPlanService>();
        services.AddScoped<ITrainingPlanExerciseService, TrainingPlanExerciseService>();
        return services;
    }
}