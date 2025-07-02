using DivineNumber.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineNumber.Services.Classes
{
    public class Exiter : IExiter
    {
        public bool IsExitOrAgain(string userInput)
        {
            userInput = userInput.ToLower();
            if (userInput == "exit")
            {
                Console.WriteLine($"Хорошего дня!");
                Process.GetCurrentProcess().Kill();
                return true;
            }
            else if (userInput == "again")
            {
                Console.WriteLine($"Угадайте число еще раз!");
                return true;
            }
            else
            {
                Console.WriteLine($"Введите корректную команду.");
                return false;
            }
        }
    }
}
