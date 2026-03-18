using System;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Netology07HomeWorkStringsAndChars
{
    class Program
    {
        //Task1
        //Напишите метод, который принимает две строки и возвращает конкатенацию этих строк.
        public static string ConcatenateStrings(string str1, string str2)
        {
            string result;
            //result = str1 + str2; //method 1
            //result = $"{str1} {str2}"; //method 2
            //result = string.Concat(str1, str2); //method 3
            //Metod 4
            /*
            var sb = new StringBuilder();
            sb.Append(str1);
            sb.Append(str2);
            result = sb.ToString();
            */
            result = string.Format("{0} {1}", str1, str2);
            return result;
        }
        //Task 2
        /*
         * Напишите метод GreetUser, который получает имя (string) и возраст (int), 
         * а затем использует строку с форматом $ для возврата сообщения вида “Hello, [Name]! You are [Age] years old.” . 
         * Второе предложение должно идти с новой строки (используйте escape последовательность)
         */
        public static string GreetUser(string name, int age)
        {
            string result;
            result = $"Hello, {name}! \nYou are {age} years old.";
            return result;
        }
        //Task 3
        /*
         * Закончите метод, который получает строку и возвращает новую строку с информацией: 
         * Количество символов в строке 
         * Строку в верхнем регистре 
         * Строку в нижнем регистре 
         * Используйте методы класса string
         */

        public static string getStringForThirdTask(string getStr)
        {
            var sb = new StringBuilder();
            sb.Append("Количество символов: ");
            sb.Append(getStr.Length);
            sb.Append("\n");
            sb.Append(getStr.ToUpper());
            sb.Append("\n");
            sb.Append(getStr.ToLower());
            
            string result = sb.ToString();
            return result;
            
        }
        //Task 4
        /*
         * Напишите метод, который возвращает первые 5 символов строки. Используйте метод Substring
         */
        public static string getFirstFiveSymbols(string getStr)
        {
            int five = 5;
            if (getStr.Length < 5) { five = getStr.Length; }
            return getStr.Substring(0,five);
        }
        //Task 5
        /*
         * Напишите метод, принимающий на вход массив из строк и возвращающий экземпляр StringBuilder. 
         * Вам нужно создать экземпляр StringBuilder, который объединяет все элементы входного массива в одно предложение, 
         * каждый элемент - через пробел. 
         * Какой метод StringBuilder вы будете использовать: Append или AppendLine?
         */
        public static StringBuilder getSentence(string[] strArray)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < strArray.Length; i++)
            {
                sb.Append(strArray[i]);
                if (i < strArray.Length - 1){ sb.Append(' '); }
            }
            return sb;
        }
        //Task 6
        /*
         * Напишите метод, который принимает строку и два слова: одно для поиска и другое для замены. 
         * Затем замените все вхождения первого слова на второе слово в введенной строке и верните результат. 
         */
        public static string ReplaceWords(string inputString, string wordToReplace, string replacementWord) 
        {
            string result;
            string withACapitalLetterStr1 = char.ToUpper(wordToReplace[0]) + wordToReplace.Substring(1);
            string withACapitalLetterStr2 = char.ToUpper(replacementWord[0]) + replacementWord.Substring(1);
            result = inputString.Replace(wordToReplace, replacementWord);
            result = result.Replace(withACapitalLetterStr1, withACapitalLetterStr2);
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Task1");
            Console.WriteLine(ConcatenateStrings("Hello ","World!"));
            
            Console.Write("\n\n\nTask2\n");
            Console.WriteLine(GreetUser("St. Patrick", 1637));

            Console.Write("\n\n\nTask3\n");
            Console.WriteLine(getStringForThirdTask("Hello World"));

            Console.Write("\n\n\nTask4\n");
            Console.WriteLine(getFirstFiveSymbols("Hello World"));

            Console.Write("\n\n\nTask5\n");
            var sb = new StringBuilder();
            string[] strArray = new string[] {"One", "Two", "Three", "Four", "Five"};
            sb = getSentence(strArray);
            Console.WriteLine(sb.ToString());

            Console.Write("\n\n\nTask6\n");
            string myExpresion = "The game is not worth the candle. Burn the candle at both ends. Can't hold a candle to. Better to light a candle than curse the darkness. Candle in the wind";
            string resultTaskSixth = ReplaceWords(myExpresion, "candle", "lamp");
            Console.WriteLine(resultTaskSixth);
            //Assert.AreEqual("lamp", resultTaskSixth);
        }
    }
}