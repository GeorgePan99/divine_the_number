using DivineNumber.Services.AddClasses;
using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DivineNumber.Services.Classes
{
    internal class InputValidator: IInputValidator
    {
        private readonly ValueRange _valueRange;
        private readonly Commands _commands;
        public InputValidator(IOptions<ValueRange> options,
                              IOptions<Commands> commands)
        {
            this._valueRange = options.Value;
            this._commands = commands.Value;
        }
        public bool IsNumber(string input)
        {
            if (int.TryParse(input, out int result))
                return true;
            return false;
        }
        public bool IsInRange(string input)
        {
            bool res = int.TryParse(input, out int result);
            if (_valueRange.MinValue <= result && result <= _valueRange.MaxValue)
                return true;
            return false;
        }

        public bool IsCommand(string input)
        {
            if (input.ToLower() == _commands.NewTry)
                return true;
            if (input.ToLower() == _commands.Exit)
                return true;
            if (input.ToLower() == _commands.GiveUp)
                return true;
            return false;
        }
    }
}
