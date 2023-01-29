using Microsoft.Extensions.DependencyInjection;
using TextProcess.Backend.Domain.Services;

namespace TextProcess.Backend.Domain.Configuration
{
    public static class DomainServicesConfig
    {
        public static void AddDomaiServicesConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IOrderProcessDomainService, OrderProcessDomainService>();
        }

    }
}