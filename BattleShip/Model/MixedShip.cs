
using BattleShip.Interfaces;


namespace BattleShip.Model
{
    public class MixedShip : Ship, IFire, IHeal
    {
        public int valueOfDamage { get; set; }
        public int valueOfHeal { get; set; }

        public MixedShip() { }
        public MixedShip(int _valueOfDamage, int _valueOfHeal, int _id, int _speed, int _lenght, int _range) : base(_id, _speed, _lenght, _range)
        {
            valueOfDamage = _valueOfDamage;
            valueOfHeal = _valueOfHeal;
        }

        public void Heal() { }
        public void Fire() { }
    }
}
