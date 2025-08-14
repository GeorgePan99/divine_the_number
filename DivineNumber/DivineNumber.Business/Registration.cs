using DivineNumber.Services.Classes;
using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


public static class ClearDI
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        services
            .AddTransient<ICommandHandler, CommandValidator>()
            .AddTransient<IValueValidator, ValueValidator>()
            .AddTransient<IComparator, Comparator>()
            .AddTransient<IExiter, Exiter>()
            .AddLogging()
            .AddTransient<ValueRange>()
            .AddTransient<LanguageField>()
            .AddTransient<IExecution, Execution>()
            .AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });

        services.Configure<ValueRange>(config.GetSection(key: "Range"));
        services.Configure<LanguageField>(config.GetSection(key: "Language"));

        return services;
    }
}