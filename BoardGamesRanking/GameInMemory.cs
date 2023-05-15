namespace BoardGamesRanking
{
    public class GameInMemory : GameBase
    {
        public override event RateAddedDelegate RateAdded;

        private List<float> rates = new List<float>();

        public GameInMemory(string name, string publisher) 
            : base(name, publisher)
        {

        }
        public override void AddRate(float rate)
        {
            if (rate >= 0.0 && rate <= 10.0)
            {
                this.rates.Add(rate);

                if (RateAdded != null)
                {
                    RateAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(rate), $"{(nameof(rate))} is incorrect. Numbers form 0 to 10 required");
            }
        }
        public override Statistics GetStatistics()
        {
            Statistics statistics = new Statistics();

            foreach (var rate in rates)
            {
                statistics.AddRate(rate);
            }
            return statistics;
        }
    }
}
