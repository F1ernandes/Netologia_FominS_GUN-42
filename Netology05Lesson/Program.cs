using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using Netology05Lesson;

Console.WriteLine("List:");
var list = new List<int>() { 1, 2, 3, 4, 5 };
list.Add(-2);
list.Remove(1);
list.Reverse();
for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i]);
}

Console.WriteLine("------------------");

Console.WriteLine("Nodes:");
var node1 = new Node() { Value = 1 };
var node2 = new Node() { Value = 2 };
var node3 = new Node() { Value = 3 };
node1.Next = node2;
node2.Next = node3;

var next = node1.Next;
while (next != null)
{
    Console.WriteLine(next.Value);
    next = next.Next;
}
Console.WriteLine("------------------");
Console.WriteLine("Stack:");


var stack = new Stack<int>();
stack.Push(1);
stack.Push(2);
stack.Push(3);

while (stack.Count > 0)
{
    Console.WriteLine(stack.Pop());
}
Console.WriteLine("------------------");
Console.WriteLine("Queue");

var queue =  new Queue<float>();
queue.Enqueue(1.5f);
queue.Enqueue(2);   
queue.Enqueue(3);

while (queue.Count > 0)
{

    Console.WriteLine(queue.Dequeue());
}

Console.WriteLine("------------------");
Console.WriteLine("Dictionary");
var dictionary = new Dictionary<int, string>();
dictionary.Add(1, "One");
dictionary.Add(2, "Two");
if (dictionary.TryAdd(1, "Three"))
{
    Console.WriteLine("Sucess");
}
else 
{
    Console.WriteLine("Fail");
}

if (dictionary.TryGetValue(2, out string value))
{
    Console.WriteLine($"{value}");

}

Console.WriteLine(dictionary[1]);
dictionary[1] = "f";
dictionary[2] = "fdd";

foreach (KeyValuePair<int, string> kvp in dictionary)
{
    Console.WriteLine("key = {0} and value = {1}", kvp.Key, kvp.Value);
}


Console.WriteLine("------------------");
Console.WriteLine("HashSet");

var hashSet = new HashSet<int>();
hashSet.Add(0);
hashSet.Add(1);

foreach( var hash in hashSet)
{
    Console.WriteLine(hash);
}

var node7 = new Node(5);
var node8 = new Node(5);
Console.WriteLine("------------------");
Console.WriteLine(node7.GetHashCode());
Console.WriteLine(node8.GetHashCode());