using System.Collections.Generic;
using System.Threading.Tasks;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Infrastructure;
using ECommercePlatform.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace ECommercePlatform.Console
{
    class Program
    {
        private static IFileService _fileService;

        private static ICommandParserService _commandParserService;

        private static IMediator _commandExecutionService;

        static async Task Main(string[] args)
        {
            ShowHeader();

            LoadDependencies();

            var paths = GetFilePath();

            System.Console.WriteLine();

            foreach (var path in paths)
            {
                ShowBar(path + " - progress");

                List<string> lines = await _fileService.ReadFileAsync(path);

                if (lines.Count <= 0)
                    System.Console.WriteLine("The file could not be read!");

                foreach (var command in lines)
                {
                    var convertedCommand = _commandParserService?.ConvertCommand(command);

                    if (convertedCommand == null)
                    {
                        System.Console.WriteLine("Invalid command!");
                        continue;
                    }

                    var result = await _commandExecutionService.Send(convertedCommand);

                    System.Console.WriteLine(result.Message);
                }

                System.Console.WriteLine();
            }

            System.Console.Read();
        }

        static List<string> GetFilePath()
        {
            List<string> paths = new List<string>();

            while (true)
            {
                string path = AnsiConsole.Ask<string>("Enter the file path: ");

                paths.Add(path);

                if (!AnsiConsole.Confirm("Do you want to enter another file path?"))
                    break;
                
            }

            return paths;
        }

        static void LoadDependencies()
        {
            var serviceProvider = new ServiceCollection()
                    .AddInfrastructreDependencies()
                    .AddPersistenceDependencies()
                    .BuildServiceProvider();

            _fileService = serviceProvider.GetService<IFileService>();

            _commandParserService = serviceProvider.GetService<ICommandParserService>();

            _commandExecutionService = serviceProvider.GetService<IMediator>();
        }

        static void ShowHeader()
        {
            AnsiConsole.Render(
                new FigletText("Hepsiburada")
                    .LeftAligned()
                    .Color(Color.Orange1));

            System.Console.WriteLine();
        }

        static void ShowBar(string text)
        {
            var rule = new Rule($"[red]{text}[/]");
            rule.LeftAligned();
            AnsiConsole.Render(rule);
        }
    }
}
