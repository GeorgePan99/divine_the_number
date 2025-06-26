using DivineNumber.Services.Classes;
using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection()
    .AddTransient<ICommandValidation, CommandValidator>()
    .AddTransient<IValueValidation, ValueValidator>()
    .AddTransient<IComparison, Comparator>()
    .AddTransient<Execution>();


using var serviceProvider = services.BuildServiceProvider();

IComparison? comparator = serviceProvider.GetService<IComparison>();
ICommandValidation? commandValidator = serviceProvider.GetService<ICommandValidation>();
IValueValidation? valueValidator = serviceProvider.GetService<IValueValidation>();
Execution? execution = serviceProvider.GetService<Execution>();

execution.Execute();
