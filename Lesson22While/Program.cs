using System;
using System.Threading;
using System.Linq.Expressions;

/*
    float f = 3.14f;        // 7 цифр точности (~6-9 цифр)
    double d = 3.1415926535; // 15-16 цифр точности
    decimal dec = 3.14159265358979323846m; // 28-29 цифр точности (для финансов)
 */

namespace Lessons
{

    class Program
    {
        static void Main(string[] args)
        {
            int start = 0, end = 0 ;
            Console.WriteLine("Введите целое число - начало диапазона");
            start = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите целое число - конец диапазона");
            end = int.Parse(Console.ReadLine());


            int count = start;
            int evenNumber = 0, notEvenNumber = 0;
            int evenSum = 0, notEvenSum = 0;
            do
            {
                

                if (count%2 == 1 || count % 2 == -1)
                {
                    notEvenNumber++;
                    notEvenSum += count;
                    //Console.WriteLine(count + " - нечётное");
                }
                else
                {
                    evenNumber++;
                    evenSum += count;
                }
                count++;
            } while (count <= end);
            Console.WriteLine("Чётных: " + evenNumber + ", нечётный: " + notEvenNumber);
            Console.WriteLine("Сумма чётных: " + evenSum + ", сумма нечётных: " + notEvenSum);
            Console.ReadLine();
        }
    }
}