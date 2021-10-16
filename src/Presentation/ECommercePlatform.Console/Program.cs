using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Infrastructure;
using ECommercePlatform.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercePlatform.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Console.WriteLine("-----HepsiBurada Case-----\n");

            var serviceProvider = LoadDependencies();

            var fileService = serviceProvider.GetService<IFileService>();

            var commandParserService = serviceProvider.GetService<ICommandParserService>();

            var mediator = serviceProvider.GetService<IMediator>();


            System.Console.Write("Enter the file path: ");

            var path = System.Console.ReadLine();

            System.Console.WriteLine("--------------");

            List<string> lines = await fileService.ReadFileAsync(path);

            foreach (var command in lines)
            {
                var convertedCommand = commandParserService?.ConvertCommand(command);

                if (convertedCommand == null)
                {
                    System.Console.WriteLine("Invalid command!");
                    continue;
                }

                var result = await mediator.Send(convertedCommand);

                System.Console.WriteLine(result.Message);
            }

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
