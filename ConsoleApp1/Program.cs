// Создание service provider
using ConsoleApp1;
using Microsoft.Extensions.DependencyInjection;
using ConsoleApp1.Models.Interfaces;
using ConsoleApp1.Models.Services;
using ConsoleApp1.Models;

class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IInputProvider, ConsoleInput>()
            .AddSingleton<INumberGenerator, RandomNumberGenerator>()
            .AddSingleton<INumbersComparer, NumbersComparer>()
            .AddSingleton<IMessagePrinter, ConsolePrinter>()
            .AddSingleton<IAttemptCounter>(sp => new AttemptCounter(5))
            .BuildServiceProvider();

        var game = new GuessingNumberGame(serviceProvider, 1, 100);

        game.StartGame();
    }
}