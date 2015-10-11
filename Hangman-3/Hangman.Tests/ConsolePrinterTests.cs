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

        /// <summary>
        /// Executed before each test.
        /// </summary>
        [TestInitialize]
        public void BeforeEachTest()
        {
            this.consoleOldOutput = Console.Out;

            this.stringWriter = new StringWriter();
            Console.SetOut(this.stringWriter);
        }

        /// <summary>
        /// Executed after each test.
        /// </summary>
        [TestCleanup]
        public void AfterEachTest()
        {
            Console.SetOut(this.consoleOldOutput);
        }

        /// <summary>
        /// Checks if text is printed without new line.
        /// </summary>
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

        /// <summary>
        /// Checks if a single symbol is printed without new line.
        /// </summary>
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

        /// <summary>
        /// Checks if printer prints empty string if null is passed.
        /// </summary>
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

        /// <summary>
        /// Checks if text is printed with new line. 
        /// </summary>
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

        /// <summary>
        /// Checks if printer prints only a new line if no text is passed.
        /// </summary>
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

        /// <summary>
        /// Checks screen cleaning.
        /// </summary>
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
