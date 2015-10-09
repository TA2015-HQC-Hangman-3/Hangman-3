namespace Hangman.Logic.DataManagers
{
    using System.IO;
    using System.Xml.Serialization;

    using Contracts;
    using SaveLoad;

    /// <summary>
    /// Class to read and write the game state in XML file.
    /// </summary>
    /// <typeparam name="T">Represents object for saving/loading the game state.</typeparam>
    public class XmlGameStateManager<T> : IDataManager<T> where T : SaveLoadManager
    {
<<<<<<< HEAD
        /// <summary>
        /// Method for reading from file.
        /// </summary>
        /// <param name="filePath">The path to the file to be read from.</param>
        /// <returns>Collection of type dictionary.</returns>ss
        public T Read(string filePath)
=======
        private const string DefaultXmlSavePath = @"..\..\..\Hangman.Logic\files\savedGameState.xml";

        private readonly XmlSerializer xmlSerializer;
        private readonly string xmlSavePath;

        public XmlGameStateManager()
        {
            this.xmlSavePath = DefaultXmlSavePath;
            this.xmlSerializer = new XmlSerializer(typeof(T));
        }

        public XmlGameStateManager(string filePath)
>>>>>>> b6e5466bce575ebb4498be25c79f1bf7c40f1770
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

<<<<<<< HEAD
        /// <summary>
        /// Method for writing in file.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <param name="information">Collection containing the information to be written in dictionary.</param>
        public void Write(string filePath, T information)
=======
        public void Write(T information)
>>>>>>> b6e5466bce575ebb4498be25c79f1bf7c40f1770
        {
            using (StreamWriter writer = new StreamWriter(this.xmlSavePath))
            {
                this.xmlSerializer.Serialize(writer, information);
            }
        }
    }
}
