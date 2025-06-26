using DivineNumber.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineNumber.Services.Classes
{
    public class Comparator : IComparison
    {
        public readonly int randValue;
        private readonly int minValue = 1;
        private readonly int maxValue = 10;
        private readonly IValueValidation validation;
        private readonly ICommandValidation command;
        public Comparator(IValueValidation validation,
                          ICommandValidation command)
        {
            Random random = new Random();
            this.randValue = random.Next(minValue, maxValue + 1);
            this.validation = validation;
            this.command = command;
        }
        public void IsCorrectValue(string userInput)
        {
            command.IsCommand(userInput);
            if (validation.IsValid(userInput))
            {
                if (randValue == Convert.ToInt32(userInput))
                {
                    Console.WriteLine("Вы угадали!");
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    Console.WriteLine("Вы не угадали!");
                }
            }
        }
    }
}
