namespace Hangman.Logic.DataManagers
{
    using System.IO;
    using System.Xml.Serialization;

    using Contracts;
    using SaveLoad;

    public class XmlGameStateManager<T> : IDataManager<T> where T : SaveLoadManager
    {
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
