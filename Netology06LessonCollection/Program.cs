using Netology06LessonCollection;
var army = new List<Unit>()
{
    new Unit() { Name = "Orc"},
    new Unit() { Name = "Elf" }
};

var order1 = new Order() { OrderValue = 1 };
var order2 = new Order() { OrderValue = 2 };

var task1 = new TaskUnit() { Value = 1 };
var task2 = new TaskUnit() { Value = 2 };

foreach (var unit in army)
{
    Console.WriteLine(unit.Name);
    Console.WriteLine("Cansel task, 1 for fireball and 2 for bolt");
    var spell = int.Parse(Console.ReadLine());
    if(unit.Abilities.TryGetValue(spell, out var ability))
    { 
        Console.WriteLine(ability);
    }

}

var orderQueue = new Queue<Order>();

orderQueue.Enqueue(order1);
orderQueue.Enqueue(order2);

var stackTask = new Stack<TaskUnit>();
stackTask.Push(task1);
stackTask.Push(task2);  

while (orderQueue.Count > 0)
{
    Console.WriteLine("Comleted task = " + orderQueue.Dequeue().OrderValue);
}

Console.WriteLine("Cansel task, 1 for yes and 2 for no");
var result = int.Parse(Console.ReadLine());
if (result == 1)
{
    stackTask.Pop().Redo();
}
