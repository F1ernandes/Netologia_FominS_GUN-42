using System;
using System.Threading;
using System.Linq.Expressions;


namespace Lessons
{
    /*Changes For Test Commit*/

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number");
            if (!Int32.TryParse(Console.ReadLine(), out var a))
            {
                Console.WriteLine("Not a number!");
                return;
            }
            Console.WriteLine("Enter second number");
            if (!Int32.TryParse(Console.ReadLine(), out var b))
            {
                Console.WriteLine("Not a number!");
                return;
            }
            Console.WriteLine("Enter operator &, |, ^");
            var s = Console.ReadLine();
            if (s.Length == 0 || s.Length > 1)
            {
                Console.WriteLine("Wrong Operator!");
                return;
            }
            else if ((s[0] != '&') && (s[0] != '|') && (s[0] != '^'))
            {
                Console.WriteLine("Program works only with & | ^!");
                return;
            }
            
            int result = 0;
            switch (s[0])
            {
                //Побитовое И (AND)
                case '&': result = a & b; break;
                case '|': result = a | b; break;
                case '^': result = a ^ b; break;
                //case '+': Console.WriteLine("Result of {0} + {1} = {2}", a, b, a + b); break;
                //case '-': Console.WriteLine("Result of {0} - {1} = {2}", a, b, a - b); break;
                //case '*': Console.WriteLine("Result of {0} * {1} = {2}", a, b, a * b); break;
                //case '/': Console.WriteLine("Result of {0} / {1} = {2}", a, b, a / b); break;
                //case '%': Console.WriteLine("Result of {0} % {1} = {2}", a, b, a % b); break;
                default:  Console.WriteLine("Wrong Operand"); break;
            }
            
            Console.WriteLine("Result o operation {0} {2} {1}", a, b, s[0]);
            Console.WriteLine($"Десятичное: {result}");
            Console.WriteLine($"Двоичное:   {Convert.ToString(result, 2)}");
            Console.WriteLine($"Шестнадцатеричное: {Convert.ToString(result, 16)}");
            Console.ReadLine();

        }


    }
}