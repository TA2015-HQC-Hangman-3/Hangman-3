namespace Hangman.Logic.DataManagers
{
    using System.IO;
    using System.Xml.Serialization;
    using System.Web.Script.Serialization;

    using Contracts;
    using SaveLoad;

    public class JsonGameStateManager<T> : IDataManager<T> where T : SaveLoadManager
    {
        private const string DefaultJsonSavePath = @"..\..\..\Hangman.Logic\files\savedGameState.txt";

        private readonly JavaScriptSerializer jsonSerializer;
        private readonly string jsonSavePath;

        public JsonGameStateManager()
        {
            this.jsonSavePath = DefaultJsonSavePath;
            this.jsonSerializer = new JavaScriptSerializer();
        }

        public JsonGameStateManager(string filePath)
        {
            this.jsonSavePath = filePath;
            this.jsonSerializer = new JavaScriptSerializer();
        }

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
