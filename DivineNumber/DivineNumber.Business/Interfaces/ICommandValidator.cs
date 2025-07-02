using DivineNumber.Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineNumber.Services.Interfaces
{
    public interface ICommandValidator
    {
        public void IsCommand(string userInput);
    }
}
