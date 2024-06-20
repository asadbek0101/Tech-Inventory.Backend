using MediatR;
using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Tech_Inventory.Application.Common.Behaviors;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Application.Common.Helpers;
using Minio;
using Microsoft.Extensions.Configuration;

namespace Tech_Inventory.Application;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IPaginator, Paginator>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddMinio(configureClient => configureClient
        .WithEndpoint(configuration["Minio:Client"])
        .WithCredentials(configuration["Minio:AccessKey"],
            configuration["Minio:SecretKey"])
        .WithSSL(false));
    }
}
