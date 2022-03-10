using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

            _canvas.KeyDown += KeyDown;
            _canvas.KeyUp += KeyUp;
        }

        private void KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
        }

        private void KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
        }
    }
}
