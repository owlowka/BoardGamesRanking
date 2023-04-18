namespace BoardGamesRanking.Tests
{
    public class TypeTests
    {
        private GameInMemory GetGame(string gameName, string gamePublisher)
        {
            return new GameInMemory(gameName, gamePublisher);
        }

        [Test]
        public void WhenGamesHaveDifferentNames_ShouldReturnNotEqualValues()

        {
            //arrange
            GameInMemory game1 = GetGame("Talizman", "Galaktyka");
            GameInMemory game2 = GetGame("Tajniaki", "Rebel");

            //act//assert
            Assert.AreNotSame (game1, game2);
            Assert.False(game1.Equals (game2));
            Assert.False(Object.ReferenceEquals(game1, game2));
        }

        [Test]
        public void WhenTwoVarsHaveSameObject_ShouldReturnEqualValues()

        {
            //arrange
            GameInMemory game1 = GetGame("Talizman", "Galaktyka");
            GameInMemory game2 = game1;

            //act//assert
            Assert.AreSame(game1, game2);
            Assert.True(game1.Equals(game2));
            Assert.True(Object.ReferenceEquals(game1, game2));
        }
    }
}