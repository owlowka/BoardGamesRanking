namespace BoardGamesRanking
{
    public abstract class GameBase : Item, IGame
    {
        public delegate void RateAddedDelegate(object sender, EventArgs args);

        public abstract event RateAddedDelegate RateAdded;

        public GameBase(string name, string publisher)
            : base(name, publisher)
        {
        }

        public abstract void AddRate(float rate);
        public void AddRate(string rate)
        {
            if (float.TryParse(rate, out float result))
            {
                this.AddRate(result);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(rate), $"{(nameof(rate))} is incorrect. Numbers form 0 to 10 required");
            }
        }

        public abstract Statistics GetStatistics();
    }
}
