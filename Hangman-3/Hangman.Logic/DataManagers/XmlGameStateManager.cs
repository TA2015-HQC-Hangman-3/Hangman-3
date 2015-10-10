namespace Hangman.Logic.DataManagers
{
    using System.IO;
    using System.Xml.Serialization;

    using Contracts;
    using SaveLoad;

    /// <summary>
    /// Represents saving game state in XML
    /// </summary>
    /// <typeparam name="T">The type of object that deals with saving and loading the game.</typeparam>
    public class XmlGameStateManager<T> : IDataManager<T> where T : SaveLoadManager
    {
        private const string DefaultXmlSavePath = @"..\..\..\Hangman.Logic\files\savedGameState.xml";

        private readonly XmlSerializer xmlSerializer;
        private readonly string xmlSavePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlGameStateManager{T}"/> class.
        /// </summary>
        public XmlGameStateManager()
        {
            this.xmlSavePath = DefaultXmlSavePath;
            this.xmlSerializer = new XmlSerializer(typeof(T));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlGameStateManager{T}"/> class.
        /// </summary>
        /// <param name="filePath">Specifies the path to the XML file.</param>
        public XmlGameStateManager(string filePath)
        {
            this.xmlSavePath = filePath;
            this.xmlSerializer = new XmlSerializer(typeof(T));
        }

        /// <summary>
        /// Implements the reading from the file.
        /// </summary>
        /// <returns>Object of the specified type.</returns>
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

        /// <summary>
        /// Implements the writing in the XML file.
        /// </summary>
        /// <param name="information">Specifies the information written in the file.</param>
        public void Write(T information)
        {
            using (StreamWriter writer = new StreamWriter(this.xmlSavePath))
            {
                this.xmlSerializer.Serialize(writer, information);
            }
        }
    }
}
