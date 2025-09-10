using DivineNumber.Services.Interfaces;


namespace DivineNumber.Services.Classes
{
    internal class Comparator(IValueGenerator valueGenerator): IComparator
    {
        private readonly IValueGenerator _valueGenerator = valueGenerator;
        
        public bool Compare(string input)
        {
            var res = int.Parse(input);
            return res == _valueGenerator.GetRandomValue();
        }
    }
}
