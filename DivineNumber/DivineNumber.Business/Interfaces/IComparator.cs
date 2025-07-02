using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineNumber.Services.Interfaces
{
    public interface IComparator
    {
        public void IsCorrectValue(string userInput);
        public void SetRandValue();
    }
}