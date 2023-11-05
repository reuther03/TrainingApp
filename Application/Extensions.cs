using System.Runtime.CompilerServices;
using Application.Abstractions.Services;
using Application.Services;
using Domain.TrainingPlans;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // TODO: tutaj dodawac servisy
        services.AddScoped<ITrainingPlanService, TrainingPlanService>();
        return services;
    }
}