using System.Linq;
using System.Windows;

namespace CarRacingOO.Model
{
    class Star
    {
        private readonly Vector _size = new(10, 10);
        public Rectangle Rectangle { get; private set; } = null!;
        public Star()
        {
            Reset();
        }

        private void Reset()
        {
            var x = MyRandom.Instance.Next(0, 86);
            var y = MyRandom.Instance.Next(-20, -80);
            Rectangle = new Rectangle(x, y, _size);
        }

        public bool Move(int speedY)
        {
            var x = Rectangle.Position.X;
            var y = Rectangle.Position.Y;
            y += speedY;
            if (y > 100) return false;
            Rectangle = new Rectangle(x, y, _size);
            return true;
        }

        public bool Contains(params Vector[] positions)
        {
            return positions.Any(Rectangle.Contains);
        }
    }
}
