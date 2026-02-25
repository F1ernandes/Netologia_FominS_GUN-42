using System;
using System.Threading;
using System.Linq.Expressions;


namespace Lessons
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = { 15, 7, 12, 5 };
            //1. Заполнить массив с клавиатуры
            for (int i = 0; i<myArray.Length;i++)
            {
                Console.WriteLine("введите значение ячейки массива с индексом "+i);
                myArray[i] = int.Parse(Console.ReadLine());
            }
            //2. Вывести массив в обратном порядке
            Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");
            Console.WriteLine("Ваш массив в обратном порядке:"); 
            for (int i = myArray.Length-1; i >= 0; i--)
            {
                Console.WriteLine(myArray[i]);
            }
            //3. Сумма чётных чисел
            int sumEvenNumbers = 0;
            int minNumber = myArray[0];
            for (int i = 0; i < myArray.Length; i++)
            {
                int addEvenNumber = myArray[i] % 2 == 0 ? myArray[i] : 0;
                sumEvenNumbers += addEvenNumber;

                minNumber = myArray[i] < minNumber ? myArray[i] : minNumber;
            }
            Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");
            Console.WriteLine("Сумма чётных чисел в массиве = " + sumEvenNumbers);

            //3. Минимальное число
           
            Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");
            Console.WriteLine("Наименьшее число в массиве = " + minNumber);

        }


    }
}