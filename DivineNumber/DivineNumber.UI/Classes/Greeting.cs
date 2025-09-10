using DivineNumber.Services;
using DivineNumber.Services.AdditionalClasses;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using DivineNumber.UI.Interfaces;

namespace DivineNumber.UI.Classes;

public class Greeting(IStringLocalizer<SharedResource> localizer,
                      IOptions<ValueRange> valueRange,
                      IOptions<Commands> commands) : IGreeting
{
    private readonly IStringLocalizer<SharedResource> _localizer = localizer;
    private readonly IOptions<ValueRange> _valueRange = valueRange;
    private readonly IOptions<Commands> _commands = commands;

    public void WriteGreeting()
    {
        Console.WriteLine(_localizer["Greeting"],
                          _valueRange.Value.MinValue,
                          _valueRange.Value.MaxValue,
                          _commands.Value.Exit,
                          _commands.Value.GiveUp,
                          _commands.Value.NewTry);
    }
}