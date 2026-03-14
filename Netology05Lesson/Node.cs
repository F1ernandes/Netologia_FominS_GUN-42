using System;
using System.Collections.Generic;
using System.Text;

namespace Netology05Lesson
{
    internal class Node
    {
        public int Value;
        public Node Next;
        public Node():this(0) {}
        public Node(int val) { Value = val; }
    }
}
