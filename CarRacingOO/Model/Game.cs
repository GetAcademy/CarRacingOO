namespace CarRacingOO.Model
{
    internal class Game
    {
        public Player Player { get; }
        public Car[] Cars { get; }
        public Star Star { get; }

        public Game()
        {
            Player = new Player(222, 525);
            Cars = new[] { new Car(), new Car() };
            Star = new Star();
        }

        public void GameLoop()
        {
            Player.Move();
        }
    }
}
