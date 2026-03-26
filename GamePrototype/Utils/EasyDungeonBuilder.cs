using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using System.Drawing;
using GamePrototype.Utils;

namespace GamePrototype.Utils
{
    public class EasyDungeonBuilder : DungeonBuilderBase
    {
        public EasyDungeonBuilder(LevelSize size) : base(size)
        {
        }

        protected override int GetRoomCount()
        {
            return mapSize switch
            {
                LevelSize.S => 3,
                LevelSize.M => 5,
                LevelSize.L => 8,
                LevelSize.XL => 12,
                LevelSize.XXL => 20,
                _ => 5
            };
        }

        protected override float GetEnemyRatio()
        {
            return 0.2f; // 20% врагов
        }
    }
}
