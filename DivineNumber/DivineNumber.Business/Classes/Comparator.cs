using DivineNumber.Services.Interfaces;


namespace DivineNumber.Services.Classes
{
    internal class Comparator: IComparator
    {
        public IValueGenerator valueGenerator;
        public IInputValidator inputValidator;
        public Comparator(IValueGenerator valueGenerator,
                          IInputValidator inputValidator)
        {
            this.valueGenerator = valueGenerator;
            this.inputValidator = inputValidator;
        }
        public bool Compare(string input)
        {
            int res = int.Parse(input);
            if (res == valueGenerator.GetRandomValue())
                return true;
            return false;
        }
    }
}
