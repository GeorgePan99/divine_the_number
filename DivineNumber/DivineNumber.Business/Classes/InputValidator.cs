using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Options;
using DivineNumber.Services.AdditionalClasses;

namespace DivineNumber.Services.Classes
{
    internal class InputValidator: IInputValidator
    {
        private readonly ValueRange _valueRange;
        private readonly Commands _commands;
        public InputValidator(IOptions<ValueRange> options,
                              IOptions<Commands> commands)
        {
            _valueRange = options.Value;
            _commands = commands.Value;
        }
        public bool IsNumber(string input)
        {
            return int.TryParse(input, out int result);
        }
        public bool IsInRange(int input)
        {
            return _valueRange.MinValue <= input && input <= _valueRange.MaxValue;
        }

        public bool IsCommand(string input)
        {
            if (string.Equals(input, _commands.NewTry, 
                    StringComparison.CurrentCultureIgnoreCase))
                return true;
            if (string.Equals(input, _commands.Exit, 
                    StringComparison.CurrentCultureIgnoreCase))
                return true;
            if (string.Equals(input, _commands.GiveUp, 
                    StringComparison.CurrentCultureIgnoreCase))
                return true;
            return false;
        }
    }
}
