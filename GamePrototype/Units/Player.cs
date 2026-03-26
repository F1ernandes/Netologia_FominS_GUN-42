using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.ComponentModel;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }
        /*
         *  возвращает урон с учётом оружия.
         */
        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon) 
            {
                return BaseDamage + weapon.Damage;
            }
            return BaseDamage;
        }
        /*
         *  после боя перебирает инвентарь, применяет UseEconomicItem для экономических предметов и удаляет их.
         */
        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;

            for (int i = items.Count-1; i>=0; i--) 
            {
                //Console.WriteLine("Проверяю, что в инвентаре: " + items[i].Name);
                if (items[i] is EconomicItem economicItem) 
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(economicItem);
                }
            }
        }
        /*
         * добавляет предмет, если это EquipItem — пытается экипировать в слот, иначе вызывает базовый метод.
         */
        public override void AddItemToInventory(Item item)
        {

            if (item is EquipItem equipItem)
            {
                // Проверяем, занят ли слот
                if (_equipment.ContainsKey(equipItem.Slot))
                {
                    Console.WriteLine($"Slot {equipItem.Slot} is occupied. Replace? (y/n)");
                    var answer = Console.ReadLine();
                    if (answer?.ToLower() == "y")
                    {
                        // Снимаем старый предмет в инвентарь
                        var oldItem = _equipment[equipItem.Slot];
                        base.AddItemToInventory(oldItem);

                        // Экипируем новый
                        _equipment[equipItem.Slot] = equipItem;
                        Console.WriteLine($"Replaced {oldItem.Name} with {equipItem.Name}");
                        return;
                    }
                    else
                    {
                        // Не заменяем — кладём в инвентарь
                        base.AddItemToInventory(item);
                        return;
                    }
                }

                // Слот свободен — просто экипируем
                if (_equipment.TryAdd(equipItem.Slot, equipItem))
                {
                    Console.WriteLine($"Equipped {equipItem.Name}");
                    return;
                }
            }
            //Console.WriteLine("Добавляю в инвентарь: " + item.Name);
            base.AddItemToInventory(item);
        }
        /*
         * применяет зелье лечения.
         * применяет точильный камень
         */
        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion) 
            {
                Health += healthPotion.HealthRestore;
            }
            if (economicItem is Grindstone grindstone)
            {

                if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon)
                {
                    weapon.Repair(10);
                    Console.WriteLine("Использовал точильный камень");
                }
                else
                {
                    Console.WriteLine("No weapon equipped!");
                }
            }
        }
        /*
         * уменьшает входящий урон с учётом брони.
         */
        protected override uint CalculateAppliedDamage(uint damage)
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour) 
            {
                damage -= (uint)(damage * (armour.Defence / 100f));
            }
            return damage;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"\n{Name}");
            builder.AppendLine($"\nHealth {Health}/{MaxHealth}");
            // Вывод экипировки
            builder.AppendLine("\nEquipment:");
            foreach (var slot in _equipment)
            {
                builder.AppendLine($"[{slot.Key}]: {slot.Value.Name}");
            }
            builder.AppendLine("\nLoot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }
        /*
         * Снижение брони
         */
        protected override void DamageReceiveHandler()
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour) //тут оказывается - он не только проверяет является ли item элементом класса Armour, но и создаёт внутреннюю переменную armour, куда помещает item
            {
                armour.ReduceDurability(1); // уменьшаем прочность на 1 за удар

                if (armour.Durability == 0) // если прочность кончилась
                {
                    _equipment.Remove(EquipSlot.Armour);
                    Console.WriteLine("Your armour is broken!");
                }
            }
        }
        public override void ShowInventory()
        {
            /*  var items = Inventory.Items;

              Console.Write("You have: ");
              for (int i = 0; i < items.Count; i++)
              {
                  Console.Write(items[i].Name+"\t");
              }
              Console.Write("\n");*/
            Console.Write(ToString());
        }
    }
}
