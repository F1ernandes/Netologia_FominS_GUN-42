using System;
using System.Collections.Generic;
using System.Text;

namespace Netology06LessonCollection
{
    internal class TaskUnit
    {
        public int Value;
        public void Redo()
        {
            Console.WriteLine("Redo" + Value);
        }
    }
}
