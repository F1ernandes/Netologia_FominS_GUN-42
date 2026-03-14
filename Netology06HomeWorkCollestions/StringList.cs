using System;
using System.Collections.Generic;
using System.Text;

namespace Netology06HomeWorkCollestions
{
    internal class StringList
    {
        private List<string> myLines = new List<string>() {"Line 1", "Line 2", "Line 3", "Line 4", "Line 5" };
        public static void TaskLoop() 
        {
            Console.WriteLine("push ESC - For exit from task");
            Console.WriteLine("push Enter - For input your line");
            Console.WriteLine("push I - For input your line in the middle of list");
            Console.WriteLine("push Tab - For show List");
            Console.WriteLine("push S - For sort List");
            Console.WriteLine("=================================");

            bool breakLoop = false;
            var linesList = new StringList();

            while (!breakLoop)
            {
                var key = Console.ReadKey(true);
                
                switch (key.Key)
                {
                    case ConsoleKey.I:
                    case ConsoleKey.Enter:
                        Console.WriteLine("Input some words and push Enter button");
                        string userLine = Console.ReadLine();
                        Console.WriteLine($"You entered: {userLine}");
                        if (key.Key == ConsoleKey.Enter)
                        {
                            linesList.myLines.Add(userLine);
                        }
                        else if(key.Key == ConsoleKey.I)
                        {
                            int middleNum = linesList.myLines.Count / 2;
                            linesList.myLines.Insert(middleNum, userLine);   
                        }

                    break;
                    case ConsoleKey.Escape:
                        breakLoop = true;
                        Console.WriteLine("See you later!");
                    break;
                    
                    case ConsoleKey.S:
                        Console.WriteLine("List is sorted");
                        linesList.myLines.Sort();
                    break;
                    case ConsoleKey.Tab:
                        Console.WriteLine("Now list has these lines:");
                        foreach (var line in linesList.myLines)
                        {
                            Console.WriteLine(line); 
                        }
                    break;
                }       
            }

        }
    }
}
