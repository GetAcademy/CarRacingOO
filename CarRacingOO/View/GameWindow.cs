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
        private Canvas _canvas;

        public GameWindow()
        {
            Width = 525;
            Height = 517;
            Title = "Car racing OO";
            _canvas = new Canvas
            {
                Background = new SolidColorBrush(Colors.Gray)
            };

            _canvas.KeyDown += CanvasKeyDown;
            _canvas.KeyUp += CanvasKeyUp;
            Reset();
            var gamePresenter = new GamePresenter(this);
            gamePresenter.Start();
        }

        private void CanvasKeyDown(object sender, KeyEventArgs e)
        {
        }

        private void CanvasKeyUp(object sender, KeyEventArgs e)
        {
        }

        private void Reset()
        {
            _canvas.Children.Clear();
            var player = CreateRectangle(Colors.Yellow);
            Canvas.SetTop(player, 374);
            _canvas.Children.Add(_canvas);

        }

        private static Rectangle CreateRectangle(Color color, int width = 55, int height = 80)
            => new Rectangle { Fill = new SolidColorBrush(color), Height = height, Width = width };
    }
}
