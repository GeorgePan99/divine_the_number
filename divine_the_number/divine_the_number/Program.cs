using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

var builder = WebApplication.CreateBuilder();
builder.Configuration.AddJsonFile("config.json");
var app = builder.Build();


int MIN_VALUE = Convert.ToInt32(app.Configuration["min_value"]);
int MAX_VALUE = Convert.ToInt32(app.Configuration["max_value"]);

var rand = new Random();
int mystery_vaue = rand.Next(MIN_VALUE, MAX_VALUE + 1);

void Greeting(int min, int max)
{
    string text = $"""
            Добро пожаловать в игру "Угадай число"!
        Наши правила невероятно просты: мы загадываем вам число в диапазоне от {min} до {max},
        а вам предстоит его угадать!
            Если вы поймете, что вы не в силах больше справляться,
        вы можете ввести слово "giveup", и таком образом, прекратите свои попытки.
        А мы, в свою очередь, скажем, какое число загадали.
            Если вы захотите выйти из игры, напишите "exit".
        Удачи!
        """;
    Console.WriteLine(text);
    Console.WriteLine();
    Console.WriteLine("Введите предполагаемое число");
}

void IsValue(int user_value)
{
    if (user_value == mystery_vaue)
    {
        Console.WriteLine("Вы угадали число! Вы молодец!");
        Process.GetCurrentProcess().Kill();
    }
    else if (user_value > MAX_VALUE || user_value < MIN_VALUE)
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

void IsCommand(string user_string)
{
    if (user_string == "giveup")
    {
        Console.WriteLine("В следующий раз повезет!");
        Console.WriteLine($"Загаданное число: {mystery_vaue}");
        Process.GetCurrentProcess().Kill();
    }
    else if (user_string == "exit")
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
    string user_input = Console.ReadLine();
    try
    {
        IsValue(Convert.ToInt32(user_input));

    }
    catch
    {
        IsCommand(user_input);
    }
}

Greeting(MIN_VALUE, MAX_VALUE);
Input();