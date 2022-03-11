namespace CarRacingOO.Model
{
    internal class Game
    {
        public Player Player { get; }
        public Car[] Cars { get; }
        public Star Star { get; }

        public Game()
        {
            Player = new Player();
            Cars = new[] { new Car(), new Car() };
            Star = new Star();
        }
    }
}
