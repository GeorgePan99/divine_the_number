using DivineNumber.Services;
using DivineNumber.UI.Interfaces;
using DivineNumber.Services.AdditionalClasses;
using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace DivineNumber.UI.Classes;

public class Game: IGame
{
    private readonly IHiddenValueGenerator _valueGenerator;
    private readonly IComparator _comparator;
    private readonly IInputValidator _inputValidator;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IOptions<ValueRange> _valueRange;
    private readonly IOptions<Commands> _commands;
    private bool _running = true;
    private bool _afterVictoryProcess = true;

    public Game
    (
        IHiddenValueGenerator valueGenerator,
        IComparator comparator,
        IInputValidator inputValidator,
        IStringLocalizer<SharedResource> localizer,
        IOptions<ValueRange> valueRange,
        IOptions<Commands> commands
    )
    {
        _valueGenerator = valueGenerator;
        _comparator = comparator;
        _inputValidator = inputValidator;
        _localizer = localizer;
        _valueRange = valueRange;
        _commands = commands;
    }

    public void StartGame()
    {
        Console.WriteLine(_localizer["Greeting"],
            _valueRange.Value.MinValue,
            _valueRange.Value.MaxValue,
            _commands.Value.Exit,
            _commands.Value.GiveUp,
            _commands.Value.NewTry);
        
        while (_running)
        {
            string? userInput = Console.ReadLine();
            if (IsInSpot(userInput))
            {
                Console.WriteLine(_localizer["victory"]);
                DefineCommand();
            }
            else if (IsWrong(userInput))
                Console.WriteLine(_localizer["wrong"]);
            else if (IsNotInRange(userInput))
                Console.WriteLine(_localizer["outOfRange"]);
            else if (_inputValidator.IsCommand(userInput))
                DefineCommand(userInput);
            else
                Console.WriteLine(_localizer["incorrectData"]);
        }
    }

    private bool IsInSpot(string userInput)
    {
        return _inputValidator.IsNumber(userInput) &&
               _inputValidator.IsInRange(int.Parse(userInput)) &&
               _comparator.CompareInputAndHiddenValue(userInput);
    }
    
    private bool IsWrong(string userInput)
    {
        return _inputValidator.IsNumber(userInput) &&
               _inputValidator.IsInRange(int.Parse(userInput)) &&
               !_comparator.CompareInputAndHiddenValue(userInput);
    }
    
    private bool IsNotInRange(string userInput)
    {
        return _inputValidator.IsNumber(userInput) &&
               !_inputValidator.IsInRange(int.Parse(userInput));
    }
    private void DefineCommand(string userInput = "")
    {
        while (_afterVictoryProcess)
        {
            string? command;
            command = string.IsNullOrEmpty(userInput) ? Console.ReadLine() : userInput;
            
            if (string.Equals(command, _commands.Value.Exit,
                    StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine(_localizer["toExit"]);
                Console.ReadKey();
                _afterVictoryProcess = false;
                _running = false;
            }
            else if (string.Equals(command, _commands.Value.NewTry,
                         StringComparison.CurrentCultureIgnoreCase))
            {
                _valueGenerator.SetHiddenValue();
                Console.WriteLine(_localizer["newTry"]);
                _afterVictoryProcess = false;
            }
            else if (string.Equals(command, _commands.Value.GiveUp,
                         StringComparison.CurrentCultureIgnoreCase) &&
                     userInput.Length > 0)
            {
                Console.WriteLine(_localizer.GetString("giveUp"),
                    _valueGenerator.GetHiddenValue());
                _afterVictoryProcess = false;
                _running = false;
            }
            else
            {
                Console.WriteLine(_localizer["incorrectData"]);
            }
        }
    }
}



















