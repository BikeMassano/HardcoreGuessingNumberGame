using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Services
{
    class ConsolePrinter : IMessagePrinter
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
