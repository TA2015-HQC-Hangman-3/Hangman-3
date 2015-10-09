namespace Hangman.Logic.DataManagers
{
    using System.IO;
    using System.Xml.Serialization;

    using Contracts;
    using SaveLoad;

    public class XmlGameStateManager<T> : IDataManager<T> where T : SaveLoadManager
    {
        private const string DefaultXmlSavePath = @"..\..\..\Hangman.Logic\files\savedGameState.xml";

        private readonly XmlSerializer xmlSerializer;
        private readonly string xmlSavePath;

        public XmlGameStateManager()
        {
            this.xmlSavePath = DefaultXmlSavePath;
            this.xmlSerializer = new XmlSerializer(typeof(T));
        }

        public XmlGameStateManager(string filePath)
        {
            this.xmlSavePath = filePath;
            this.xmlSerializer = new XmlSerializer(typeof(T));
        }

        public T Read()
        {
            if (!File.Exists(this.xmlSavePath))
            {
                throw new FileNotFoundException("Error: file not found!");
            }

            T information;

            using (StreamReader reader = new StreamReader(this.xmlSavePath))
            {
                information = this.xmlSerializer.Deserialize(reader) as T;
            }

            return information;
        }

        public void Write(T information)
        {
            using (StreamWriter writer = new StreamWriter(this.xmlSavePath))
            {
                this.xmlSerializer.Serialize(writer, information);
            }
        }
    }
}
