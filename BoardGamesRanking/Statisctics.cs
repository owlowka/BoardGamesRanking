using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesRanking
{
    public class Statistics
    {
        public Statistics()
        {
            Count = 0;
            Sum = 0;
            Max = float.MinValue;
            Min = float.MaxValue;
        }

        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Sum { get; private set; }
        public float Count { get; private set; }

        public float Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public string AverageSentence
        {
            get
            {
                switch (Average)
                {
                    case var average when average >= 9:
                        return "The Best Of The Bests";
                    case var average when average >= 7:
                        return "Better Than Good";
                    case var average when average >= 5:
                        return "Good";
                    case var average when average >= 4:
                        return "Could Be Better";
                    case var average when average >= 2:
                        return "Not So Good";
                    default:
                        return "The worst or without grades";
                }
            }
        }

        public void AddRate(float rate)
        {
            Count++;
            Sum+= rate;
            Min = Math.Min(rate, Min);
            Max = Math.Max(rate, Max);
        }

    }
}
