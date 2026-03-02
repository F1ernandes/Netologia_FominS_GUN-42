using System;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Classes
{
    class Unit
    {
        private readonly string name;
        private float _health;
        private readonly int _damage;
        private readonly float _armor;

        public string Name { get { return name; } }
        public float Health { get { return _health; } } 
        public int Damage { get { return _damage; } }
        public float Armor { get { return _armor; } }    
        public Unit() : this("Unknown Unit") { }
        public Unit(string unitName)
        {
            name = unitName;
            _damage = 10;
            _armor = 0.6f;
            _health = 100;

        }
        public float GetRealHealth()
        {
            return _health *(1f + _armor);
        }
        public bool SetDamage(float value)
        { 
            _health = value *_armor;
            return _health <= 0f;
        }
    }
    class Weapon
    {
        public string Name { get; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }
        public float Durability{   get; }
        public Weapon(string weaponName)
        {
            Name = weaponName;
            Durability = 1f;
        }
        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
            SetDamageParams(minDamage, maxDamage);
        }
        public void SetDamageParams(int minDamage, int maxDamage)
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

            
            if (maxDamage <= 1){    MaxDamage = 10; }
            else{                   MaxDamage = maxDamage;  }
        }

        
        public int GetDamage()
        {
            return (MinDamage + MaxDamage) / 2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var Bob = new Unit("Bob");
            Console.WriteLine(Bob.Name);
            var Unk = new Unit();
            Console.WriteLine(Unk.Name);
            var Crossbow = new Weapon("Crossbow", -2, 15);
            Console.WriteLine(Crossbow.MinDamage);
        }

    }
}