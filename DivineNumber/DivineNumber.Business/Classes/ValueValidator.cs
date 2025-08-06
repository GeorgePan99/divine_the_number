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
            if (int.TryParse(userInput, out int number))
            {
                if (number <= ValueRange.MaxValue &&
                    number >= ValueRange.MinValue
                    )
                {
                    return true;
                }
                else
                {
                    Console.WriteLine(localizer["Range"]);
                    return false;
                }
            }
            else
            {
                Console.WriteLine(localizer["IncorrectData"]);
                return false;
            }
        }
    }
}
