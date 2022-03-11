﻿namespace CarRacingOO.Model
{
    internal class Game
    {
        public Player Player { get; }
        public Car[] Cars { get; }
        public Star Star { get; }
        public int Speed { get; }

        public Game()
        {
            Player = new Player(222, 453);
            Cars = new[] { new Car(), new Car() };
            Star = new Star();
            Speed = 15;
        }

        public void GameLoop()
        {
            Player.Move();
        }
    }
}
