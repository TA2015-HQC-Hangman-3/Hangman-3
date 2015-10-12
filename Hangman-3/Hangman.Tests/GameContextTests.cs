// <copyright file="GameContextTests.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Class GameContextTests.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Tests
{
    using Hangman.Logic;
    using Hangman.Logic.Contracts;
    using Hangman.Logic.WordProviders;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Provides Unit Tests for <see cref="GameContext"/> class.
    /// </summary>
    [TestClass]
    public class GameContextTests
    {
        /// <summary>
        /// Tests if all fields in class GameContext are filled properly.
        /// </summary>
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
