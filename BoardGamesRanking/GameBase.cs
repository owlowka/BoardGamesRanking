
namespace BoardGamesRanking
{
    public abstract class GameBase : Item, IGame
    {
        public delegate void RateAddedDelegate(object sender, EventArgs args);

        public abstract event RateAddedDelegate RateAdded;

        public GameBase(string name, string publisher)
            : base(name, publisher)
        {
            Name = name;
            Publisher = publisher;
        }
        public override string Name { get; set; }
        public override string Publisher { get; set; }
        public abstract void AddRate(float rate);
        public abstract void AddRate(string rate);
        public abstract Statistics GetStatistics();

    }
}
