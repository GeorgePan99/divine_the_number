using DivineNumber.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineNumber.Services.Classes
{
    public class Comparator : IComparator
    {
        private int randValue;
        private readonly int minValue = 1;
        private readonly int maxValue = 10;
        private readonly IValueValidator validation;
        private readonly ICommandValidator command;
        private readonly IExiter exiter;
        public Comparator(IValueValidator validation,
                          ICommandValidator command,
                          IExiter exiter)
        {
            this.validation = validation;
            this.command = command;
            this.exiter = exiter;
        }
        public void SetRandValue()
        {
            Random random = new Random();
            randValue = random.Next(minValue, maxValue + 1);
        }
        public void IsCorrectValue(string userInput)
        {
            command.IsCommand(userInput);
            if (validation.IsValid(userInput))
            {
                if (randValue == Convert.ToInt32(userInput))
                {
                    Console.WriteLine("Вы угадали!");
                    Console.WriteLine("Чтобы выйти, введите exit.");
                    Console.WriteLine("Чтобы сыграть еще раз, введите again.");
                    bool resolution = false;
                    while (resolution is false)
                    {
                        resolution = exiter.IsExitOrAgain(Console.ReadLine());
                        if (resolution is true)
                        {
                            SetRandValue();
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Вы не угадали!");
                }
            }
        }
    }
}
