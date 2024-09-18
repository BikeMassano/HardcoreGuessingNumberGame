using ConsoleApp1.Models.Enums;

namespace ConsoleApp1.Models.Interfaces
{
    interface INumbersComparer
    {
        CompareResult Compare(int guessedNumber, int targetNumber);
    }
}
