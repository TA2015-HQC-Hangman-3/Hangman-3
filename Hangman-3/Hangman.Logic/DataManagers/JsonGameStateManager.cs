namespace Hangman.Logic.DataManagers
{
    using System.IO;
    using System.Web.Script.Serialization;
    using System.Xml.Serialization;
    using Contracts;
    using SaveLoad;

    /// <summary>
    /// Implements the transfer of information about the game state from and to JSON file.
    /// </summary>
    /// <typeparam name="T">The type of object that deals with saving and loading the game.</typeparam>
    public class JsonGameStateManager<T> : IDataManager<T> where T : SaveLoadManager
    {
        private const string DefaultJsonSavePath = @"..\..\..\Hangman.Logic\files\savedGameState.txt";

        private readonly JavaScriptSerializer jsonSerializer;
        private readonly string jsonSavePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonGameStateManager{T}"/> class.
        /// </summary>
        public JsonGameStateManager()
        {
            this.jsonSavePath = DefaultJsonSavePath;
            this.jsonSerializer = new JavaScriptSerializer();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonGameStateManager{T}"/> class.
        /// </summary>
        /// <param name="filePath">Specifies the path to the JSON file.</param>
        public JsonGameStateManager(string filePath)
        {
            this.jsonSavePath = filePath;
            this.jsonSerializer = new JavaScriptSerializer();
        }

        /// <summary>
        /// Implements the reading from the file.
        /// </summary>
        /// <returns>Object of the specified type.</returns>
        public T Read()
        {
            if (!File.Exists(this.jsonSavePath))
            {
                throw new FileNotFoundException("Error: file not found!");
            }

            T information;

            using (StreamReader reader = new StreamReader(this.jsonSavePath))
            {
                string jsonInfo = reader.ReadToEnd();
                information = this.jsonSerializer.Deserialize<T>(jsonInfo);
            }

            return information;
        }

        /// <summary>
        /// Implements the writing in the JSON file.
        /// </summary>
        /// <param name="information">Specifies the information written in the file.</param>
        public void Write(T information)
        {
            using (StreamWriter writer = new StreamWriter(this.jsonSavePath, false))
            {
                string jsonInfo = this.jsonSerializer.Serialize(information);

                writer.Write(jsonInfo);
            }
        }
    }
}
