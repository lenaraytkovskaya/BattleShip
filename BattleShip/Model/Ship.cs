namespace BattleShip.Model
{
    public abstract class Ship
    {
        public int id { get; set; }
        public int speed { get; set; }
        public int length { get; set; }
        public int range { get; set; }
        public Direction Direction { get; set; }
        

        public Ship() { }
        public Ship(int _id, int _speed, int _lenght, int _range)
        {
            id = _id;
            speed = _speed;
            length = _lenght;
            range = _range;
        }

        public static bool operator ==(Ship firstShip, Ship secondShip)
        {
            if (firstShip.length == secondShip.length && firstShip.GetType() == secondShip.GetType())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Ship firstShip, Ship secondShip)
        {
            if (firstShip.length != secondShip.length && firstShip.GetType() != secondShip.GetType())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "Состояние корабля: " + id.GetType() + " " + id + " " + speed.GetType() + " " + length.GetType() + " " + range.GetType() + " " + Direction.GetType();
        }
    }
}