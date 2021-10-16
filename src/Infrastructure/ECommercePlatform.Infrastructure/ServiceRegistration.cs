using System.Reflection;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercePlatform.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructreDependencies(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<IProductService, ProductService>()
                .AddTransient<ICampaignService, CampaignService>()
                .AddTransient<IOrderService, OrderService>()
                .AddSingleton<ITimeManagementService, TimeManagementService>()
                .AddTransient<ICommandParserService, CommandParserService>()
                .AddTransient<IFileService, FileService>()
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
