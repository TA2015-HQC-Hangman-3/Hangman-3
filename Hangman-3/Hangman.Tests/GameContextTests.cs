namespace Hangman.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Hangman.Logic;
    using Hangman.Logic.WordProviders;
    using Hangman.Logic.Contracts;
    using Moq;

    [TestClass]
    public class GameContextTests
    {
        [TestMethod]
        public void GameContextConstructorShouldInitializeAllFieldsProperly()
        {
            var wordProvider = SimpleRandomWordProvider.Instance;
            var scoreboard = new Mock<IScoreboard>();
            var context = new GameContext(wordProvider, scoreboard.Object);
            
            Assert.IsNotNull(context.Word);
            Assert.AreEqual(0, context.CurrentMistakes);
            Assert.AreEqual(false, context.HasCheated);
            Assert.AreEqual(true, context.IsGameRunning);
        }
    }
}
