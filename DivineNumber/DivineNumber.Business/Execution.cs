using DivineNumber.Services;
using DivineNumber.Services.Classes;
using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;


public class Execution: IExecution
{
    private readonly IComparator comparison;
    private readonly ValueRange ValueRange;
    private readonly IStringLocalizer<SharedResource> localizer;
    public Execution(IComparator comparison,
                     IOptions<ValueRange> options,
                     IStringLocalizer<SharedResource> localizer)
    {
        this.comparison = comparison;
        this.ValueRange = options.Value;
        this.localizer = localizer;
    }
    public void Greetings()
    {
        Console.WriteLine(localizer["Greetings"], 
                          ValueRange.MinValue, 
                          ValueRange.MaxValue);
    }
    public void Execute()
    {
        comparison.SetRandValue();
        while (true)
        {
            string userInput = Console.ReadLine();
            comparison.IsCorrectValue(userInput);
        }
    }
}

