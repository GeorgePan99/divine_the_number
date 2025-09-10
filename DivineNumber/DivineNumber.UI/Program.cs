using DivineNumber.Services;
using DivineNumber.Services.AdditionalClasses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Globalization;
using DivineNumber.UI.Classes;
using DivineNumber.UI.Interfaces;


var services = new ServiceCollection();

services.AddServices();

services.AddSingleton<IGreeting, Greeting>();
services.AddSingleton<IGame, Game>();

using var provider = services.BuildServiceProvider();

var languageService = provider.GetService<IOptions<LanguageField>>();

CultureInfo.CurrentUICulture = new CultureInfo(languageService.Value.Language);

var greetingService = provider.GetRequiredService<IGreeting>();
var gameService = provider.GetRequiredService<IGame>();


greetingService.WriteGreeting();
gameService.StartGame();