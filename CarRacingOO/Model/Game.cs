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
        public bool IsPowerMode { get; private set; }

        private int _starCounter = 30;
        private int _powerModeCounter = 200;

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
            UpdatePowerMode();
            UpdateStar();
            IsRunning = !Cars.Any(car => car.CrashesWith(Player));
        }

        private void UpdatePowerMode()
        {
            if (!IsPowerMode) return;
            _powerModeCounter--;
            IsPowerMode = _powerModeCounter > 0;
        }

        private void UpdateStar()
        {
            if (Star != null)
            {
                var stillExists = Star.Move(Speed);
                var isStarCrash = Star.CrashesWith(Player);
                if(isStarCrash|| !stillExists) Star = null;
                if (isStarCrash) PowerUp();
            }
            else if (--_starCounter < 1)
            {
                Star = new Star();
                _starCounter = MyRandom.Instance.Next(600, 900);
            }
        }

        private void PowerUp()
        {
            IsPowerMode = true;
            _powerModeCounter = 200;
        }
    }
}
