using DivineNumber.Services.Interfaces;
using Microsoft.Extensions.Options;
using DivineNumber.Services.AdditionalClasses;

namespace DivineNumber.Services.Classes
{
    internal class ValueGenerator: IValueGenerator
    {
        private int _randomValue;
        private readonly ValueRange _valueRange;
        private readonly int _additive = 1;
        private readonly Random _rnd = new Random();
        public ValueGenerator(IOptions<ValueRange> options)
        {
            _valueRange = options.Value;
            _randomValue = _rnd.Next(_valueRange.MinValue,
                                    _valueRange.MaxValue + _additive);
        }
        public void SetRandomValue()
        {
            this._randomValue = _rnd.Next(_valueRange.MinValue,
                                    _valueRange.MaxValue + _additive);
        }
        public int GetRandomValue()
        {
            return this._randomValue;
        }
    }
}
