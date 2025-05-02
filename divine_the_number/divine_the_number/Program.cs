var builder = WebApplication.CreateBuilder();
builder.Configuration.AddJsonFile("config.json");
var app = builder.Build();


int min_value = Convert.ToInt32(app.Configuration["min_value"]);
int max_value = Convert.ToInt32(app.Configuration["max_value"]);


var rand = new Random();
int mistery_vaue = rand.Next(min_value, max_value + 1);

Console.WriteLine($"Введите число от {min_value} до {max_value}");

// тут нужно обрабатывать исключения
int user_value = Convert.ToInt32(Console.ReadLine());

while (user_value != mistery_vaue)
{
    Console.WriteLine("Не угадали!");
    user_value = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("Вы молодец! Число угадано!");