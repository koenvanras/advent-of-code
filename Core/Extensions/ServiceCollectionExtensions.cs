using Core.Abstractions;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            // Register services
            services.AddScoped<IDistanceService, DistanceService>();
            services.AddScoped<ISimilarityService, SimilarityService>();

            return services;
        }
    }
}
