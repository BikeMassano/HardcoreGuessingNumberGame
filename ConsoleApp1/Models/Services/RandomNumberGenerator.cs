using ConsoleApp1.Models.Interfaces;

namespace ConsoleApp1.Models.Services
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
