using Hangman.Logic.WordProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Tests.WordProviders
{
    [TestClass]
    public class SimpleRandomWordProviderTests
    {
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
