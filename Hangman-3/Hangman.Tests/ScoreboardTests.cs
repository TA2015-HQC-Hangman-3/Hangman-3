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
        public class FakePrinter : IPrinter
        {
            public List<string> Messages { get; set; }

            public FakePrinter()
            {
                this.Messages = new List<string>();
            }

            public void ClearScreen()
            {
                this.Messages.Clear();
            }

            public void Print(string text)
            {
                this.Messages.Add(text);
            }

            public void PrintLine()
            {
                this.Messages.Add("\r\n");
            }

            public void PrintLine(string text)
            {
                this.Messages.Add(text + "\r\n");
            }
        }

        [TestMethod]
        public void Sample()
        {
            var printer = new FakePrinter();
            var sorter = new SelectionSorter();
            var scoreDataManager = new TextFileScoreboardDataManager<Dictionary<string, int>>();

            var scoreboard = new Scoreboard(printer, sorter, scoreDataManager);

            scoreboard.PrintScore();

            // check printer.Messages
        }

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
