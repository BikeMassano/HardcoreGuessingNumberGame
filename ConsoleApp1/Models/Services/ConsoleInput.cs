using ConsoleApp1.Models.Interfaces;

namespace ConsoleApp1.Models.Services
{
    class ConsoleInput : IInputProvider
    {
        public int ReadInteger()
        {
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int value))
            {
                throw new FormatException("Значение должно быть целочисленным.");
            }
            return value;
        }
    }
}
