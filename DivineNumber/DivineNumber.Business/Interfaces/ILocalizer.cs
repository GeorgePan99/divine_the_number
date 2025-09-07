using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineNumber.Services.Interfaces
{
    public interface ILocalizer
    {
        string GetString(string key);
    }
}
