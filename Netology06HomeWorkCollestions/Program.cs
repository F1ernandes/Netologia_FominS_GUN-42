using System;
using System.Threading;
using System.Linq.Expressions;


namespace Netology06HomeWorkCollestions
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Choose the task (1/2/3)");
            int taskNum;

            if (!int.TryParse(Console.ReadLine(), out taskNum)) { Console.WriteLine("You enter wrong char!"); }
            else 
            {
                switch (taskNum)
                {
                    case 1:
                        StringList.TaskLoop();
                        break;
                    case 2:
                        StudentsGrade.TaskLoop();
                        break;
                    case 3:
                        TrackList.TaskLoop();
                        break;
                    default:
                        Console.WriteLine("You chosen task number " + taskNum +" but we haven't this task"); break;
                }
            }
            

            



        }
        //For All Functions
        public static bool CheckForExit()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("See you later!");
                    return true; // пора выходить
                }
            }
            return false; // продолжаем работу
        }

    }
}