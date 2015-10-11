namespace Hangman.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
   
    /// <summary>
    /// Provides Unit Tests for <see cref="HangmanWordProxy"/> class.
    /// </summary>
    [TestClass]
    public class HangmanWordProxyTests
    {
        /// <summary>
        /// Checks if method IsValidLetter returns false when non letter is passed.
        /// </summary>
        [TestMethod]
        public void HangmanWordProxy_IsValidLetter_ShouldReturnFalseWhenInvalidLetterIsPassed()
        {
            var letter = "%";
            PrivateObject hangmanWordProxy = new PrivateObject(typeof(Logic.HangmanWordProxy));

            bool actual = Convert.ToBoolean(hangmanWordProxy.Invoke("IsValidLetter", letter));
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks if method IsValidLetter returns true when a valid letter is passed.
        /// </summary>
        [TestMethod]
        public void HangmanWordProxy_IsValidLetter_ShouldReturnTrueWhenValidLetterIsPassed()
        {
            var letter = "a";
            PrivateObject hangmanWordProxy = new PrivateObject(typeof(Logic.HangmanWordProxy));

            bool actual = Convert.ToBoolean(hangmanWordProxy.Invoke("IsValidLetter", letter));
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks if the method IsLetterGuessedForFirstTime returns true if only one letter is passed.
        /// </summary>
        [TestMethod]
        public void HangmanWordProxy_IsLetterGuessedForFirstTime_ShouldReturnTrueWhenSingleLetterIsPassed()
        {
            var letter = "a";
            var hangmanWordProxy = new Logic.HangmanWordProxy(letter);

            bool actual = hangmanWordProxy.IsLetterGuessedForFirstTime(letter);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }
    }   
}
