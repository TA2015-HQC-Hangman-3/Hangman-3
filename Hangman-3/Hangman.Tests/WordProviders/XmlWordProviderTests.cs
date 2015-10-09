namespace Hangman.Tests.WordProviders
{
    //using Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    [TestClass]
    public class XmlWordProviderTests
    {
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


        [TestMethod]
        public void XmlWordProviderGetWord_ManyWordsInFileAndCalledTwice_ShouldReturnDifferentWords()
        {
            var path = GetFilePathForWordsCount(15);

            var b = 5;
        }
    }
}
