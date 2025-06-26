using DivineNumber.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineNumber.Services.Classes
{
    public class ValueValidator : IValueValidation
    {
        private readonly int minValue = 1;
        private readonly int maxValue = 10;
        public bool IsValid(string userInput)
        {
            userInput = userInput.ToLower();
            if (int.TryParse(userInput, out int value) && 
                value <= maxValue &&
                value >= minValue)
            {
                return true;
            }
            else if (!int.TryParse(userInput, out int number))
            {
                Console.WriteLine($"Некорректные данные!");
                return false;
            }
            else
            {
                Console.WriteLine("Число должно находиться в интервале!");
                return false;
            }
        }
    }
}
