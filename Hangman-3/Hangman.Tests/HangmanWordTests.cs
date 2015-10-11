using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Tests
{
    [TestClass]
    public class HangmanWordTests
    {
        [TestMethod]
        public void HangmanWord_ShouldChosenWordLenghtEqualToHiddenWordLength()
        {
            var word = "cookie";
            var hangmanWord = new HangmanWord(word);
            Assert.AreEqual(hangmanWord.TheChosenWord.Length, hangmanWord.HiddenWord.Length);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HangmanWord_WhenNullWordIsProvided_ShouldThrow()
        {
            string word = null;
            var hangmanWord = new HangmanWord(word);
        }

        [TestMethod]
        public void HangmanWord_WhenWordIsValid_ShouldGenerateHiddenWordWithLenghtEqualToChosenWordLength()
        {
            string word = "cookie";
            var hangmanWord = new HangmanWord(word);

            Assert.AreEqual(hangmanWord.TheChosenWord.Length,hangmanWord.HiddenWord.Length);
        }

        [TestMethod]
        public void HangmanWordIsGuessedForTheFirstTime_WhenIsTheFirstTime_ShouldReturnTrue()
        {
            string word = "cookie";
            var letter = "o";
            var hangmanWord = new HangmanWord(word);

            var actual = hangmanWord.IsLetterGuessedForFirstTime(letter);

            Assert.IsTrue(actual);
        }

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
    }
}
