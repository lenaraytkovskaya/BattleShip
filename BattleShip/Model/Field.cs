using BattleShip.Interfaces;

namespace BattleShip.Model
{
    public  class Field : IField
    {
        public int height { get; set; }
        public int width { get; set; }

        private int minX;
        private int maxX;
        private int minY;
        private int maxY;

        public Field() { }
        public Field(int _width, int _height)
        {
            width = _width;
            height = _height;
            if (width % 2 == 0)
            {
                maxX = width / 2;
                minX = maxX * -1;
            }
            else
            {
                maxX = (width + 1) / 2;
                minX = (width + 1) / 2 - width;
            }

            if (this.height % 2 == 0)
            {
                maxY = height / 2;
                minY = maxY * -1;
            }
            else
            {
                maxY = (height + 1) / 2;
                minY = (height + 1) / 2 - height;
            }
        }

        List<Point> reservesPoints = new List<Point>();

        public Dictionary<List<Point>, Ship> Ships = new Dictionary<List<Point>, Ship>();

        public bool AddShips(TypeShip typeShip, Point point, Direction direction, int length)
        {

            List<Point> NewreservesPoints = CalculationOfCoordinates(point, direction, length);


            if (Ships.Count == 0)
            {
                switch (typeShip)
                {
                    case TypeShip.WarShip:
                        WarShip warship = new WarShip();
                        reservesPoints.AddRange(NewreservesPoints.ToList());
                        Ships.Add(NewreservesPoints, warship);
                        break;
                    case TypeShip.SupportShip:
                        SupportShip supship = new SupportShip();
                        reservesPoints.AddRange(NewreservesPoints.ToList());
                        Ships.Add(NewreservesPoints, supship);
                        break;
                    case TypeShip.MixedShip:
                        MixedShip mixship = new MixedShip();
                        reservesPoints.AddRange(NewreservesPoints.ToList());
                        Ships.Add(NewreservesPoints, mixship);

                        break;
                }
                return true;

            }
            else if (PosibilityToAddShip(point.x, point.y))
            {
                switch (typeShip)
                {
                    case TypeShip.WarShip:
                        WarShip warship = new WarShip();
                        reservesPoints.AddRange(NewreservesPoints.ToList());
                        Ships.Add(NewreservesPoints, warship);
                        break;
                    case TypeShip.SupportShip:
                        SupportShip supship = new SupportShip();

                        reservesPoints.AddRange(NewreservesPoints.ToList());
                        Ships.Add(NewreservesPoints, supship);
                        break;
                    case TypeShip.MixedShip:
                        MixedShip mixship = new MixedShip();
                        reservesPoints.AddRange(NewreservesPoints.ToList());
                        Ships.Add(NewreservesPoints, mixship);
                        break;
                }
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool PosibilityToAddShip(int x, int y)
        {
            foreach (var spips in Ships)
            {
                foreach (var item in reservesPoints)
                {
                    if (x == item.x && y == item.y)
                    {
                        return false;
                    }
                }

            }
            if (x < this.minX || x > this.maxX || y < this.minY || y > this.maxY)
            {
                return false;
            }
            return true;
        }

        public List<Point> CalculationOfCoordinates(Point _point, Direction _direction, int _length)
        {
            List<Point> NewreservesPoints = new List<Point>();



            if (_length >= 1)
            {
                _point = new Point(_point.x, _point.y);
                NewreservesPoints.Add(_point);
                if (_direction == Direction.left)
                {

                    for (int i = 0; i < _length - 1; i++)
                    {
                        _point = new Point(_point.x + 1, _point.y);
                        NewreservesPoints.Add(_point);
                    }

                    _point = new Point(_point.x + 1, _point.y);
                    NewreservesPoints.Add(_point);
                    _point = new Point(_point.x - _length - 1, _point.y);
                    NewreservesPoints.Add(_point);

                    _point = new Point(_point.x, _point.y + 1);
                    NewreservesPoints.Add(_point);
                    for (int i = 0; i < _length + 1; i++)
                    {
                        _point = new Point(_point.x + 1, _point.y);
                        NewreservesPoints.Add(_point);
                    }

                    _point = new Point(_point.x, _point.y - 2);
                    NewreservesPoints.Add(_point);
                    for (int i = 0; i < _length + 1; i++)
                    {
                        _point = new Point(_point.x - 1, _point.y);
                        NewreservesPoints.Add(_point);
                    }
                }
                else if (_direction == Direction.right)
                {


                    for (int i = 0; i < _length - 1; i++)
                    {
                        _point = new Point(_point.x - 1, _point.y);
                        NewreservesPoints.Add(_point);
                    }
                    _point = new Point(_point.x - 1, _point.y);
                    NewreservesPoints.Add(_point);
                    _point = new Point(_point.x + _length + 1, _point.y);
                    NewreservesPoints.Add(_point);

                    _point = new Point(_point.x, _point.y + 1);
                    NewreservesPoints.Add(_point);
                    for (int i = 0; i < _length + 1; i++)
                    {
                        _point = new Point(_point.x - 1, _point.y);
                        NewreservesPoints.Add(_point);
                    }

                    _point = new Point(_point.x, _point.y - 2);
                    NewreservesPoints.Add(_point);
                    for (int i = 0; i < _length + 1; i++)
                    {
                        _point = new Point(_point.x + 2, _point.y);
                        NewreservesPoints.Add(_point);
                    }

                }
                else if (_direction == Direction.up)
                {

                    for (int i = 0; i < _length - 1; i++)
                    {
                        _point = new Point(_point.x, _point.y - 1);
                        NewreservesPoints.Add(_point);
                    }

                    _point = new Point(_point.x, _point.y + _length);
                    NewreservesPoints.Add(_point);
                    _point = new Point(_point.x, _point.y - _length - 1);
                    NewreservesPoints.Add(_point);


                    _point = new Point(_point.x + 1, _point.y);
                    NewreservesPoints.Add(_point);
                    for (int i = 0; i < _length + 1; i++)
                    {
                        _point = new Point(_point.x, _point.y + 1);
                        NewreservesPoints.Add(_point);
                    }

                    _point = new Point(_point.x - 2, _point.y);
                    NewreservesPoints.Add(_point);
                    for (int i = 0; i < _length + 1; i++)
                    {
                        _point = new Point(_point.x, _point.y - 1);
                        NewreservesPoints.Add(_point);
                    }
                }
                else
                {

                    for (int i = 0; i < _length - 1; i++)
                    {
                        _point = new Point(_point.x, _point.y + 1);
                        NewreservesPoints.Add(_point);
                    }

                    _point = new Point(_point.x, _point.y + 1);
                    NewreservesPoints.Add(_point);
                    _point = new Point(_point.x, _point.y - _length - 1);
                    NewreservesPoints.Add(_point);

                    _point = new Point(_point.x - 1, _point.y);
                    NewreservesPoints.Add(_point);
                    for (int i = 0; i < _length + 1; i++)
                    {
                        _point = new Point(_point.x, _point.y + 1);
                        NewreservesPoints.Add(_point);
                    }

                    _point = new Point(_point.x + 2, _point.y);
                    NewreservesPoints.Add(_point);
                    for (int i = 0; i < _length + 1; i++)
                    {
                        _point = new Point(_point.x, _point.y - 1);
                        NewreservesPoints.Add(_point);
                    }
                }

            }
            return NewreservesPoints;
        }

        public void ShowShips()
        {
            Ships = Ships.OrderBy(point => Math.Sqrt(Math.Pow(point.Key[0].x - 0, 2) + Math.Pow(point.Key[0].y - 0, 2))).ToDictionary(obj => obj.Key, obj => obj.Value);
        }

        private Point GetQuadrant(int quadrant, int x, int y)
        {
            if (quadrant == 2)
            {
                return new Point(-x, y);
            }
            if (quadrant == 3)
            {
                return new Point(-x, -y);
            }
            if (quadrant == 4)
            {
                return new Point(x, -y);
            }
            return new Point(x, y);
        }

        public Dictionary<List<Point>, Ship> this[int quadrant, int x, int y]
        {
            get
            {
                var coordinates = GetQuadrant(quadrant, x, y);

                foreach (var ships in Ships)
                {
                    for (int i = 0; i < Ships.Count; i++)
                    {
                        if (ships.Key[i].x == coordinates.x && ships.Key[i].y == coordinates.y)
                        {
                            return Ships;
                        }
                    }
                }
                return null;
            }
        }

    }
}
