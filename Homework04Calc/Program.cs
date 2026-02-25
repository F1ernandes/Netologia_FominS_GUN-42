using System;
using System.Threading;
using System.Linq.Expressions;

/*
    float f = 3.14f;        // 7 цифр точности (~6-9 цифр)
    double d = 3.1415926535; // 15-16 цифр точности
    decimal dec = 3.14159265358979323846m; // 28-29 цифр точности (для финансов)
 */

namespace Lessons
{

    class Program
    {
        static void Main(string[] args)
        {
            bool Esc = false;
            while (!Esc)
            {
                Console.Clear();
                double firstValue = 0, secondValue = 0, calcResult = 0;
                string action;

                try
                {
                    Console.WriteLine("Введите число 1");
                    firstValue = double.Parse(Console.ReadLine());

                    Console.WriteLine("Введите число 2");
                    secondValue = double.Parse(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка операции");
                }

                Console.WriteLine("Выберите операцию: + - * /");
                action = Console.ReadLine();


                switch (action)
                {
                    case "+": calcResult = firstValue + secondValue; break;
                    case "-": calcResult = firstValue - secondValue; break;
                    case "*": calcResult = firstValue * secondValue; break;
                    case "/":
                        if (secondValue == 0) { calcResult = 0; break; }
                        calcResult = firstValue / secondValue; break;
                    default: Console.WriteLine("Ошибка операции"); break;
                }


                Console.WriteLine("Результат: " + calcResult);
                Console.WriteLine("Нажмите любую клавишу. ESC - для выхода");
                Console.ReadLine();
                if (Console.ReadKey().Key == ConsoleKey.Escape) { Esc = true; }

            }
        }
    }
}