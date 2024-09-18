using ConsoleApp1.Models.Enums;
using ConsoleApp1.Models.Interfaces;

namespace ConsoleApp1.Models.Services
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
