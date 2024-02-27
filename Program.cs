using System.Threading.Tasks;

namespace Todo_list
{
    internal class Program
    {
        static int initialLimit = 3;
        static string[] todoList = new string[initialLimit];
        static int todoCount = 0;
        static void Main(string[] args)
        {
            // welcome user
            // View list of choices
            // View all tasks
            // Adding todo
            // mark task complete
            // remove task
            // exit
            
            string userChoice;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\tWellcome TO Trakker");
            Console.ResetColor();

            do
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor= ConsoleColor.White;
                Console.WriteLine("(1) View all Goals \n(2) Add Goal \n(3) Complete Goal \n(4) Delete Goal  \n(5) Exit");
                Console.ResetColor();
                userChoice = Console.ReadLine();
                
                switch (userChoice)
                {
                    case "1":
                    {
                            // view all tasks
                            ShowAllTodoList() ;
                            break;
                    }
                    case "2":
                    {
                            AddTask();
                            break;
                    }
                    case "3":
                    {
                            MarkComplete();
                            break;
                    }
                    case "4":
                    {
                            DeleteTask();
                            break;
                    }
                    case "5":
                    {
                            //Environment.Exit(0);
                            break;
                    }

                    default:
                        Console.Beep();
                        Console.Beep();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choise!!");
                        Console.ResetColor();
                        break;
                }
            }
            while (userChoice != "5");
        }
        private static bool TodoListIsEmpty()
        {
            if (todoCount == 0)
            {
                Console.WriteLine("Goals List Is Empty");
                return true;
            }
            return false;
        }
        private static bool TodayListIsFull() 
        {
            if (todoCount == todoList.Length)
            {
                Console.WriteLine("Goals List Is Full");
                return true;
            }
                return false;
        }
        private static void ShowAllTodoList()
        {
            //foreach (var task in todos)
            //    if (task != null)
            //        Console.WriteLine(task);
            if(!TodoListIsEmpty())
            { 
                Console.WriteLine("Goals List: ");
                for (int i = 0; i < todoCount; i++)
                {
                    Console.WriteLine($"{i + 1}. {todoList[i]}");
                }
            }

            
        }
        private static void AddTask()
        {
            Console.WriteLine("Enter your next goal: ");
            string goal = Console.ReadLine();
            if(todoCount <  todoList.Length)
            {
                todoList[todoCount] = goal;
                Console.WriteLine("Goal Added");
                todoCount++;
            }
            else
            {
                TodayListIsFull();
            }
        }
        private static void MarkComplete()
        {
            try
            {
                ShowAllTodoList();
                Console.Write("Enter goal number you Done it: ");
                int taskId = Convert.ToInt32(Console.ReadLine()) - 1;
                if (taskId <= todoCount)
                {
                    if (!TodoListIsEmpty())
                    {
                        todoList[taskId] = todoList[taskId] + " ---COMPLETED";
                        Console.WriteLine(todoList[taskId]);
                    }
                }
                if (taskId > todoCount)
                    Console.WriteLine("That Goal is not yours!");
            }catch (Exception ex)
            {
                Console.WriteLine("Invalid Number please enter Goal number");
            }
        }
        private static void DeleteTask()
        {
            try
            {
                ShowAllTodoList();
                Console.Write("Enter goal number you want to remove: ");
                int taskId = Convert.ToInt32(Console.ReadLine()) - 1;
                if (taskId <= todoCount)
                {
                    if (!TodoListIsEmpty())
                    {
                        for (int i = taskId; i < initialLimit-1; i++)
                        {
                            todoList[i] = todoList[i + 1];
                        }
                        Console.WriteLine("REMOVED");
                        todoCount--;
                    }
                }
                if (taskId > todoCount)
                    Console.WriteLine("That Goal is not yours!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Number please enter Goal number");
            }
        }
    }
}
