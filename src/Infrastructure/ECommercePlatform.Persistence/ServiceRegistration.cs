using ECommercePlatform.Application.Interfaces.Repositories;
using ECommercePlatform.Persistence.Contexts;
using ECommercePlatform.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercePlatform.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddDbContext<ApplicationContext>()
                .AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
