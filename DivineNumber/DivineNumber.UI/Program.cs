using DivineNumber.Services;
using DivineNumber.Services.AddClasses;
using DivineNumber.Services.AdditionalClasses;
using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;


var services = new ServiceCollection();

services.AddServices();

using var provider = services.BuildServiceProvider();

var languageService = provider.GetService<IOptions<LanguageField>>();
var valueService = provider.GetRequiredService<IOptions<ValueRange>>();
var commandService = provider.GetRequiredService<IOptions<Commands>>();


CultureInfo.CurrentUICulture = new CultureInfo(languageService.Value.Language);

var generatorService = provider.GetRequiredService<IValueGenerator>();
var validatorService = provider.GetRequiredService<IInputValidator>();
var comparatorService = provider.GetRequiredService<IComparator>();
var greetingsService = provider.GetRequiredService<IGreetings>();

var localizer = provider.GetRequiredService<ILocalizer>();

Console.WriteLine(greetingsService.Greeting(),
                  valueService.Value.MinValue,
                  valueService.Value.MaxValue,
                  commandService.Value.Exit,
                  commandService.Value.GiveUp,
                  commandService.Value.NewTry);


bool running = true;

while (running)
{
    string? userInput = Console.ReadLine();

    if (validatorService.IsNumber(userInput) &&
        validatorService.IsInRange(userInput) &&
        comparatorService.Compare(userInput))
    {
        AfterVictory(userInput);
    }

    else if (validatorService.IsNumber(userInput) &&
             validatorService.IsInRange(userInput) &&
             !comparatorService.Compare(userInput))
        Console.WriteLine(localizer.GetString("wrong"));

    else if (validatorService.IsNumber(userInput) &&
         !validatorService.IsInRange(userInput) &&
         !comparatorService.Compare(userInput))
        Console.WriteLine(localizer.GetString("outOfRange"));

    else if (validatorService.IsCommand(userInput))
    {
        DefineCommand(userInput);
    }

    else if (!validatorService.IsCommand(userInput))
        Console.WriteLine(localizer.GetString("incorrectData"));
}

void DefineCommand(string input)
{
    if (input.ToLower() == commandService.Value.Exit)
    {
        Console.WriteLine(localizer.GetString("toExit"));
        Console.ReadKey();
        Process.GetCurrentProcess().Kill();
    }
    else if (input.ToLower() == commandService.Value.NewTry)
    {
        generatorService.SetRandomValue();
        Console.WriteLine(localizer.GetString("newTry"));
    }
    else if (input.ToLower() == commandService.Value.GiveUp)
    {
        Console.WriteLine(localizer.GetString("giveUp"), generatorService.GetRandomValue());
    }
}

void AfterVictory(string input)
{
    Console.WriteLine(localizer.GetString("victory"));
    bool flag = false;
    while (!flag)
    {
        string newCommand = Console.ReadLine();
        if (newCommand.ToLower() == commandService.Value.Exit)
        {
            Console.WriteLine(localizer.GetString("toExit"));
            Console.ReadKey();
            Process.GetCurrentProcess().Kill();
        }
        else if (newCommand.ToLower() == commandService.Value.NewTry)
        {
            generatorService.SetRandomValue();
            Console.WriteLine(localizer.GetString("newGame"));
            flag = true;
        }
        else
        {
            Console.WriteLine(localizer.GetString("correctCommand"));
        }
    }
}
