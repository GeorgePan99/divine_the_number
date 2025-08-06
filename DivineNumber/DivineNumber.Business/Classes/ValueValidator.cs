using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;


namespace DivineNumber.Services.Classes
{
    public class ValueValidator : IValueValidator
    {
        private readonly ValueRange ValueRange;
        private readonly IStringLocalizer<SharedResource> localizer;
        public ValueValidator(IOptions<ValueRange> options,
                              IStringLocalizer<SharedResource> localizer)
        {
            this.ValueRange = options.Value;
            this.localizer = localizer;
        }
        public bool IsValid(string userInput)
        {
            userInput = userInput.ToLower();
            if (int.TryParse(userInput, out int value) && 
                value <= ValueRange.MaxValue &&
                value >= ValueRange.MinValue)
            {
                return true;
            }
            else if (!int.TryParse(userInput, out int number))
            {
                Console.WriteLine(localizer["IncorrectData"]);
                return false;
            }
            else
            {
                Console.WriteLine(localizer["Range"]);
                return false;
            }
        }
    }
}
