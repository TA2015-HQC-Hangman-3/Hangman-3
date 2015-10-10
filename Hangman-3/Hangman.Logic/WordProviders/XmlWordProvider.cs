namespace Hangman.Logic.WordProviders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    /// <summary>
    /// Represents XML word provider and contain method for getting a word.
    /// </summary>
    public class XmlWordProvider : BaseWordProvider
    {
        private const string DefaultXmlWordsFilePath = @"..\..\..\Hangman.Logic\files\words.xml";

        private static volatile XmlWordProvider instance;
        private static object syncLock = new object();
     
        private string xmlWordsFilePath;

        /// <summary>
        /// Prevents a default instance of the <see cref="XmlWordProvider"/> class of being created.
        /// </summary>
        private XmlWordProvider()
        {
            this.XmlWordsFilePath = DefaultXmlWordsFilePath;
            //this.AvailableWords = this.availableWords;
        }

        /// <summary>
        /// Gets or sets the path to the XML file.
        /// </summary>
        public string XmlWordsFilePath
        {
            private get
            {
                return this.xmlWordsFilePath;
            }

            set
            {
                this.xmlWordsFilePath = value;
                this.AvailableWords = this.LoadWords();
            }
        }
           
        private IEnumerable<string> LoadWords()
        {
            var doc = XDocument.Load(this.XmlWordsFilePath);
            return doc.Root.Elements().Select(element => element.Value.ToString());
        }

        /// <summary>
        /// Gets a new instance of <see cref="XmlWordProvider"/> class. Uses lazy loading.
        /// </summary>
        public static XmlWordProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new XmlWordProvider();
                        }
                    }
                }

                return instance;
            }
        }
    }
}