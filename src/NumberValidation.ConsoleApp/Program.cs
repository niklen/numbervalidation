// See https://aka.ms/new-console-template for more information


using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NumberValidation.Validator;
using NumberValidation.Validator.Services;

using IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
            services.AddValidator())
            .Build();

var run = true;
do
{
    Console.WriteLine("");
    Console.WriteLine("Welcome to number validator!");
    Console.WriteLine("Please enter a number. To enter multiple numbers please separate them using ',': ");

    var input = Console.ReadLine();

    var numbers = input.Split(',');

    using var serviceScope = host.Services.CreateScope();
    var provider = serviceScope.ServiceProvider;
    var validationService = provider.GetRequiredService<IValidationService>();

    validationService.ValidateNumbers(numbers);

    Console.WriteLine($"To run again press: A");
    
} while (Console.ReadKey().Key == ConsoleKey.A);




await host.RunAsync();
