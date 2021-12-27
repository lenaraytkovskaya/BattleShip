using BattleShip.Model;

namespace BattleShip.Interfaces
{
    public  interface IField
    {
        public bool AddShips(TypeShip typeship, Point point, Direction direction, int length);
    }
}
