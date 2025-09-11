using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Options;
using DivineNumber.Services.AdditionalClasses;

namespace DivineNumber.Services.Classes
{
    internal class InputValidator(IOptions<ValueRange> options,
                                  IOptions<Commands> commands): IInputValidator
    {
        private readonly ValueRange _valueRange = options.Value;
        private readonly Commands _commands = commands.Value;
        public bool IsNumber(string input)
        {
            return int.TryParse(input, out int result);
        }
        public bool IsInRange(string input)
        {
            bool res = int.TryParse(input, out int result);
            if (res)
                return _valueRange.MinValue <= result && result <= _valueRange.MaxValue;
            return false;
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
