using DivineNumber.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace DivineNumber.Services.AdditionalClasses
{
    public class ResourceLocalizer : ILocalizer
    {
        private readonly ResourceManager _resourceManager;

        public ResourceLocalizer()
        {
            _resourceManager = new ResourceManager(
                "DivineNumber.Services.Resources.SharedResource",
                Assembly.GetExecutingAssembly());
        }

        public string GetString(string key)
        {
            return _resourceManager.GetString(key, CultureInfo.CurrentUICulture);
        }
    }
}
