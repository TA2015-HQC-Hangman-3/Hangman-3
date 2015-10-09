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
        /// <summary>
        /// Method for reading from file.
        /// </summary>
        /// <param name="filePath">The path to the file to be read from.</param>
        /// <returns>Collection of type dictionary.</returns>ss
        public T Read(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Error: file not found!");
            }

            T information;

            using (StreamReader reader = new StreamReader(filePath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                information = xmlSerializer.Deserialize(reader) as T;
            }

            return information;
        }

        /// <summary>
        /// Method for writing in file.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <param name="information">Collection containing the information to be written in dictionary.</param>
        public void Write(string filePath, T information)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                xmlSerializer.Serialize(writer, information);
            }
        }
    }
}
