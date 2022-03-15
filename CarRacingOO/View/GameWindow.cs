using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CarRacingOO.Presenter;

namespace CarRacingOO.View
{
    internal class GameWindow : Window
    {
        private readonly Rectangle _player;
        private readonly GamePresenter _presenter;
        private readonly Canvas _canvas;
        private readonly Rectangle[] _roadMarks;
        private readonly Rectangle[] _cars;

        public GameWindow()
        {
            Width = 525;
            Height = 517;
            Title = "Car racing OO";
            _canvas = new Canvas
            {
                Background = new SolidColorBrush(Colors.Gray),
                Focusable = true
            };

            _canvas.KeyDown += UpdateKeys;
            _canvas.KeyUp += UpdateKeys;
            _canvas.Focus();

            _roadMarks = Enumerable.Range(0, 4).Select(
                i => Add(CreateRoadMark(), 237, i*170-152)).ToArray();
            _player = Add(CreateRectangle(Colors.Yellow), null, 374);
            _player.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/View/images/playerImage.png")));
            _cars = new[] { Add(CreateRectangle(Colors.Blue)) , Add(CreateRectangle(Colors.Purple)) };

            Content = _canvas;
            _presenter = new GamePresenter(this);
            _presenter.Start();
        }

        private void UpdateKeys(object sender, KeyEventArgs e)
        {
            if (e.Key is Key.Left or Key.Right)
            {
                _presenter.SetMove(e.Key == Key.Left, e.IsDown);
            }
        }

        private Rectangle Add(Rectangle rectangle, int? x = null, int? y = null)
        {
            _canvas.Children.Add(rectangle);
            if (x.HasValue) Canvas.SetLeft(rectangle, x.Value);
            if (y.HasValue) Canvas.SetTop(rectangle, y.Value);
            return rectangle;
        }

        private static ImageBrush CreateImage(string fileName)
            => new(new BitmapImage(new Uri($"pack://application:,,,/View/images/{fileName}.png")));
        private static Rectangle CreateRectangle(Color color, int width = 55, int height = 80)
            => new() { Fill = new SolidColorBrush(color), Height = height, Width = width };

        private static Rectangle CreateRoadMark()
            => new() { Fill = new SolidColorBrush(Colors.White), Height = 106, Width = 20 };

        public GameWindow SetPlayerX(int playerX)
        {
            Canvas.SetLeft(_player, playerX);
            return this;
        }

        public GameWindow UpdateCars(Vector[] carPositions)
        {
            for (var i = 0; i < _cars.Length; i++)
            {
                var car = _cars[i];
                var position = carPositions[i];
                Canvas.SetLeft(car, position.X);
                Canvas.SetTop(car, position.Y);
            }
            return this;
        }

        public GameWindow UpdateRoadMarks(int speed)
        {
            foreach (var roadMark in _roadMarks)
            {
                var top = Canvas.GetTop(roadMark)+speed;
                Canvas.SetTop(roadMark, top > 510 ? -152 : top);
            }
            return this;
        }
    }
}
