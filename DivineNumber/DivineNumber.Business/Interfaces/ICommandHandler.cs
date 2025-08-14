using DivineNumber.Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineNumber.Services.Interfaces
{
    public interface ICommandHandler
    {
        public void Handle(string userInput);
    }
}
