using DivineNumber.Services;
using DivineNumber.Services.AdditionalClasses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Globalization;
using DivineNumber.UI.Classes;
using DivineNumber.UI.Interfaces;


var services = new ServiceCollection();

services.AddServices();

services.AddSingleton<IGame, Game>();

using var provider = services.BuildServiceProvider();

var languageOptions = provider.GetService<IOptions<LanguageField>>();

CultureInfo.CurrentUICulture = new CultureInfo(languageOptions.Value.Language);

var gameService = provider.GetRequiredService<IGame>();


gameService.StartGame();