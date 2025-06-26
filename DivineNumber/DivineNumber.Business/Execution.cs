using DivineNumber.Services.Classes;
using DivineNumber.Services.Interfaces;


public class Execution
{
    private readonly IComparison comparison;
    public Execution(IComparison comparison)
    {
        this.comparison = comparison;
    }
    public void Execute()
    {
        while (true)
        {
            string userInput = Console.ReadLine();
            comparison.IsCorrectValue(userInput);
        }
    }
}