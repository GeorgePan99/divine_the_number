using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
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
        private readonly IValueValidator validation;
        private readonly ICommandHandler command;
        private readonly IExiter exiter;
        private readonly ValueRange ValueRange;
        private readonly IStringLocalizer<SharedResource> localizer;
        public Comparator(IValueValidator validation,
                          ICommandHandler command,
                          IExiter exiter,
                          IOptions<ValueRange> options,
                          IStringLocalizer<SharedResource> localizer)
        {
            this.validation = validation;
            this.command = command;
            this.exiter = exiter;
            this.ValueRange = options.Value;
            this.localizer = localizer;
        }
        public void SetRandValue()
        {
            Random random = new Random();
            randValue = random.Next(ValueRange.MinValue, ValueRange.MaxValue + 1);
        }
        public void IsCorrectValue(string userInput)
        {
            command.Handle(userInput);
            if (validation.ValidateValue(userInput))
            {
                if (randValue == Convert.ToInt32(userInput))
                {
                    Console.WriteLine(localizer["Congratulation"]);
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
                    Console.WriteLine(localizer["Mistake"]);
                }
            }
        }
    }
}
