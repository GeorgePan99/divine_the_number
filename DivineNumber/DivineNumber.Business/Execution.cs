using DivineNumber.Services.Classes;
using DivineNumber.Services.Interfaces;


public class Execution
{
    private readonly IComparator comparison;
    public Execution(IComparator comparison)
    {
        this.comparison = comparison;
    }
    public void Greetings()
    {
        Console.WriteLine
            (
            "Вы попали в игру 'Угадай число!'\n" +
            "Ваша задача угадать число.\n" +
            "Если вы захотите выйти, введите в консоль 'exit'.\n" +
            "Есть захотите сдаться, введите 'giveup'.\n" +
            "Удачи!"
            );
    }
    public void Execute()
    {
        comparison.SetRandValue();
        while (true)
        {
            string userInput = Console.ReadLine();
            comparison.IsCorrectValue(userInput);
        }
    }
}