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

	private const string StatusDone = "сделано";
        private const string StatusNotDone = "не сделано";

        private static string[] todos = new string[InitialTodosCapacity];
        private static bool[] statuses = new bool[InitialTodosCapacity];
        private static DateTime[] dates = new DateTime[InitialTodosCapacity];
        private static int todoCount = 0;

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
                    ShowProfile(firstName, lastName, birthYear);
                    continue;
                }

                if (command.StartsWith(CommandAdd + " "))
                {
                    AddTodo(command);
                    continue;
                }

                if (command == CommandView)
                {
                    ShowTodos();
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

        private static void ExpandAllArrays()
        {
            todos = ExpandArray(todos);
            statuses = ExpandArray(statuses);
            dates = ExpandArray(dates);
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

        private static void ShowProfile(string firstName, string lastName, int birthYear)
        {
            Console.WriteLine($"{firstName} {lastName}, {birthYear}");
        }

        private static void AddTodo(string command)
        {
            string[] parts = command.Split(TaskTextSeparator);
            if (parts.Length < 2 || parts[1] == "")
            {
                Console.WriteLine("Формат: add \"текст задачи\"");
                return;
            }

            if (todoCount == todos.Length)
            {
                ExpandAllArrays();
            }

            todos[todoCount] = parts[1];
            statuses[todoCount] = false;
            dates[todoCount] = DateTime.Now;
            todoCount++;
            Console.WriteLine("Задача добавлена.");
        }

        private static void ShowTodos()
        {
            for (int i = 0; i < todos.Length; i++)
            {
                if (!string.IsNullOrEmpty(todos[i]))
                {
                    string statusText = statuses[i] ? StatusDone : StatusNotDone;
                    Console.WriteLine($"{i + 1} {todos[i]} {statusText} {dates[i]}");
                }
            }
        }
    }
}