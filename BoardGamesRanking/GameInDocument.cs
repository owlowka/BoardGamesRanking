namespace BoardGamesRanking
{
    public class GameInDocument : GameBase
    {
        public string DocumentName
        {
            get
            {
                return $"{Name}_{Publisher}.txt";
            }
        }

        public override event RateAddedDelegate RateAdded;

        public GameInDocument(string name, string publisher) 
            : base(name, publisher)
        {
        }
        public override Statistics GetStatistics()
        {
            var ratesFromDocument = this.ReadRatesFromDocument();
            var result = this.CalculateStatistics(ratesFromDocument);
            return result;
        }

        public override void AddRate(float rate)
        {
            if (rate >= 0.0 && rate <= 10.0)
            {
                using (var writer = File.AppendText(DocumentName))
                {
                    writer.WriteLine(rate);
                }

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

        private Statistics CalculateStatistics(List<float> results)
        {
            Statistics statistics = new Statistics();

            foreach (var result in results)
            {
                statistics.AddRate(result);
            }
            return statistics;
        }

        private List<float> ReadRatesFromDocument()
        {
            var rates = new List<float>();

            if (File.Exists($"{DocumentName}"))
            {
                using (var reader = File.OpenText($"{DocumentName}"))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        var number = int.Parse(line);
                        rates.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return rates;
        }
    }
}
