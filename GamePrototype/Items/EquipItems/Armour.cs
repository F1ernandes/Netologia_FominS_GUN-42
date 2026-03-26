using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public class Armour : EquipItem //sealed - запрещает наследование, убрал это, чтобы добавить Helmet
    {
        public Armour(uint defence, uint durability, string name) : base(durability, name) => Defence = defence;

        public uint Defence { get; }

        public override EquipSlot Slot => EquipSlot.Armour;
    }
}
