using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using CarRacingOO.Presenter;

namespace CarRacingOO.View
{
    internal class GameWindow : Window
    {
        private readonly Rectangle _player;
        private readonly GamePresenter _presenter;

        public GameWindow()
        {
            Width = 525;
            Height = 517;
            Title = "Car racing OO";
            var canvas = new Canvas
            {
                Background = new SolidColorBrush(Colors.Gray)
            };

            canvas.KeyDown += UpdateKeys;
            canvas.KeyUp += UpdateKeys;
            canvas.Children.Clear();
            _player = CreateRectangle(Colors.Yellow);
            Canvas.SetTop(_player, 374);
            canvas.Children.Add(_player);
            Content = canvas;
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

        private static Rectangle CreateRectangle(Color color, int width = 55, int height = 80)
            => new Rectangle { Fill = new SolidColorBrush(color), Height = height, Width = width };

        public void SetPlayerX(int playerX)
        {
            Canvas.SetLeft(_player, playerX);
        }
    }
}
