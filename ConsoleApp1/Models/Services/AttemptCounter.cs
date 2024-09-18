using ConsoleApp1.Models.Interfaces;

namespace ConsoleApp1.Models.Services
{
    class AttemptCounter : IAttemptCounter
    {
        private int _maxAttempts;
        private int _attemptsLeft;

        public AttemptCounter(int maxAttempts)
        {
            _maxAttempts = maxAttempts;
            _attemptsLeft = maxAttempts;
        }

        public int AttemptsLeft => _attemptsLeft;

        public void DecreaseAttempts()
        {
            _attemptsLeft--;
        }

        public bool HasAttemptsLeft()
        {
            return _attemptsLeft > 0;
        }
    }
}
