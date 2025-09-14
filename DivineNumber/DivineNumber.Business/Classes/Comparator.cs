using DivineNumber.Services.Interfaces;


namespace DivineNumber.Services.Classes
{
    internal class Comparator: IComparator
    {
        private readonly IHiddenValueGenerator _valueGenerator;
        public Comparator(IHiddenValueGenerator valueGenerator)
        {
            _valueGenerator = valueGenerator;
        }
        
        public bool CompareInputAndHiddenValue(string input)
        {
            var res = int.Parse(input);
            return res == _valueGenerator.GetHiddenValue();
        }
    }
}
