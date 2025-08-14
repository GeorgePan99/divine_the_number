using DivineNumber.Services;
using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();

// Регистрируем сервисы из бизнес-слоя
services.AddServices();

var provider = services.BuildServiceProvider();

// Получаем сервис
var greetingService = provider.GetRequiredService<IExecution>();

greetingService.Greetings();
greetingService.Execute();