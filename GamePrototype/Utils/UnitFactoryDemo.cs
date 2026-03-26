using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public class UnitFactoryDemo
    {
        public static Unit CreatePlayer(string name)
        {
            var player = new Player(name, 30, 30, 6);
            player.AddItemToInventory(new Weapon(10, 15, "Sword")); // Меч //Попадает в экипировку
            player.AddItemToInventory(new Armour(10, 15, "LeatherArmour")); //Броня //Попадает в экипировку
            player.AddItemToInventory(new HealthPotion("Potion")); //Зелье
            player.AddItemToInventory(new Grindstone("Grindstone")); //Точильный камень
            return player;
        }

        public static Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 2);
        public static Item GetRandomLot()
        {
            var random = new Random();
            /*   return random.Next(2) == 0
                   ? new Helmet(20, 15, "Helmet")
                   : new RangeWeapon(10, 100, "RangeWeapon");*/
            //return new Armour(25, 15, "PlateArmour"); //для проверки, как отрабатывает замена экипировки
            switch (random.Next(20))
            {
                case 0: return new Helmet(25, 15, "GoldenHelmet"); break;
                case 1: return new Helmet(10, 15, "LeatherHelmet"); break;
                case 2: return new Helmet(15, 15, "IronHelmet"); break;
                case 3: return new RangeWeapon(10, 40, "ShortBow"); break;
                case 4: return new RangeWeapon(10, 80, "CrossBow"); break;
                case 5: return new RangeWeapon(10, 120, "LongBow"); break;
                case 6: return new Armour(25, 15, "PlateArmour"); break;
                case 7: return new Armour(20, 15, "ChainMail"); break;
                case 8: case 9: case 10: return new Grindstone("Stone"); break;
                default: return new Gold(); break;
            }
        }
    }
}
