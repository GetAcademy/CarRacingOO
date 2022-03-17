﻿using System;
using System.Windows;

namespace CarRacingOO.Model
{
    internal class Car
    {
        private readonly Vector _size = new(11, 20);
        public Rectangle Rectangle { get; private set; }
        public int ImageIndex { get; private set; }
        public Car()
        {
            Reset();
        }

        private void Reset()
        {
            var x = MyRandom.Instance.Next(0, 89);
            var y = MyRandom.Instance.Next(-80, -20);
            ImageIndex = MyRandom.Instance.Next(0, 5);
            Rectangle = new Rectangle(x, y, _size);
        }

        public void Move(int speedY)
        {
            var x = Rectangle.Position.X;
            var y = Rectangle.Position.Y;
            y += speedY;
            if (y > 100) Reset();
            else Rectangle = new Rectangle(x, y, _size);
        }
    }
}
