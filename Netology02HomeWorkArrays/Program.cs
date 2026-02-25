using System;
using System.Threading;
using System.Linq.Expressions;


namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {

            /*Fibonachi Numbers*/
            int[] fibonachiNumbers = new int[15];

            for (int i = 0; i < fibonachiNumbers.Length; i++)
            {
                switch (i)
                {
                    case 0: case 1: fibonachiNumbers[i] = i; break;
                    default: fibonachiNumbers[i] = fibonachiNumbers[i - 1] + fibonachiNumbers[i - 2]; break;
                }
            }
            int indexKey = 0;
            foreach (int fibonachiNumber in fibonachiNumbers)
            {
                indexKey++; //Numeracija po chelovecheski 
                Console.WriteLine(indexKey + " => " + fibonachiNumber);
            }



        }
    }
}