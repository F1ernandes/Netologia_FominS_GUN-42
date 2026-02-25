using System;
using System.Threading;
using System.Linq.Expressions;


namespace Lessons
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = { 15, 7, 5, 12, 111, 5, 111, 64, 96 };
            int minResult = myArray.Min();
            int maxResult = myArray.Max();
            int arraySum = myArray.Sum();
            Console.WriteLine("Минимальное число = " + minResult);
            Console.WriteLine("Максимальное число = " + maxResult);
            Console.WriteLine("Сумма = " + arraySum);
            Console.WriteLine("Сумма чётных = " + myArray.Where(i => i % 2 == 0).Sum());
            Console.WriteLine("Сумма нечётных = " + myArray.Where(i => i % 2 != 0).Sum());

            Console.WriteLine("Уникальные элементы массива");
            int[] resultArray = myArray.Distinct().ToArray();
            for (int i = 0; i < resultArray.Length; i++)
            {
                Console.WriteLine(i + " => " + resultArray[i]);
            }

            Console.WriteLine("Сортировка");
            resultArray = myArray.OrderByDescending(i=>i).ToArray();
            for (int i = 0; i < resultArray.Length; i++)
            {
                Console.WriteLine(i + " => " + resultArray[i]);
            }

            Console.WriteLine("Первое число больше ста " + Array.Find(myArray, i => i > 70));
            Console.WriteLine("Последнее число меньше семидясети " + Array.FindLast(myArray, i => i < 70));
            Console.WriteLine("Индекс 111: " + Array.FindIndex(myArray, i=> i== 111));
            Console.WriteLine("Ласт индекс 111: " + Array.FindLastIndex(myArray, i => i == 111));

            /*numbersBefore70*/
            int[] numbersBefore70 = myArray.Where(i=> i>70).ToArray();
            Console.WriteLine("Числа до 70");
            for (int i = 0; i < numbersBefore70.Length; i++)
            {
                Console.WriteLine(i + " => " + numbersBefore70[i]);
            }


            Console.WriteLine("Перевернём массив");
            Array.Reverse(myArray);
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(i + " => " + myArray[i]);
            }

        }


    }
}