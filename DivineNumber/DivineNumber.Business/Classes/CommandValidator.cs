using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
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
        public void IsCommand(string userInput)
        {
            userInput = userInput.ToLower();
            if (userInput == "giveup" || userInput == "exit")
            {
                Console.WriteLine($"Хорошего дня!");
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
