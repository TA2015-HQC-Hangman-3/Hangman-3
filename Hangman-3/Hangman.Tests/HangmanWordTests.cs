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
        public void HangmanWord_WhenNullWordIsProvidedShouldThrow()
        {
            string word = null;
            var hangmanWord = new HangmanWord(word);
        }

        [TestMethod]
        public void HangmanWord_ShouldGenerateHiddenWordReturnWordWithLenghtEqualToChosenWordWength()
        {
            string word = "cookie";
            var hangmanWord = new HangmanWord(word);

            Assert.AreEqual(hangmanWord.TheChosenWord.Length,hangmanWord.HiddenWord.Length);
           
        }
    }
}
