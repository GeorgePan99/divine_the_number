using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineNumber.Services.Classes
{
    public class CommandValidator : ICommandValidator
    {
        private readonly IStringLocalizer<SharedResource> localizer;
        public CommandValidator(IStringLocalizer<SharedResource> localizer)
        {
            this.localizer = localizer;
        }
        public void IsCommand(string userInput)
        {
            userInput = userInput.ToLower();
            if (userInput == "giveup" || userInput == "exit")
            {
                Console.WriteLine(localizer["Farewell"]);
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
