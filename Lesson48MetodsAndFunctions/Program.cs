using System;
using System.Threading;
using System.Linq.Expressions;


namespace Lessons
{

    class Program
    {
        static void Main(string[] args)
        {
            char symbol;
            int num = 0;
            Console.WriteLine("Enter one symbol");
            //   symbol = Char.Parse(Console.ReadLine());
            symbol = Console.ReadKey().KeyChar;
            Console.WriteLine("Enter how much will repeat himself");
            num = Int32.Parse(Console.ReadLine());
            PrintSymbolN(num, symbol);

        }
        public static void PrintSymbolN(int N, char symbol)
        {
            Console.Write("\n");
            for (int i = 0; i < N; i++)
            {
                Console.Write(symbol);
            }
            Console.Write("\n");
        }

    }
}