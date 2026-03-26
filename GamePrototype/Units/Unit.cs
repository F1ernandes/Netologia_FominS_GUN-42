using GamePrototype.Items.EconomicItems;

namespace GamePrototype.Units
{
    public abstract class Unit
    {
        private const int INVENTORY_SIZE = 3;
        private uint _health;
        private uint _maxHealth;
        protected uint BaseDamage;
        public Inventory Inventory;
        
        public string Name { get; private set; }
        public uint Health
        {
            get => _health;
            protected set => _health = value;
        }

        public uint MaxHealth => _maxHealth;

        protected Unit(string name, uint health, uint maxHealth, uint baseDamage) 
        {
            Name = name;
            _health = health;
            _maxHealth = maxHealth;
            BaseDamage = baseDamage;
            Inventory = new Inventory(INVENTORY_SIZE);
        }
        /*
         Принимает урон, считает итоговый урон через CalculateAppliedDamage, меняет здоровье
         */
        public void ApplyDamage(uint damage)
        {
            var damageApplied = CalculateAppliedDamage(damage);
            if (_health < damageApplied || (_health - damageApplied) <= 0) 
            {
                _health = 0;
            }
            else 
            {
                _health -= damageApplied;
            }
            
            DamageReceiveHandler();
        }
        /*
         * абстрактный, его обязаны реализовать наследники (логика расчёта урона с учётом брони и прочего)
         */
        protected abstract uint CalculateAppliedDamage(uint damage);
        /*
         *  виртуальный, можно переопределить, если нужно что-то сделать после получения урона (например, уменьшить прочность брони)
         */
        protected virtual void DamageReceiveHandler() { }
        
        public abstract uint GetUnitDamage();

        public abstract void HandleCombatComplete();
        public virtual void ShowInventory() { }

        /*
         * виртуальный, можно переопределить, если нужна особая логика добавления (например, замена экипировки)
         */
        public virtual void AddItemToInventory(Item item) 
        {
            if (!Inventory.TryAdd(item)) 
            {
                Console.WriteLine($"Inventory of {Name} is full");
            }
        }

        public void AddItemsFromUnitToInventory(Unit unit)
        {
            for (int i = 0; i < unit.Inventory.Items.Count; i++) 
            {
                if (!Inventory.TryAdd(unit.Inventory.Items[i])) 
                {
                    //inventory is full
                    return;
                }
            }
        }
    }
}
