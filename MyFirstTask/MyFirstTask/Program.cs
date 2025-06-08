using System.Diagnostics;
using Microsoft.Extensions.Configuration;


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();


int MinValue = configuration.GetValue<int>("min_value");
int MaxValue = configuration.GetValue<int>("max_value");

var rand = new Random();
int mysteryValue = rand.Next(MinValue, MaxValue + 1);



void Greeting(int min, int max)
{
    string GreetingText = $"""
            Добро пожаловать в игру "Угадай число"!
        Наши правила невероятно просты: мы загадываем вам число в диапазоне от {min} до {max},
        а вам предстоит его угадать!
            Если вы поймете, что вы не в силах больше справляться,
        вы можете ввести слово "giveup", и таким образом, прекратите свои попытки.
        А мы, в свою очередь, скажем, какое число загадали.
            Если вы захотите выйти из игры, напишите "exit".
        Удачи!
        """;
    Console.WriteLine(GreetingText, min, max);
    Console.WriteLine();
    Console.WriteLine("Введите предполагаемое число");
}

void IsValue(int userValue)
{
    if (userValue == mysteryValue)
    {
        Console.WriteLine("Вы угадали число! Вы молодец!");
        Process.GetCurrentProcess().Kill();
    }
    else if (userValue > MaxValue || userValue < MinValue)
    {
        Console.WriteLine("Число вне заданных границ!");
        Input();
    }
    else
    {
        Console.WriteLine("Неверно:(");
        Input();
    }
}

void IsCommand(string userString)
{
    if (userString == "giveup")
    {
        Console.WriteLine("В следующий раз повезет!");
        Console.WriteLine($"Загаданное число: {mysteryValue}");
        Process.GetCurrentProcess().Kill();
    }
    else if (userString == "exit")
    {
        Console.WriteLine("Хорошего дня!");
        Process.GetCurrentProcess().Kill();
    }
    else
    {
        Console.WriteLine("Введенное вами значение не подходит. Попробуйте еще раз");
        Input();
    }
}


void Input()
{
    string userInput = Console.ReadLine();
    try
    {
        IsValue(Convert.ToInt32(userInput));

    }
    catch
    {
        IsCommand(userInput);
    }
}


Greeting(MinValue, MaxValue);
Input();