using DivineNumber.Services;
using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();

services.AddServices();

var provider = services.BuildServiceProvider();

var greetingService = provider.GetRequiredService<IExecution>();

greetingService.Greetings();
greetingService.Execute();