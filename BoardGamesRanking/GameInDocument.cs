using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesRanking
{
    public class GameInDocument : GameBase
    {
        public const string documentName = "rates.txt";

        public override event RateAddedDelegate RateAdded;


        public GameInDocument(string name, string publisher) 
            : base(name, publisher)
        {

        }
        public override void AddRate(float rate)
        {
            if (rate >= 0.0 && rate <= 10.0)
            {
                using (var writer = File.AppendText(documentName))
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

        public override void AddRate(string rate)
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

        public override Statistics GetStatistics()
        {
            var ratesFromDocument = this.ReadRatesFromDocument();
            var result = this.CalculateStatistics(ratesFromDocument);
            return result;
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

            if (File.Exists($"{documentName}"))
            {
                using (var reader = File.OpenText($"{documentName}"))
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
