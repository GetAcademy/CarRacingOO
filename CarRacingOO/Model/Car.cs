using System;
using System.Windows;

namespace CarRacingOO.Model
{
    internal class Car
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Vector Position => new(X, Y);
        public Car()
        {
            X = MyRandom.Instance.Next(0, 430);
            Y = MyRandom.Instance.Next(-400, -100);
        }

        public void Move(int speedY)
        {
            Y += speedY;
        }
    }
}
