using System;
using System.Threading;
using System.Linq.Expressions;


namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите число 1");
            if (!Int32.TryParse(Console.ReadLine(), out var a))
            {
                Console.WriteLine("Not a number!");
                return;
            }
            Console.WriteLine("введите число 2");
            if (!Int32.TryParse(Console.ReadLine(), out var b))
            {
                Console.WriteLine("Not a number!");
                return;
            }
            Console.WriteLine("введите оператор");
            var s = Console.ReadLine();
            if (s.Length == 0 || s.Length > 1)
            {
                Console.WriteLine("Wrong Operator!");
                return;
            }
            //var a = Int32.TryParse(Console.ReadLine());
            //var b = Int32.Parse(Console.ReadLine());

            switch (s[0])
            {
                case '+':
                    Console.WriteLine("Result of {0} + {1} = {2}", a, b, a + b);
                    break;
                case '-':
                    Console.WriteLine("Result of {0} - {1} = {2}", a, b, a - b);
                    break;
                case '*':
                    Console.WriteLine("Result of {0} * {1} = {2}", a, b, a * b);
                    break;
                case '/':
                    Console.WriteLine("Result of {0} / {1} = {2}", a, b, a / b);
                    break;
                case '%':
                    Console.WriteLine("Result of {0} % {1} = {2}", a, b, a % b);
                    break;
                default:
                    Console.WriteLine("Wrong Operand");
                    break;
            }
            Console.ReadLine();

        }


    }
}