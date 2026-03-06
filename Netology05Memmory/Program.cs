using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Classes
{
    struct Interval
    {
        public float Min { get; }
        public float Max { get; }
        public float Get()
        {
            Random random = new Random();
            return (float)(random.NextDouble()*(Max - Min) + Min); 
        }
        public Interval(int minValue, int maxValue)
        {
            
            if (minValue < 0) { Console.WriteLine("некорректное минимальное значения диапазона " + minValue); minValue = 0 ; }
            if (maxValue < 0) { Console.WriteLine("некорректные максимальное значения диапазона " + maxValue); maxValue = 0; }
            if (minValue > maxValue) 
            { 
                Console.WriteLine("некорректные значения диапазона, min > max"); 
                /*int tempValue = maxValue;   maxValue = minValue;  minValue = tempValue;*/
                //Использую кортеж
                (minValue, maxValue) = (maxValue, minValue);
            }
            if (minValue == maxValue) { 
                Console.WriteLine("некорректные значения диапазона, min = max, max увеличен на 10"); 
                maxValue += 10;
            }
            Min = minValue; Max = maxValue; 

        }
    }
    class Unit
    {
        private readonly string _name;
        private float _health;
        private readonly Interval _damage;
        private readonly float _armor;

        public string Name => _name; //{ get { return name; } }
        public float Health => _health; //{ get { return _health; } }
        public Interval Damage => _damage; //{ get { return _damage; } }
        public float Armor => _armor; //{ get { return _armor; } }
        public Unit() : this("Unknown Unit") { }
        public Unit(string name) : this("Unknown Unit", 0, 10) { }
        public Unit(string unitName, int minDamage, int maxDamage)
        {
            _name = unitName;
            _damage = new Interval (minDamage, maxDamage);
            _armor = 0.6f;
            _health = 100;

        }
        public float GetRealHealth()
        {
            return _health * (1f + _armor);
        }
        public bool SetDamage(float value)
        {
            _health = value * _armor;
            return _health <= 0f;
        }
    }
    class Weapon
    {
        public string Name { get; }
        public Interval Damage { get; private set;}
     /* public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }
     */
        public float Durability { get; }
        public Weapon(string weaponName)
        {
            Name = weaponName;
            Durability = 1f;
            Damage = new Interval(1, 10);
        }
        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
            Damage = new Interval(minDamage, maxDamage);
            // SetDamageParams(minDamage, maxDamage);
        }
       /* public void SetDamageParams(int minDamage, int maxDamage)
        {
            if (minDamage > maxDamage)
            {
                Console.WriteLine($"Incorrect input data for {Name}: minDamage more then maxDamage. I changed them.");
                int temp = minDamage;
                minDamage = maxDamage;
                maxDamage = temp;
            }


            if (minDamage < 1)
            {
                Console.WriteLine($"I set MinDamage for {Name} as 1");
                MinDamage = 1;
            }
            else
            {
                MinDamage = minDamage;
            }


            if (maxDamage <= 1) { MaxDamage = 10; }
            else { MaxDamage = maxDamage; }
        }*/


        public int GetDamage()
        {
            return (int)Damage.Get();
        }
    }
    // Структура Room
    struct Room
    {
        public Unit Unit { get; }
        public Weapon Weapon { get; }

        public Room (Unit unit, Weapon weapon)
        {
            Unit = unit;
            Weapon = weapon;
        }
    }

    public class Dungeon
    {
        private Room[] _rooms;

        public Dungeon()
        {
            _rooms = new Room[]
            {
                new Room(new Unit("Leonardo", 3, 8), new Weapon("Twin Katana", 4, 10)),
                new Room(new Unit("Raphael", 2, 6), new Weapon("Twin Sai", 3, 12)),
                new Room(new Unit("Donatello", 1, 4), new Weapon("Bo Staff", 5, 15)),
                new Room(new Unit("Michelangelo", 2, 7), new Weapon("Nunchucks", 2, 8))
            };
        }

        public void ShowRooms()
        {
            for (int i = 0; i < _rooms.Length; i++)
            {
                var room = _rooms[i];
                Console.WriteLine($"Room {i + 1}:");
                Console.WriteLine($"Unit of room: {room.Unit.Name}, Health: {room.Unit.Health}, Damage: {room.Unit.Damage.Min}-{room.Unit.Damage.Max}");
                //Console.WriteLine($"Weapon of room: {room.Weapon.Name}, Damage: {room.Weapon.Damage.Min}-{room.Weapon.Damage.Max}");
                Console.WriteLine($"Weapon of room: {room.Weapon.Name}, Damage: {room.Weapon.Damage.Get()}");
                Console.WriteLine("---");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*var Bob = new Unit("Bob");
            Console.WriteLine(Bob.Name);
            var Unk = new Unit();
            Console.WriteLine(Unk.Name);
            var Crossbow = new Weapon("Crossbow", -2, 15);
            Console.WriteLine(Crossbow.MinDamage);*/
            Dungeon dungeon = new Dungeon();
            dungeon.ShowRooms();
        }

    }
}