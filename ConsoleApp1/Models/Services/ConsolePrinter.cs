using ConsoleApp1.Models.Interfaces;

namespace ConsoleApp1.Models.Services
{
    class ConsolePrinter : IMessagePrinter
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
