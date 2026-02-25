using System;
using System.Threading;
using System.Linq.Expressions;


namespace Lessons
{

    class Program
    {
        static void Main(string[] args)
        {
            int limit = int.Parse(Console.ReadLine());
            for (int i = 0; i < limit; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}