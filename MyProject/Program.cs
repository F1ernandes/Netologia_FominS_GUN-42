using System;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstValue, secondValue, thirdValue;
            Console.WriteLine("Введите число №1");
            firstValue = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите число №2");
            secondValue = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите число №3");
            thirdValue = double.Parse(Console.ReadLine());


            double resultSum = (firstValue + secondValue + thirdValue);
            double resultComposition = (firstValue * secondValue * thirdValue);

            Console.WriteLine("Сумма = " + resultSum + ", Произведение = " + resultComposition);




            /*string aStr, bStr, cStr;
            double convertToDollars = 76.91;
            int a, b, c;
            Console.WriteLine("Введите число №1");
            aStr = Console.ReadLine();
            Console.WriteLine("Введите число №2");
            bStr = Console.ReadLine();
            Console.WriteLine("Введите число №3");
            cStr = Console.ReadLine();

            a = Convert.ToInt32(aStr);
            b = Convert.ToInt32(bStr);
            c = Convert.ToInt32(cStr);

            int result = (a + b + c) / 3;
            Console.WriteLine("Среднее арефмитическое: " + result);
            result = a * b * c;
            Console.WriteLine("Произведение: " + result);

            double convertResult;
            convertResult = result * convertToDollars;
            Console.WriteLine("В долларах: " + convertResult);
            */
        }
    }
}