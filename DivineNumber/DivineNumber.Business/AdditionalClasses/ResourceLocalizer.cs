using DivineNumber.Services.Interfaces;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace DivineNumber.Services.AdditionalClasses
{
    public class ResourceLocalizer : ILocalizer
    {
        public required ResourceManager ResourceManager;

        public ResourceLocalizer()
        {
            ResourceManager = new ResourceManager(
                "DivineNumber.Services.Resources.SharedResource",
                Assembly.GetExecutingAssembly());
        }

        public string GetString(string key)
        {
            return ResourceManager.GetString(key, CultureInfo.CurrentUICulture);
        }
    }
}
