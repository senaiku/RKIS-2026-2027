// Консоль выводит русский текст в кодировке UTF-8
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Работу выполнил Добрынин");

Console.Write("Введите имя: ");
string firstName = Console.ReadLine() ?? "";

Console.Write("Введите фамилию: ");
string lastName = Console.ReadLine() ?? "";

Console.Write("Введите год рождения: ");
string birthYearText = Console.ReadLine() ?? "";

// Преобразуем год рождения в целое число и считаем возраст
int birthYear = int.Parse(birthYearText);
int age = DateTime.Now.Year - birthYear;

Console.WriteLine($"Добавлен пользователь {firstName} {lastName}, возраст - {age}");

string[] todos = new string[2];

while (true)
{
    Console.Write("Введите команду: ");
    string command = Console.ReadLine() ?? "";

    if (command == "exit")
    {
        break;
    }
    if (command == "help")
    {
        Console.WriteLine("Доступные команды:");
        Console.WriteLine("help - вывести список команд");
        Console.WriteLine("profile - показать данные пользователя");
        Console.WriteLine("add \"текст задачи\" - добавить задачу");
        Console.WriteLine("view - показать все задачи");
        Console.WriteLine("exit - завершить программу");
        continue;
    }
    if (command == "profile")
    {
        Console.WriteLine($"{firstName} {lastName}, {birthYear}");
        continue;
    }

    Console.WriteLine("Неизвестная команда.");
}
