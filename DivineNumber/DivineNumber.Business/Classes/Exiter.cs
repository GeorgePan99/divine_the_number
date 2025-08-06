using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace DivineNumber.Services.Classes
{
    public class Exiter : IExiter
    {
        private readonly IStringLocalizer<SharedResource> localizer;
        public Exiter(IStringLocalizer<SharedResource> localizer)
        {
            this.localizer = localizer;
        }
        public bool IsExitOrAgain(string userInput)
        {
            userInput = userInput.ToLower();
            if (userInput == "exit")
            {

                Console.WriteLine(localizer["Farewell"]);
                Process.GetCurrentProcess().Kill();
                return true;
            }
            else if (userInput == "again")
            {
                Console.WriteLine(localizer["Again"]);
                return true;
            }
            else
            {
                Console.WriteLine(localizer["IncorrectCommand"]);
                return false;
            }
        }
    }
}
