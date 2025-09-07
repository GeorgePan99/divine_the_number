using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineNumber.Services.Interfaces
{
    public interface IInputValidator
    {
        public bool IsNumber(string input);
        public bool IsCommand(string input);
        public bool IsInRange(string input);
    }
}
