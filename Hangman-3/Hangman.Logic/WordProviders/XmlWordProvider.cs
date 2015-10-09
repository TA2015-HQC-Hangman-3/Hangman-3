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
        private static volatile XmlWordProvider instance;
        private static object syncLock = new object();
     
        private const string XmlWordsFilePath = @"..\..\..\Hangman.Logic\files\words.xml";
           
        private XmlWordProvider()
        {
            this.AvailableWords = this.LoadWords();
            //this.AvailableWords = this.availableWords;
        }

        private IEnumerable<string> LoadWords()
        {
            var doc = XDocument.Load(XmlWordsFilePath);
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