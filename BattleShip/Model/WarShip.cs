
using BattleShip.Interfaces;

namespace BattleShip.Model
{
    public  class WarShip:Ship, IFire
    {
        public int valueOfDamage { get; set; }
        public WarShip() { }
        public WarShip(int _valueOfDamage, int _id, int _speed, int _lenght, int _range) : base(_id, _speed, _lenght, _range)
        {
            valueOfDamage = _valueOfDamage;
        }
        public void Fire() { }
    }
    
}
