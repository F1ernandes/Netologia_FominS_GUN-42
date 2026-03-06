using System;
using System.Threading;
using System.Linq.Expressions;


namespace Lessons
{

    class Program
    {
        static int IndexOf(int[] array, int value)
        {
            for(int i  = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {  return i; }
            }
            return -1;
        }
        static int[] GetRandomArray(uint length, int minValue, int maxValue)
        {
            int[] myArray = new int[length];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                myArray[i] = random.Next(minValue, maxValue);
            }
            return myArray;
        }
        static void Coco( int[] arr)
        {
            arr[0] = 10; 
        }
        static void Main(string[] args)
        {
            int[] myArray = {1,2,3 };//GetRandomArray (100, -100, 100);
            Coco(myArray);
            Console.WriteLine(myArray[0]);
            //Console.WriteLine(IndexOf(myArray, -5));
        }

    }
}