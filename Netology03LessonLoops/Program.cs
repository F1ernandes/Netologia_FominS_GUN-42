using System;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task A
            /*Fibonacchi Numbers - Task 01 
              
            С помощью цикла for (или while) выведите первые 10 чисел Фиббоначи (см. Задание из 3 урока)
            
             */

            int[] fibonacchiNumbers = new int[28];
            fibonacchiNumbers[0] = 0;
            fibonacchiNumbers[0] = 1;
            for (int i = 2; i < fibonacchiNumbers.Length; i++)
            {
                fibonacchiNumbers[i] = fibonacchiNumbers[i - 1] + fibonacchiNumbers[i - 2];
            }

            Console.WriteLine("First ten of fibonacci numbers. Show by for loop: ");
            for (int i = 0; i < 11 && i < fibonacchiNumbers.Length; i++)
            {
                Console.Write(fibonacchiNumbers[i] + " ");
            }
            DoConsoleSplit(2);
            Console.WriteLine("First ten of fibonacci numbers. Show by while loop: ");

            int fibonacchiIndex = 0;
            while (fibonacchiIndex < 11 && fibonacchiIndex < fibonacchiNumbers.Length)
            {
                Console.Write(fibonacchiNumbers[fibonacchiIndex] + " ");
                fibonacchiIndex++;
            }
            //Task 02
            //Используя цикл for, выведите все чётные числа от 2 до 20
            DoConsoleSplit(2);
            Console.WriteLine("Even Fibonacci numbers between 2 and 20. Show by for loop: ");
            for (int i = 0; i < fibonacchiNumbers.Length; i++)
            {
                if (fibonacchiNumbers[i] % 2 == 0 && fibonacchiNumbers[i] <= 20 && fibonacchiNumbers[i] >= 2)
                {
                    Console.Write(fibonacchiNumbers[i] + " ");
                }
            }

            DoConsoleSplit(2);
            Console.WriteLine("Even numbers between 2 and 20. Show by for loop: ");
            for (int i = 2; i < 21; i += 2)
            {
                Console.Write(i + " ");
            }

            //Task 03
            //С помощью вложенных циклов for выведите таблицу умножения от 1 до 5. Каждая строка таблицы должна быть выведена в отдельной строке.
            DoConsoleSplit(2);
            Console.WriteLine("Multiplication Table");
            int[,] multiplicationTable = new int[5, 5];
            //Fill Table
            for (int i = 0; i < multiplicationTable.GetLength(0); i++)
            {
                for (int j = 0; j < multiplicationTable.GetLength(1); j++)
                {
                    if (j == 0) { multiplicationTable[i, j] = i + 1; }
                    else 
                    { 
                        multiplicationTable[i, j] = (i + 1)*(j +1);
                    }
                }
            }

            //Print Table
            for (int i = 0; i < multiplicationTable.GetLength(0); i++)
            {
                for (int j = 0; j < multiplicationTable.GetLength(1); j++)
                {
                    if (multiplicationTable[i, j] < 10) { Console.Write(" "); }
                    Console.Write(multiplicationTable[i, j] + "  ");
                }
                Console.Write("\n\n");
            }

            //Task 04
            //Дана строка string password = “qwerty”;
            //Напишите программу для ввода пароля, которая считывает пользовательский ввод Console.ReadLine.
            //Подсказка: используйте do-while
            string passFromBase = "qwerty";
            string getPassFromUser = "";
            int tryPass = 0;
            do
            {
                Console.WriteLine("Enter the pass");
                getPassFromUser = Console.ReadLine();
                if (getPassFromUser != passFromBase)
                {
                    Console.WriteLine("It's wrong pass. Look to my hint:");
                    for (int i = 0; i<passFromBase.Length; i++)
                    {
                        if (i <= tryPass) { Console.Write(passFromBase[i]); } else { Console.Write("*"); }
                    }
                    Console.Write("\n");
                    tryPass++; 
                }

            } while (getPassFromUser != passFromBase);

        }
        static void DoConsoleSplit(int splits = 1)
        {
            for (var i = 0; i < splits; i++)
            {
                Console.WriteLine("");
            }
        }

    }
}