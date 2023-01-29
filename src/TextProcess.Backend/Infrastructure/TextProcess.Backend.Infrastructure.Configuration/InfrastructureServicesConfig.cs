using Microsoft.Extensions.DependencyInjection;
using TextProcess.Backend.Domain.Entities;
using TextProcess.Backend.Domain.Services;

namespace TextProcess.Backend.Infrastructure.Configuration
{
    public static class InfrastructureServicesConfig
    {       
        public static void AddInfrastructureServicesConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IRepository<OrderOptionEntity>, OrderOptionsRepository>();
        }
    }
}