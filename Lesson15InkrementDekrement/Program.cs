/*
    Инкремент и декремент. Постфиксный и префиксный.
    Инкремент - увеличение на единицу a = a + 1;
    Декремент - уменьшение на единицу a = a - 1;
 */
namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            a = a++ * a;
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}