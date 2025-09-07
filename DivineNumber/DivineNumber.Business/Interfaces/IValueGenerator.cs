using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineNumber.Services.Interfaces
{
    public interface IValueGenerator
    {
        public void SetRandomValue();
        public int GetRandomValue();
    }
}
