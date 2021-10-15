using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommercePlatform.Application.Services;
using ECommercePlatform.Infrastructure;
using ECommercePlatform.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercePlatform.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = LoadDependencies();

            var productService = serviceProvider.GetService<IProductService>();

            productService.Get("Mer");

            System.Console.Read();
        }

        static IServiceProvider LoadDependencies()
        {
            return new ServiceCollection()
                    .AddInfrastructreDependencies()
                    .AddPersistenceDependencies()
                    .BuildServiceProvider();
        }
    }
}
