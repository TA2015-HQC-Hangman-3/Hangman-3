// <copyright file="XmlWordProviderTests.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Class XmlWordProviderTests.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Tests.WordProviders
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Logic.WordProviders;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    /// <summary>
    /// Provides unit tests for <see cref="XmlWordProvider"/> class.
    /// </summary>
    [TestClass]
    public class XmlWordProviderTests
    {
        /// <summary>
        /// Checks if method GetWord returns different words when called twice and there are many words in the file.
        /// </summary>
        [TestMethod]
        public void XmlWordProviderGetWord_ManyWordsInFileAndCalledTwice_ShouldReturnDifferentWords()
        {
            var path = this.GetFilePathForWordsCount(15);
            var wordProvider = XmlWordProvider.Instance;
            wordProvider.XmlWordsFilePath = path;

            var word1 = wordProvider.GetWord();
            var word2 = wordProvider.GetWord();

            Assert.AreNotEqual(word1, word2);
        }

        /// <summary>
        /// Checks if method GetWord returns the same word when called twice and there is one word in the file.
        /// </summary>
        [TestMethod]
        public void XmlWordProviderGetWord_OneWordsInFileAndCalledTwice_ShouldReturnTheSameWord()
        {
            var path = this.GetFilePathForWordsCount(1);
            var wordProvider = XmlWordProvider.Instance;
            wordProvider.XmlWordsFilePath = path;

            var word1 = wordProvider.GetWord();
            var word2 = wordProvider.GetWord();
            
            Assert.AreEqual(word1, word2);
        }

        /// <summary>
        /// Checks if method GetWord returns different words when called twice and there are 40 words in the file.
        /// </summary>
        [TestMethod]
        public void XmlWordProviderGetWord_FourtyWordsInFileAndCalledTwice_ShouldReturnDifferentWords()
        {
            var path = this.GetFilePathForWordsCount(40);
            var wordProvider = XmlWordProvider.Instance;
            wordProvider.XmlWordsFilePath = path;

            var word1 = wordProvider.GetWord();
            var word2 = wordProvider.GetWord();
            
            Assert.AreNotEqual(word1, word2);
        }

        /// <summary>
        /// Checks if method GetWord returns different words when called twice and there are random number of words in the file.
        /// </summary>
        [TestMethod]
        public void XmlWordProviderGetWord_RandomcountOfWordsInFileAndCalledTwice_ShouldReturnDifferentWords()
        {
            Random random = new Random();
            var randomNumber = random.Next(10, 1000);
            var path = this.GetFilePathForWordsCount(randomNumber);
            var wordProvider = XmlWordProvider.Instance;
            wordProvider.XmlWordsFilePath = path;

            var word1 = wordProvider.GetWord();
            var word2 = wordProvider.GetWord();

            Assert.AreNotEqual(word1, word2);
        }

        private string GetFilePathForWordsCount(int count)
        {
            var words = Enumerable.Range(0, count).Select(i => "Word" + i);
            XDocument doc = new XDocument();

            var root = new XElement("words");
            doc.Add(root);

            foreach (var word in words)
            {
                root.Add(new XElement("word", word));
            }

            var filePath = Path.GetTempFileName();
            doc.Save(filePath);

            return filePath;
        }
    }
}
