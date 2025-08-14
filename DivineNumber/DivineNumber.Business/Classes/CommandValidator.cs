using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace DivineNumber.Services.Classes
{
    public class CommandValidator : ICommandHandler
    {
        private readonly IStringLocalizer<SharedResource> localizer;
        public CommandValidator(IStringLocalizer<SharedResource> localizer)
        {
            this.localizer = localizer;
        }
        public void Handle(string userInput)
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
