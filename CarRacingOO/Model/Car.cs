using System;
using System.Windows;

namespace CarRacingOO.Model
{
    internal class Car
    {
        private Game _game;
        public int X { get; private set; }
        public int Y { get; private set; }
        public int ImageIndex { get; private set; }
        public Vector Position => new(X, Y);
        public Car(Game game)
        {
            _game = game;
            Reset();
        }

        private void Reset()
        {
            X = MyRandom.Instance.Next(0, 430);
            Y = MyRandom.Instance.Next(-400, -100);
            ImageIndex = MyRandom.Instance.Next(0, 5);
        }

        public void Move(int speedY)
        {
            Y += speedY;
            if (Y > _game.Height) Reset();
        }
    }
}
