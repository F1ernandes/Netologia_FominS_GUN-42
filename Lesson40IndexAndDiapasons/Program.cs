using System;
using System.Threading;
using System.Linq.Expressions;


namespace Lessons
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = { 2, 10, 5, 6, 77, 89 };
          
            //Последний элемент с конца
            Console.WriteLine(myArray[^1]);
            //Index myIndex = ^2
            //Range myRange = 1..4 // new Range (1,4)

            //Копирование диапазона Массива
            int[] myArray2 = myArray [1..4];
            Console.WriteLine("В новом массиве теперь: ");    
            for (int i = 0; i < myArray2.Length; i++)
            {
                Console.WriteLine(i + " => " + myArray2[i]);
            }
            myArray2 = myArray[2..];
            Console.WriteLine("В новом массиве теперь: ");
            for (int i = 0; i < myArray2.Length; i++)
            {
                Console.WriteLine(i + " => " + myArray2[i]);
            }

            myArray2 = myArray[..5];
            Console.WriteLine("В новом массиве теперь: ");
            for (int i = 0; i < myArray2.Length; i++)
            {
                Console.WriteLine(i + " => " + myArray2[i]);
            }

        }


    }
}