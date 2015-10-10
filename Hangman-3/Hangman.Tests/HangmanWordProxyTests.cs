namespace Hangman.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HangmanWordProxyTests
    {
        [TestMethod]
        public void HangmanWordProxy_IsValidLetter_ShouldReturnFalseWhenInvalidLetterIsPassed()
        {
            var letter = "%";
            PrivateObject hangmanWordProxy = new PrivateObject(typeof(Logic.HangmanWordProxy));

            bool actual = Convert.ToBoolean(hangmanWordProxy.Invoke("IsValidLetter", letter));
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HangmanWordProxy_IsValidLetter_ShouldReturnTrueWhenValidLetterIsPassed()
        {
            var letter = "a";
            PrivateObject hangmanWordProxy = new PrivateObject(typeof(Logic.HangmanWordProxy));

            bool actual = Convert.ToBoolean(hangmanWordProxy.Invoke("IsValidLetter", letter));
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }
    }   
}
