
namespace Lessons
{

    class Program
    {
        static void Main(string[] args)
        {
            int fanSpeen = 0;
            bool isHighTemperature = false;
            bool hasNoColling = fanSpeen <=0;

            if (isHighTemperature && hasNoColling)
            {
                Console.WriteLine("Угроза повреждения процессора");
            }
            else if (hasNoColling)
            {
                Console.WriteLine("всё ок, но лучше охладить");
            }
            else 
            {
                Console.WriteLine("Всё ок");
            }
            //Console.ReadLine();
        }
    }
}