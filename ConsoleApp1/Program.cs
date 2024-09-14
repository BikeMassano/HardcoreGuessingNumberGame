// Создание service provider
using ConsoleApp1.Interfaces;
using ConsoleApp1;
using Microsoft.Extensions.DependencyInjection;
using ConsoleApp1.Services;

class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IInputProvider, ConsoleInput>()
            .AddSingleton<INumberGenerator, RandomNumberGenerator>()
            .AddSingleton<INumbersComparer, NumbersComparer>()
            .AddSingleton<IMessagePrinter, ConsolePrinter>()
            .BuildServiceProvider();

        var game = new GuessingNumberGame(serviceProvider, 1, 100);

        game.StartGame();
    }
}