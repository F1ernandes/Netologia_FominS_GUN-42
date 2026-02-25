using System;
using System.Threading;
using System.Linq.Expressions;


namespace Lessons
{

    class Program
    {
        static void Main(string[] args)
        {
            
            
            for (int i = 0; i < 21; i++)
            {
                for(int j=0; j<40;j++)
                {
                    if (i != 0 && i != 20 && j != 0 && j != 39) { Console.Write(" ");  continue; }
                    Console.Write("#");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
            Console.Write("\n");

            int triangleLength = 5;
            for (int i = 0; i < triangleLength; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("#");
                }
                Console.Write("\n");
            }
            
            for (int i = triangleLength; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("#");
                }
                Console.Write("\n");
            }
        }



    }
}