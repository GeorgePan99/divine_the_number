using DivineNumber.Services.Classes;
using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection()
    .AddTransient<ICommandValidator, CommandValidator>()
    .AddTransient<IValueValidator, ValueValidator>()
    .AddTransient<IComparator, Comparator>()
    .AddTransient<IExiter, Exiter>()
    .AddTransient<Execution>();

using var serviceProvider = services.BuildServiceProvider();

//IComparison? comparator = serviceProvider.GetService<IComparison>();
//ICommandValidation? commandValidator = serviceProvider.GetService<ICommandValidation>();
//IValueValidation? valueValidator = serviceProvider.GetService<IValueValidation>();
Execution? execution = serviceProvider.GetService<Execution>();

execution.Greetings();
execution.Execute();