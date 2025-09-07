using DivineNumber.Services.AddClasses;
using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineNumber.Services.Classes
{
    internal class Greetings: IGreetings
    {
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly ValueRange _valueRange;
        private readonly Commands _commands;
        public Greetings(IStringLocalizer<SharedResource> localizer,
                         IOptions<ValueRange> options,
                          IOptions<Commands> commands)
        {
            this.localizer = localizer;
            this._valueRange = options.Value;
            this._commands = commands.Value;

        }
        public string Greeting()
        {
            return localizer["Greeting"];
        }
    }
}
