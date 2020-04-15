using LifeBank.Application.Common.Interfaces;
using LifeBank.Infrastructure.Identity;
using LifeBank.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LifeBank.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment environment)
        {

            services.AddScoped<IUserManager, UserManagerService>();
            services.AddScoped<ISignInManager, SignInManagerService>();
            services.AddTransient<IMailService, MailService>();

            services.AddSingleton<IUriService>(provider =>
            {
                var accessor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent(), "/");
                return new UriService(absoluteUri);
            });

            services.AddDbContext<LifeBankDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("LifeBankDbConnection")));

            services.AddScoped<ILifeBankDbContext>(provider => provider.GetService<LifeBankDbContext>());

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
            }).AddEntityFrameworkStores<LifeBankDbContext>();



            return services;
        }
    }
}
