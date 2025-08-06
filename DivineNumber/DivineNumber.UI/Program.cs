using DivineNumber.Services.Classes;
using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Globalization;


var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var services = new ServiceCollection()
    .AddTransient<ICommandValidator, CommandValidator>()
    .AddTransient<IValueValidator, ValueValidator>()
    .AddTransient<IComparator, Comparator>()
    .AddTransient<IExiter, Exiter>()
    .AddLogging()
    .AddTransient<ValueRange>()
    .AddTransient<LanguageField>()
    .AddLocalization(options =>
        {
            options.ResourcesPath = "Resources";
        })
    .AddTransient<Execution>();

services.Configure<ValueRange>(config.GetSection(key: "Range"));
services.Configure<LanguageField>(config.GetSection(key: "Language"));


using var serviceProvider = services.BuildServiceProvider();

var languageService = serviceProvider.GetService<IOptions<LanguageField>>();

CultureInfo.CurrentUICulture = new CultureInfo(languageService.Value.Language);

Execution? execution = serviceProvider.GetService<Execution>();

execution.Greetings();
execution.Execute();