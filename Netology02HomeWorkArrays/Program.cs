using System;
using System.Linq.Expressions;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
//Task A
            /*Fibonacchi Numbers - Task 01*/
            Console.WriteLine("Fibonacci numbers");
            int[] fibonacchiNumbers = new int[15];

            for (int i = 0; i < fibonacchiNumbers.Length; i++)
            {
                switch (i)
                {
                    case 0: case 1: fibonacchiNumbers[i] = i; break;
                    default: fibonacchiNumbers[i] = fibonacchiNumbers[i - 1] + fibonacchiNumbers[i - 2]; break;
                }
            }

            PrintIntArrayVariables(fibonacchiNumbers);


            /*Month of year - Task 02*/
            DoConsoleSplit(2);
            bool isStartlist = true;
            string[] Year = new string[12] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            Console.Write("One year contains ");
            foreach (string MonthName in Year)
            {
                if (!isStartlist) { Console.Write(", "); }
                Console.Write(MonthName);
                isStartlist = false;
            }
            /*Matrix - Task 03*/
            DoConsoleSplit(2);
            Console.WriteLine("Mathematical degree:");
            int[,] taskMatix = new int[4, 4] { {2, 3, 4, 5}, { 2, 3, 4, 5 }, { 2, 3, 4, 5 }, { 2, 3, 4, 5 } };
            int tempValue, resultValue;
            for (int i = 0; i < taskMatix.GetLength(0); i++)
            {
                for(int j = 0; j<taskMatix.GetLength(1); j++)
                {
                    tempValue = taskMatix[i,j];
                    resultValue = tempValue;
                    for (int k =0; k< i; k++)
                    {
                        resultValue = resultValue * tempValue;
                    }
                    Console.Write(resultValue);
                    if (j != taskMatix.GetLength(1) - 1 ) { Console.Write(", "); }
                }
                Console.Write("\n");

            }


            /*Jagged Array - Task 04*/
            DoConsoleSplit(2);
            Console.WriteLine("Jagged Array:");
            double[][] jaggedArray = new double[3][];
            jaggedArray[0] = new double[] { 1, 2, 3, 4, 5 };
            jaggedArray[1] = new double[] { Math.E, Math.PI };
            jaggedArray[2] = new double[]
            {
                Math.Log10(1),   // = 0
                Math.Log10(10),  // = 1
                Math.Log10(100), // = 2
                Math.Log10(1000) // = 3
            };


            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
            // Task B
            /*Actions with arrays - Task 05*/
            DoConsoleSplit(2);
            int[] array = { 1, 2, 3, 4, 5 }; 
            int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };
            
            
            Console.WriteLine("First Array:");
            PrintIntArrayVariables(array);
            DoConsoleSplit();
            Console.WriteLine("Second Array:");
            PrintIntArrayVariables(array2);
            DoConsoleSplit();
            Console.WriteLine("I'm copy first array to second, but only the first three elements:");
            Array.Copy(array, 0, array2, 0, 3);

            PrintIntArrayVariables(array2);

            /*Double size for first array*/
            DoConsoleSplit(2);
            Console.WriteLine("After double size of first array:");
            Array.Resize(ref array, array.Length * 2);
            isStartlist = true;
            foreach (int checkArrayValue in array)
            {
                if (!isStartlist) { Console.Write(", "); }
                Console.Write(checkArrayValue);
                isStartlist = false;
            }

        }
        static void PrintIntArrayVariables(Array getArray)
        {
            bool isStartlist = true;
            foreach (int val in getArray)
            {
                if (!isStartlist) { Console.Write(", "); }
                Console.Write(val);
                isStartlist = false;
            }
            Console.Write("\n");
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