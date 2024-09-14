using ConsoleApp1.Enum;
using ConsoleApp1.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1
{
    class GuessingNumberGame
    {
        private readonly IInputProvider _inputProvider;
        private readonly INumberGenerator _numberGenerator;
        private readonly INumbersComparer _numberComparer;
        private readonly IMessagePrinter _messagePrinter;
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
            _minNumber = minNumber;
            _maxNumber = maxNumber;
        }

        public void StartGame()
        {
            _messagePrinter.PrintMessage("Добро пожаловать в игру Угадай Число!");
            _messagePrinter.PrintMessage("Правила игры:");
            _messagePrinter.PrintMessage($"Игрой загадывается случайное число от {_minNumber} до {_maxNumber}, затем вам предлагается угадать его");
            _messagePrinter.PrintMessage("Если вам не удалось угадать число, то игра вам подскажет, меньше оно или больше");

            _targetNumber = _numberGenerator.GenerateNumber(_minNumber, _maxNumber);

            _messagePrinter.PrintMessage("");
            _messagePrinter.PrintMessage("Число было загадано, введите предполагаемое число:");

            while (true) { 
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
                        _messagePrinter.PrintMessage("Вы победили!");
                        return;
                }
            }
        }
    }
}
