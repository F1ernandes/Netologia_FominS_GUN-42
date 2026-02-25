using System;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            double USD_to_RUB = 76.55;
            double USD;
            Console.WriteLine("Введите сумму в долларах");
            USD = double.Parse(Console.ReadLine());
            Console.WriteLine("В рублях: " + USD*USD_to_RUB);
        }
    }
}