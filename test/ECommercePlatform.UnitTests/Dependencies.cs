using ECommercePlatform.Infrastructure;
using ECommercePlatform.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercePlatform.UnitTests
{
    public class Dependencies
    {
        private ServiceProvider _serviceProvider;

        public Dependencies()
        {
            _serviceProvider = new ServiceCollection()
                .AddInfrastructreDependencies()
                .AddPersistenceDependencies()
                .BuildServiceProvider();
        }

        public T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
