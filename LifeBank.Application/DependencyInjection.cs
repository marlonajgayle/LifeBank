using LifeBank.Application.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace LifeBank.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register Health Check
            services.AddHealthChecks()
                .AddCheck<ApplicationHealthCheck>(name: "LifeBank API");
            return services;
        }
    }
}
