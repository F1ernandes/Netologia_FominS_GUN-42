using System;
using System.Threading;
using System.Linq.Expressions;
using Netology09DelegatesAndEvents;

namespace Netology09DelegatesAndEvents
{
    public delegate string ToStringConvert(Test param);
    public delegate float MathFloat(float param1, float param2);
    public class Test
    {
        public event MathFloat FloatCalculator;
        //public Test(string someString) => SomeString = someString;
        //private string SomeString { get; }
        //public string Method(Test param) => param.ToString();
        /*public override string ToString()
        {
            return $"This is the Test class {SomeString}";
        }*/
        public void Calculate(float param1, float param2)
        {
            if (FloatCalculator != null)
            {
                Console.WriteLine(FloatCalculator.Invoke(param1, param2));
            }
        }
    }
    internal class Program
    {
        public static float Sum (float param1, float param2) => param1 + param2;
        public static float Mult(float param1, float param2) => param1 * param2;


        static void Main(string[] args)
        {
            var test = new Test();
            test.FloatCalculator += Sum;
            test.Calculate(10f, 13.3f);

           // var del = new ToStringConvert(test.Method);
           // Console.WriteLine(del(test));
        }
    }
}