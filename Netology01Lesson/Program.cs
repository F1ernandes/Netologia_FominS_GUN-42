using System;
using System.Threading;
using System.Linq.Expressions;


namespace Lessons
{

    class Program
    {
        static void Main(string[] args)
        {
            //var a = Int32.Parse(Console.ReadLine());
            //var b = Int32.Parse(Console.ReadLine());
            //Console.WriteLine("Result of {0} + {1} = {2}", a, b, a + b);
            //Console.WriteLine("Result of {0} - {1} = {2}", a, b, a - b);
            //Console.WriteLine("Result of {0} * {1} = {2}", a, b, a * b);
            //Console.WriteLine("Result of {0} / {1} = {2}", a, b, a / b);
            //Console.WriteLine("Result of {0} % {1} = {2}", a, b, a % b);
            int x = 0b1100;
            int y = 0xFF;
            Console.WriteLine("Двоичная x = " + Convert.ToString(x,2));
            Console.WriteLine("Десятичная x = " + x);
            Console.WriteLine("Шестнадцатиричная y = " + Convert.ToString(y,16));
            Console.WriteLine("Десятична y = " + y);

        }


    }
}