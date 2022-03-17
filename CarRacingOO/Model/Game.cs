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
        public Star Star { get; }
        public int Speed { get; }
        public bool IsRunning { get; private set; }

        public Game()
        {
            Player = new Player();
            Cars = new[] { new Car(), new Car() };
            Star = new Star();
            Speed = 2;
            IsRunning = true;
        }

        public void GameLoop()
        {
            Player.Move();
            Cars[0].Move(Speed);
            Cars[1].Move(Speed);
            //if(Cars.Any(car=>Player.))
        }
    }
}
