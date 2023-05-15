using NUnit;
using BoardGamesRanking;


namespace BoardGamesRanking.Tests
{
    public class GameTests
    {
        [Test]
        public void WhenAddRateInvokedWithFiveInts_ThenShouldReturnMaxMinAverageAndSentenceValue()
        {   
            //arrange
            GameInMemory game = new GameInMemory("Talisman", "Galaktyka");
            game.AddRate(3);
            game.AddRate(8);
            game.AddRate(6);
            game.AddRate(9);
            game.AddRate(10);

            //act
            var result = game.GetStatistics();

            //assert
            Assert.AreEqual(3, result.Min);
            Assert.AreEqual(10, result.Max);
            Assert.AreEqual(7.2, Math.Round(result.Average, 1));
            Assert.AreEqual("Better Than Good", result.AverageSentence);

        }
    }
}
