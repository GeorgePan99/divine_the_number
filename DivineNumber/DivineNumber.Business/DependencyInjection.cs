using DivineNumber.Services.AdditionalClasses;
using DivineNumber.Services.Classes;
using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DivineNumber.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            
            
            services
                .AddSingleton<IValueGenerator, ValueGenerator>()
                .AddSingleton<IInputValidator, InputValidator>()
                .AddSingleton<IComparator, Comparator>()
                .AddLogging()
                .AddLocalization(options =>
                {
                    options.ResourcesPath = "Resources";
                })
                .AddSingleton<ILocalizer, ResourceLocalizer>();

            services.Configure<ValueRange>(config.GetSection(key: "Range"));
            services.Configure<Commands>(config.GetSection(key: "Commands"));
            services.Configure<LanguageField>(config.GetSection(key: "Language"));

            return services;
        }
    }
}
