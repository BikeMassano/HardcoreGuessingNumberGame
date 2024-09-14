using ConsoleApp1.Enum;

namespace ConsoleApp1.Interfaces
{
    interface INumbersComparer
    {
        CompareResult Compare(int guessedNumber, int targetNumber);
    }
}
