
namespace Lessons
{

    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            switch (a)
            {
                case 1: Console.WriteLine("вы ввели число 1");
                    break;
                default: Console.WriteLine("вы ввели другое число");  break;
            }
        }
    }
}