using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Services
{
    class RandomNumberGenerator : INumberGenerator
    {
        public int GenerateNumber(int minNumber, int maxNumber)
        {
            Random random = new Random();

            int generatedNumber = random.Next(minNumber, maxNumber);
            return generatedNumber;
        }
    }
}
