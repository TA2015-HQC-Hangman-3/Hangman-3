// <copyright file="SimpleRandomWordProviderTests.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Class SimpleRandomWordProviderTests.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Tests.WordProviders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Hangman.Logic.WordProviders;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for <see cref="SimpleRandomWordProvider"/> class.
    /// </summary>
    [TestClass]
    public class SimpleRandomWordProviderTests
    {
        /// <summary>
        /// Checks if method GetWord returns different words when called twice and there are many words in the file.
        /// </summary>
        [TestMethod]
        public void SimpleWordProviderGetWord_ManyWordsInFileAndCalledTwice_ShouldReturnDifferentWords()
        {
            var wordProvider = SimpleRandomWordProvider.Instance;

            var word1 = wordProvider.GetWord();
            var word2 = wordProvider.GetWord();

            Assert.AreNotEqual(word1, word2);
        }
    }
}
