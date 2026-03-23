using System;
using System.Threading;
using System.Linq.Expressions;
using Netology09DelegatesAndEvents;

namespace Netology09DelegatesAndEvents
{
    public delegate string ToStringConvert(Test param);
    public class Test
    {
        public Test(string someString) => SomeString = someString;
        private string SomeString { get; }
        public string Method(Test param) => param.ToString();
        public override string ToString()
        {
            return $"This is the Test class {SomeString}";
        }
    }
    internal class Program
    {


        static void Main(string[] args)
        {
            var test = new Test("Netology");
            var del = new ToStringConvert(test.Method);
            Console.WriteLine(del(test));
        }
    }
}