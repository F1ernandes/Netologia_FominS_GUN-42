using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using System.Drawing;

namespace GamePrototype.Utils
{
    public class HardDungeonBuilder : DungeonBuilderBase
    {
        public HardDungeonBuilder(LevelSize size) : base(size)
        {
        }

        protected override int GetRoomCount()
        {
            return mapSize switch
            {
                LevelSize.S => 5,
                LevelSize.M => 8,
                LevelSize.L => 10,
                LevelSize.XL => 14,
                LevelSize.XXL => 25,
                _ => 8
            };
        }

        protected override float GetEnemyRatio()
        {
            return 0.8f; // 80% врагов
        }
    }
}
