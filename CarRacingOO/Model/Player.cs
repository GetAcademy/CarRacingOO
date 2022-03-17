using System;

namespace CarRacingOO.Model
{
    internal class Player
    {
        public int X { get; private set; }
        private Direction _direction;
        private readonly int _speedX;
        private readonly int _maxX;

        public Player(int startX, int maxX)
        {
            _maxX = maxX;
            X = startX;
            _speedX = 2;
        }

        public void SetDirection(bool isLeft, bool isMove)
        {
            _direction = !isMove ? Direction.None :
                          isLeft ? Direction.Left : 
                          Direction.Right;
        }

        public void Move()
        {
            var delta = _speedX * (int) _direction;
            X = Math.Clamp(X + delta, 0, _maxX);
        }
    }
}
