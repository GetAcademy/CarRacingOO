﻿using System;
using System.Linq;
using System.Windows.Threading;
using CarRacingOO.Model;
using CarRacingOO.View;
using Car = CarRacingOO.View.Car;

namespace CarRacingOO.Presenter
{
    internal class GamePresenter
    {
        private readonly Game _game;
        private readonly GameWindow _gameWindow;
        private readonly DispatcherTimer _timer;
        private const int SizeFactor = 5;

        public GamePresenter(GameWindow gameWindow)
        {
            _gameWindow = gameWindow;
            _game = new Game();
            _timer = new DispatcherTimer();
            _timer.Tick += Update;
            _timer.Interval = TimeSpan.FromMilliseconds(20);
        }

        public void Start()
        {
            _timer.Start();
        }

        private void Update(object? sender, EventArgs e)
        {
            _game.GameLoop();
            _gameWindow
                .SetPlayerX(_game.Player.PositionLeft.X)
                .UpdateRoadMarks(_game.Speed * SizeFactor)
                .UpdateCars(_game.Cars.Select(c => new Car(c.Rectangle.Position, c.ImageIndex)))
                .UpdateStar(_game.Star?.Rectangle.Position);
            if (!_game.IsRunning)
            {
                _timer.Stop();
            }
        }

        public void SetMove(bool isLeft, bool isMove)
        {
            _game.Player.SetDirection(isLeft, isMove);
        }
    }
}
