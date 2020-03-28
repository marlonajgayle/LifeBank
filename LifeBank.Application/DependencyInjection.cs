using LifeBank.Infrastructure.HealthChecks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LifeBank.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register Health Check
            services.AddHealthChecks()
                .AddCheck<ApplicationHealthCheck>(name: "LifeBank API");

            // Register MediatR 
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
