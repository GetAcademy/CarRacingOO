using System;
using System.Linq;

namespace CarRacingOO.Model
{
    internal class Game
    {
        /*
         * Spillet foregår innenfor en tenkt firkant med bredde og høyde på 100.
         * I brukergrensesnittet ganger vi opp til den størrelsen vi ønsker.
         */
        public Player Player { get; }
        public Car[] Cars { get; }
        public Star? Star { get; private set; }
        public int Speed { get; }
        public bool IsRunning { get; private set; }

        private int _starCounter = 30;

        public Game()
        {
            Player = new Player();
            Cars = new[] { new Car(), new Car() };
            Speed = 2;
            IsRunning = true;
        }

        public void GameLoop()
        {
            Player.Move();
            Cars[0].Move(Speed);
            Cars[1].Move(Speed);
            UpdateStar();
            IsRunning = !Cars.Any(car => car.CrashesWith(Player));
        }

        private void UpdateStar()
        {
            if (Star != null)
            {
                var stillExists = Star.Move(Speed);
                if (!stillExists) Star = null;
            }
            else if (--_starCounter < 1)
            {
                Star = new Star();
            }
        }
    }
}
