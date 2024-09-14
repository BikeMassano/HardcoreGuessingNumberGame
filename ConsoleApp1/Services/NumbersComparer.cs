using ConsoleApp1.Enum;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Services
{
    class NumbersComparer : INumbersComparer
    {
        public CompareResult Compare(int guessedNumber, int targetNumber)
        {
            if (guessedNumber > targetNumber) return CompareResult.Greater;
            if (guessedNumber == targetNumber) return CompareResult.Equal;
            if (guessedNumber < targetNumber) return CompareResult.Less;
            throw new ArgumentException("Ошибка сравнения. Вероятно введены некорректные входные данные.");
        }
    }
}
