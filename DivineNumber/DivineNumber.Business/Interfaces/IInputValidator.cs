namespace DivineNumber.Services.Interfaces
{
    public interface IInputValidator
    {
        public bool IsNumber(string input);
        public bool IsCommand(string input);
        public bool IsInRange(int input);
    }
}
