using System;

namespace CarRacingOO.Model
{
    internal class Game
    {
        public Player Player { get; }
        public Car[] Cars { get; }
        public Star Star { get; }
        public int Speed { get; }
        public int Width { get; } = 508;
        public int Height { get; } = 500;
        public bool IsRunning { get; private set; }

        public Game()
        {
            Player = new Player(222, 453);
            Cars = new[] { new Car(this), new Car(this) };
            Star = new Star();
            Speed = 15;
        }

        public void GameLoop()
        {
            Player.Move();
            Cars[0].Move(Speed);
            Cars[1].Move(Speed);
        }
    }
}
