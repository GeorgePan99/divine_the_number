using DivineNumber.Services;
using DivineNumber.UI.Interfaces;
using DivineNumber.Services.AdditionalClasses;
using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace DivineNumber.UI.Classes;

public class Game(IValueGenerator valueGenerator,
                  IComparator comparator,
                  IInputValidator inputValidator,
                  IStringLocalizer<SharedResource> localizer,
                  IOptions<ValueRange> valueRange,
                  IOptions<Commands> commands): IGame
{
    private readonly IValueGenerator _valueGenerator = valueGenerator;
    private readonly IComparator _comparator = comparator;
    private readonly IInputValidator _inputValidator = inputValidator;
    private readonly IStringLocalizer<SharedResource> _localizer = localizer;
    private readonly IOptions<ValueRange> _valueRange = valueRange;
    private readonly IOptions<Commands> _commands = commands;
    private bool _running = true;
    private bool _afterVictoryProcess = true;

    public void StartGame()
    {
        while (_running)
        {
            string? userInput = Console.ReadLine();
            if (IsInSpot(userInput))
                AfterVictory(userInput);
            else if (IsWrong(userInput))
                Console.WriteLine(_localizer.GetString("wrong"));
            else if (IsNotInRange(userInput))
                Console.WriteLine(_localizer.GetString("outOfRange"));
            else if (_inputValidator.IsCommand(userInput))
                DefineCommand(userInput);
            else
                Console.WriteLine(_localizer.GetString("incorrectData"));
        }
    }

    public bool IsInSpot(string userInput)
    {
        return _inputValidator.IsNumber(userInput) &&
               _inputValidator.IsInRange(userInput) &&
               _comparator.Compare(userInput);
    }
    
    public bool IsWrong(string userInput)
    {
        return _inputValidator.IsNumber(userInput) &&
               _inputValidator.IsInRange(userInput) &&
               !_comparator.Compare(userInput);
    }
    
    public bool IsNotInRange(string userInput)
    {
        return _inputValidator.IsNumber(userInput) &&
               !_inputValidator.IsInRange(userInput) &&
               !_comparator.Compare(userInput);
    }
    public void DefineCommand(string userInput)
    {
        if (string.Equals(userInput, _commands.Value.Exit,
                StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine(_localizer.GetString("exit"));
            _running = false;
        }
        else if (string.Equals(userInput, _commands.Value.NewTry,
                StringComparison.CurrentCultureIgnoreCase))
        {
            _valueGenerator.SetRandomValue();
            Console.WriteLine(_localizer.GetString("newTry"));
        }
        else if (string.Equals(userInput, _commands.Value.GiveUp,
                     StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine(_localizer.GetString("giveUp"), 
                _valueGenerator.GetRandomValue());
            _running = false;
        }
    }

    public void AfterVictory(string userInput)
    {
        Console.WriteLine(_localizer.GetString("victory"));
        while (_afterVictoryProcess)
        {
            string? newCommand = Console.ReadLine();
            if (string.Equals(newCommand, _commands.Value.Exit,
                    StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine(_localizer.GetString("toExit"));
                Console.ReadKey();
                _afterVictoryProcess = false;
                _running = false;
            }
            else if (string.Equals(newCommand, _commands.Value.NewTry, 
                         StringComparison.CurrentCultureIgnoreCase))
            {
                _valueGenerator.SetRandomValue();
                Console.WriteLine(_localizer.GetString("newGame"));
                _afterVictoryProcess = false;
            }
            else
                Console.WriteLine(_localizer.GetString("correctCommand"));
        }
    }
}



















