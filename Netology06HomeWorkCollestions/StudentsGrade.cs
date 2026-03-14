using System;
using System.Collections.Generic;
using System.Text;

namespace Netology06HomeWorkCollestions
{
    internal class StudentsGrade
    {
        private Dictionary<string, int> educationalJournal = new Dictionary <string,int>()
        {
            {"Vasja",2},
            {"Petja",4},
            {"Sergey",5},

        };
        public static void TaskLoop()
        {
            Console.WriteLine("push ESC - For exit from task");
            Console.WriteLine("push Tab - To look student's grade");
            Console.WriteLine("push F - To to find score of the student");
            Console.WriteLine("push Enter - To add student and his score");
            Console.WriteLine("=================================");

            bool breakLoop = false;
            var students = new StudentsGrade();

            while (!breakLoop)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.F:
                        Console.WriteLine("Enter name of the student");
                        string nameToFind = Console.ReadLine();
                        if (!students.educationalJournal.ContainsKey(nameToFind))
                        {
                            Console.WriteLine("Wrong name. Student not found");
                        }
                        else if (students.educationalJournal.TryGetValue(nameToFind, out int getScore))
                        {
                            Console.WriteLine("Student " + nameToFind +" has " + getScore + " for exam");
                        }
                    break;
                    case ConsoleKey.Escape:
                        breakLoop = true;
                        Console.WriteLine("See you later!");
                    break;
                    case ConsoleKey.Enter:
                        Console.WriteLine("Enter name of the student");
                        string name = Console.ReadLine();
                        byte score;
                        bool isEnableScore = false;

                        Console.WriteLine("Enter his score (range 2..5)");
                        while (!isEnableScore)
                        {
                            if(byte.TryParse(Console.ReadLine(), out score))
                            {
                                if (score >= 2 && score <= 5) 
                                { 
                                    students.educationalJournal.Add(name, score); 
                                    isEnableScore = true; 
                                }
                                else { Console.WriteLine("The score must be in range 2..5"); }
                            }
                            else
                            {
                                Console.WriteLine("You enter wrong score");
                            }
                        }

                        
                        break;
                    case ConsoleKey.Tab:
                        Console.WriteLine("Now list has these lines:");
                        foreach (var lineJournal in students.educationalJournal)
                        {
                            Console.WriteLine("Student: "+ lineJournal.Key+ " Exam score: " + lineJournal.Value);
                        }
                    break;
                }
            }
        }
    }
}
