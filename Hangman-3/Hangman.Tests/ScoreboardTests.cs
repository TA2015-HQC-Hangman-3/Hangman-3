namespace Hangman.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Logic.DataManagers;
    using Logic.Sorters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ScoreboardTests
    {
        [TestMethod]
        public void ScoreboardPrintScores_WhenNoScores_ShouldPrint1Message()
        {
            var printer = new Mock<IPrinter>();
            var messagesCount = 0;
            printer.Setup(p => p.PrintLine(It.IsAny<string>()))
                    .Callback(() => ++messagesCount);
            var sorter = new SelectionSorter();
            var scoreDataManager = new TextFileScoreboardDataManager<Dictionary<string, int>>("../../test-score.txt");

            var scoreboard = new Scoreboard(printer.Object, sorter, scoreDataManager);

            scoreboard.PrintScore();

            // check printer.Messages

            // assert
            Assert.AreEqual(1, messagesCount);
        }
    }
}
