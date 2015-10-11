namespace Hangman.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Provides Unit Tests for <see cref="HangmanWord"/> class.
    /// </summary>
    [TestClass]
    public class HangmanWordTests
    {
        /// <summary>
        /// Checks if the chosen word's length equals the hidden word's length.
        /// </summary>
        [TestMethod]
        public void HangmanWord_ShouldChosenWordLenghtEqualToHiddenWordLength()
        {
            var word = "cookie";
            var hangmanWord = new HangmanWord(word);
            Assert.AreEqual(hangmanWord.TheChosenWord.Length, hangmanWord.HiddenWord.Length);
        }

        /// <summary>
        /// Checks if it throws when null is passed.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HangmanWord_WhenNullWordIsProvided_ShouldThrow()
        {
            string word = null;
            var hangmanWord = new HangmanWord(word);
        }

        /// <summary>
        /// Checks if length of valid chosen word and length hidden word are equal.
        /// </summary>
        [TestMethod]
        public void HangmanWord_WhenWordIsValid_ShouldGenerateHiddenWordWithLenghtEqualToChosenWordLength()
        {
            string word = "cookie";
            var hangmanWord = new HangmanWord(word);

            Assert.AreEqual(hangmanWord.TheChosenWord.Length, hangmanWord.HiddenWord.Length);
        }

        /// <summary>
        /// Checks if IsLetterGuessedForFirstTime method returns true if letter is guessed for the first time.
        /// </summary>
        [TestMethod]
        public void HangmanWordIsGuessedForTheFirstTime_WhenIsTheFirstTime_ShouldReturnTrue()
        {
            string word = "cookie";
            var letter = "o";
            var hangmanWord = new HangmanWord(word);

            var actual = hangmanWord.IsLetterGuessedForFirstTime(letter);

            Assert.IsTrue(actual);
        }

        /// <summary>
        /// Checks if IsLetterGuessedForFirstTime method returns false if letter is not guessed for the first time.
        /// </summary>
        [TestMethod]
        public void HangmanWordIsGuessedForTheFirstTime_WhenNotTheFirstTime_ShouldReturnFalse()
        {
            string word = "cookie";
            var letter = "o";
            var hangmanWord = new HangmanWord(word);
            hangmanWord.IsLetterGuessedForFirstTime(letter);

            var actual = hangmanWord.IsLetterGuessedForFirstTime(letter);

            Assert.IsFalse(actual);
        }

        /// <summary>
        /// Checks whether only underlines are returned when no letter is guessed.
        /// </summary>
        [TestMethod]
        public void HangmanWordPrintTheWord_WhenNoLetterIsGuessed_ShouldPrintOnlyUnderscores()
        {
            var word = "cookie";
            var hangmanWord = new HangmanWord(word);
            var printer = new Mock<IPrinter>();

            var calledCount = 0;
            
            printer.Setup(pr => pr.Print("The secret word is: "))
                    .Callback(() => ++calledCount);

            var underscoredWord = new string('_', word.Length);
            underscoredWord = string.Join(" ", underscoredWord.ToCharArray());
            underscoredWord += " ";

            printer.Setup(pr => pr.Print(underscoredWord))
                .Callback(() => ++calledCount);

            printer.Setup(pr => pr.PrintLine())
                .Callback(() => ++calledCount);

            hangmanWord.PrintTheWord(printer.Object);

            Assert.AreEqual(3, calledCount);
        }

        /// <summary>
        /// Checks if IsWordGuessed returns false when it is not guessed.
        /// </summary>
        [TestMethod]
        public void HangmanWordIsWordGuessed_WhenNotGuessed_ShouldReturnFalse()
        {
            var word = "cookie";
            var hangmanWord = new HangmanWord(word);

            var actual = hangmanWord.IsWordGuessed();

            Assert.IsFalse(actual);
        }

        /// <summary>
        /// Checks if IsWordGuessed returns true when it is guessed.
        /// </summary>
        [TestMethod]
        public void HangmanWordIsWordGuessed_WhenGuessed_ShouldReturnFalse()
        {
            var word = "cookie";
            var hangmanWord = new HangmanWord(word);
            foreach (var ch in word)
            {
                hangmanWord.IsLetterInTheWord(ch.ToString());
            }

            var actual = hangmanWord.IsWordGuessed();

            Assert.IsTrue(actual);
        }
    }
}
