namespace TodoListApp
{
    internal class Program
    {
        private const int InitialTodosCapacity = 2;
        private const int CapacityGrowthFactor = 2;
        private const char TaskTextSeparator = '"';

        private const string CommandHelp = "help";
        private const string CommandProfile = "profile";
        private const string CommandAdd = "add";
        private const string CommandView = "view";
        private const string CommandExit = "exit";

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Работу выполнил Добрынин");

            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine() ?? "";

            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine() ?? "";

            Console.Write("Введите год рождения: ");
            string birthYearText = Console.ReadLine() ?? "";

            int birthYear = int.Parse(birthYearText);
            int age = DateTime.Now.Year - birthYear;

            Console.WriteLine($"Добавлен пользователь {firstName} {lastName}, возраст - {age}");

            string[] todos = new string[InitialTodosCapacity];
            int todoCount = 0;

            while (true)
            {
                Console.Write("Введите команду: ");
                string command = Console.ReadLine() ?? "";

                if (command == CommandExit)
                {
                    break;
                }

                if (command == CommandHelp)
                {
                    ShowHelp();
                    continue;
                }

                if (command == CommandProfile)
                {
                    Console.WriteLine($"{firstName} {lastName}, {birthYear}");
                    continue;
                }

                if (command.StartsWith(CommandAdd + " "))
                {
                    string[] parts = command.Split(TaskTextSeparator);
                    if (parts.Length < 2 || parts[1] == "")
                    {
                        Console.WriteLine("Формат: add \"текст задачи\"");
                        continue;
                    }

                                        if (todoCount == todos.Length)
                    {
                        todos = ExpandArray(todos);
                    }

                    todos[todoCount] = parts[1];
                    todoCount++;
                    Console.WriteLine("Задача добавлена.");
                    continue;
                }

                if (command == CommandView)
                {
                    for (int i = 0; i < todos.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(todos[i]))
                        {
                            Console.WriteLine($"{i + 1}. {todos[i]}");
                        }
                    }
                    continue;
                }

                Console.WriteLine("Неизвестная команда.");
            }
        }
	private static T[] ExpandArray<T>(T[] array)
        {
            T[] expandedArray = new T[array.Length * CapacityGrowthFactor];
            for (int i = 0; i < array.Length; i++)
            {
                expandedArray[i] = array[i];
            }
                return expandedArray;
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("help - вывести список команд");
            Console.WriteLine("profile - показать данные пользователя");
            Console.WriteLine("add \"текст задачи\" - добавить задачу");
            Console.WriteLine("view - показать все задачи");
            Console.WriteLine("exit - завершить программу");
        }
    }
}