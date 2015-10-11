// <copyright file="ConsolePrinterTests.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Class ConsolePrinterTests.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Tests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for <see cref="ConsolePrinter"/> class.
    /// </summary>
    [TestClass]
    public class ConsolePrinterTests
    {
        private TextWriter consoleOldOutput;
        private StringWriter stringWriter;

        [TestInitialize]
        public void BeforeEachTest()
        {
            this.consoleOldOutput = Console.Out;

            this.stringWriter = new StringWriter();
            Console.SetOut(this.stringWriter);
        }

        [TestCleanup]
        public void AfterEachTest()
        {
            Console.SetOut(this.consoleOldOutput);
        }

        [TestMethod]
        public void ConsolePrinterPrint_WhenAStringIsPassed_ShouldPrintTheStringWithoutNewLine()
        {
            // arrange
            var text = "To be printed";
            var printer = new ConsolePrinter();    

            // act
            printer.Print(text);

            // assert
            var actual = this.stringWriter.ToString();
            var expected = text;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConsolePrinterPrint_WhenASingleSymbolStringIsPassed_ShouldPrintTheStringWithoutNewLine()
        {
            // arrange
            var text = "t";
            var printer = new ConsolePrinter();

            // act
            printer.Print(text);

            // assert
            var actual = this.stringWriter.ToString();
            var expected = text;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConsolePrinterPrint_WhenNullIsPassed_ShouldPrintEmptyString()
        {
            // arrange
            string text = null;
            var printer = new ConsolePrinter();

            // act
            printer.Print(text);

            // assert
            var actual = this.stringWriter.ToString();
            var expected = string.Empty;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConsolePrinterPrintLine_WhenAStringIsPassed_ShouldPrintTheStringWithNewLine()
        {
            // arrange
            var text = "To be printed";
            var printer = new ConsolePrinter();

            // act
            printer.PrintLine(text);

            // assert
            var actual = this.stringWriter.ToString();
            var expected = text + Environment.NewLine;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConsolePrinterPrintLine_WhenNoStringIsPassed_ShouldPrintOnlyNewLine()
        {
            // arrange
            var printer = new ConsolePrinter();

            // act
            printer.PrintLine();

            // assert
            var actual = this.stringWriter.ToString();
            var expected = Environment.NewLine;

            Assert.AreEqual(expected, actual);
        }

        [Ignore]
        [TestMethod]
        public void ConsolePrinterClearScreen_WhenSomethingIsPrinted_ShouldClearIt()
        {
            // arrange
            var printer = new ConsolePrinter();
            printer.PrintLine();
            printer.PrintLine("Test line");
            printer.PrintLine();
            printer.Print("Test");

            // act
            printer.ClearScreen();

            // assert
            var actual = this.stringWriter.ToString();
            var expected = string.Empty;

            Assert.AreEqual(expected, actual);
        }
    }
}
