
namespace Lessons
{

    class Program
    {
        static void Main(string[] args)
        {
            bool isInfected = false;
            if (isInfected)
            {
                Console.WriteLine("Персонаж здоров");
            }
            else
            {
                Console.WriteLine("Персонаж инфицирован");

            }

            Console.WriteLine("Введите числовое значение от 1 до 10");
            int a=0;

            while (a != 11)
            {
                a = int.Parse(Console.ReadLine());
                float b = a % 2;

                if (b == 1)
                {
                    Console.WriteLine("Число нечётное");
                }
                else
                {
                    Console.WriteLine("Ура, чётное");

                }
            }
        }
    }
}