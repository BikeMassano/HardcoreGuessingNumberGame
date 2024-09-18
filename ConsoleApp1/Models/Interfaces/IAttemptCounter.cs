namespace ConsoleApp1.Models.Interfaces
{
    interface IAttemptCounter
    {
        int AttemptsLeft { get; }
        void DecreaseAttempts();
        bool HasAttemptsLeft();
    }
}
