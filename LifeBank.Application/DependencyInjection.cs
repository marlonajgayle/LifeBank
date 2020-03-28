using LifeBank.Infrastructure.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace LifeBank.Infrastructure
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
