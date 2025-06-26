using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineNumber.Services.Interfaces
{
    public interface IValueValidation
    {
        public bool IsValid(string userInput);
    }
}
