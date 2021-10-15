using System.Reflection;
using ECommercePlatform.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercePlatform.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructreDependencies(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<IProductService, ProductService>()
                .AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
