using DivineNumber.Services.AddClasses;
using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineNumber.Services.Classes
{
    internal class ValueGenerator: IValueGenerator
    {
        private int _randomValue;
        private readonly ValueRange _valueRange;
        private readonly int _additive = 1;
        public ValueGenerator(IOptions<ValueRange> options)
        {
            this._valueRange = options.Value;
            Random rnd = new Random();
            this._randomValue = rnd.Next(_valueRange.MinValue,
                                    _valueRange.MaxValue + _additive);
        }
        public void SetRandomValue()
        {
            Random rnd = new Random();
            this._randomValue = rnd.Next(_valueRange.MinValue,
                                    _valueRange.MaxValue + _additive);
        }
        public int GetRandomValue()
        {
            return this._randomValue;
        }
    }
}
