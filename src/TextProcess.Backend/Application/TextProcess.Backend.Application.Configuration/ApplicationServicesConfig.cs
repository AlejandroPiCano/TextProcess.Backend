using Microsoft.Extensions.DependencyInjection;
using TextProcess.Backend.Application.Services;

namespace TextProcess.Backend.Application.Configuration
{
    /// <summary>
    /// The ApplicationServicesConfig class.
    /// </summary>
    public static class ApplicationServicesConfig
    {
        /// <summary>
        /// The AddApplicationServicesConfiguration method.
        /// </summary>
        /// <param name="services">The services collection.</param>
        /// <exception cref="ArgumentNullException">The exception.</exception>
        public static void AddApplicationServicesConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IOrderProcessApplicationService, OrderProcessApplicationService>();
            services.AddScoped<IOrderOptionsService, OrderOptionsService>();
        }
    }
}