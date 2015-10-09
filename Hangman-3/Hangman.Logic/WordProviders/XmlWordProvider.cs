using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hangman.Logic.WordProviders
{
    public class XmlWordProvider:BaseWordProvider
    {
        private const string DefaultXmlWordsFilePath = @"..\..\..\Hangman.Logic\files\words.xml";

        private static volatile XmlWordProvider instance;
        private static object syncLock = new object();
     
        private string xmlWordsFilePath;

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
           
        private XmlWordProvider()
        {
            this.XmlWordsFilePath = DefaultXmlWordsFilePath;
            //this.AvailableWords = this.availableWords;
        }

        private IEnumerable<string> LoadWords()
        {
            var doc = XDocument.Load(this.XmlWordsFilePath);
            return doc.Root.Elements().Select(element => element.Value.ToString());
        }

        public static XmlWordProvider Instance
        {
            get
            {
                if (instance== null)
                {
                    lock (syncLock)
                    {
                        if (instance== null)
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