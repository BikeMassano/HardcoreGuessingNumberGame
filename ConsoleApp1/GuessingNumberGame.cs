using ConsoleApp1.Models.Enums;
using ConsoleApp1.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1
{
    class GuessingNumberGame
    {
        private readonly IInputProvider _inputProvider;
        private readonly INumberGenerator _numberGenerator;
        private readonly INumbersComparer _numberComparer;
        private readonly IMessagePrinter _messagePrinter;
        private readonly IAttemptCounter _attemptCounter;
        private readonly int _minNumber;
        private readonly int _maxNumber;

        private int _targetNumber = 0;
        private int _guessedNumber = 0;
        private CompareResult? _compareResult = null;

        public GuessingNumberGame(IServiceProvider serviceProvider, int minNumber, int maxNumber)
        {
            _inputProvider = serviceProvider.GetRequiredService<IInputProvider>();
            _numberGenerator = serviceProvider.GetRequiredService<INumberGenerator>();
            _numberComparer = serviceProvider.GetRequiredService<INumbersComparer>();
            _messagePrinter = serviceProvider.GetRequiredService<IMessagePrinter>();
            _attemptCounter = serviceProvider.GetRequiredService<IAttemptCounter>();
            _minNumber = minNumber;
            _maxNumber = maxNumber;
        }

        public void StartGame()
        {
            _targetNumber = _numberGenerator.GenerateNumber(_minNumber, _maxNumber);

            _messagePrinter.PrintMessage($"Я загадал число от {_minNumber} до {_maxNumber}. На то чтобы угадать его, у вас есть {_attemptCounter.AttemptsLeft} попытки!");

            while (_attemptCounter.HasAttemptsLeft()) { 
                _guessedNumber = _inputProvider.ReadInteger();

                _compareResult = _numberComparer.Compare(_guessedNumber, _targetNumber);

                switch (_compareResult)
                {
                    case CompareResult.Less:
                        _messagePrinter.PrintMessage("Число меньше загаданного, попробуйте ещё раз");
                        break;
                    case CompareResult.Greater:
                        _messagePrinter.PrintMessage("Число больше загаданного, попробуйте ещё раз");
                        break;
                    case CompareResult.Equal:
                        _messagePrinter.PrintMessage("Вы угадали число!");
                        return;
                }
                _attemptCounter.DecreaseAttempts();
            }
            _messagePrinter.PrintMessage("У вас закончились попытки. Загаданное число было: " + _targetNumber);
        }
    }
}
