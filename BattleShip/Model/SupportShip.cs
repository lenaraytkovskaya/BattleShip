
using BattleShip.Interfaces;

namespace BattleShip.Model
{
    public  class SupportShip:Ship, IHeal
    {
        public int valueOfHeal { get; set; }
        public SupportShip() { }
        public SupportShip(int _valueOfHeal, int _id, int _speed, int _lenght, int _range) : base(_id, _speed, _lenght, _range)
        {
                valueOfHeal = _valueOfHeal;
        }
        public void Heal() { }
        
    }
}
