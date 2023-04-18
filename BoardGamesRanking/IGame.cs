
using static BoardGamesRanking.GameBase;


namespace BoardGamesRanking
{
    public interface IGame
    {
        string Name { get; }
        string Publisher { get; }
        void AddRate(float rate);
        void AddRate(string rate);

        event RateAddedDelegate RateAdded;
        Statistics GetStatistics();

    }
}
