namespace Hangman.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Logic.Sorters;
    using Moq;

    [TestClass]
    public class ScoreboardTests
    {

        class FakePrinter : IPrinter
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
        }

        [TestMethod]
        public void Sample()
        {
            var printer = new FakePrinter();
            var sorter = new SelectionSorter();

            var scoreboard = new Scoreboard(printer, sorter);

            scoreboard.PrintScore();

            //check printer.Messages
        }

        [TestMethod]
        public void ScoreboardPrintScores_WhenNoScores_ShouldPrint1Message()
        {
            var printer = new Mock<IPrinter>();
            var messagesCount = 0;
            printer.Setup(p => p.Print(It.IsAny<string>()))
                    .Callback(() => ++messagesCount);
            var sorter = new SelectionSorter();

            var scoreboard = new Scoreboard(printer.Object, sorter, "../../test-score.txt");
            
            scoreboard.PrintScore();

            //check printer.Messages

            //assert
            Assert.AreEqual(1, messagesCount);
        }
    }
}
