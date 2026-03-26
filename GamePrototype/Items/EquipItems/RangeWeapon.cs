using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public sealed class RangeWeapon : Weapon
    {
        public RangeWeapon(uint damage, uint durability, string name) : base(damage, durability, name) { }

        //public uint Damage { get; }

        public override EquipSlot Slot => EquipSlot.RangeWeapon;
    }
}
