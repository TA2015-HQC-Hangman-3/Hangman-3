namespace Hangman.Logic.SaveLoad
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    using Hangman.Logic.Contracts;

    public class SaveLoadManager : ISaveLoadManager
    {
        private const string SavePath = @"..\..\..\Hangman.Logic\files\savedGameState.xml";
        private IPrinter printer;

        public SaveLoadManager()
            : this(new ConsolePrinter())
        {
        }

        public SaveLoadManager(IPrinter printer)
        {
            this.printer = printer;
        }

        public Memento GameState { get; set;}

        public void SaveGame()
        {
            using (StreamWriter writer = new StreamWriter(SavePath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveLoadManager));

                xmlSerializer.Serialize(writer, this);
            }

            this.printer.PrintLine("Game successfully saved!");
        }

        public void LoadGame()
        {
            if (!File.Exists(SavePath))
            {
                throw new FileNotFoundException("Error: saveGameState.xml not found!");
            }

            SaveLoadManager game;

            using (StreamReader reader = new StreamReader(SavePath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveLoadManager));
                game = xmlSerializer.Deserialize(reader) as SaveLoadManager;
            }

            if (game == null)
            {
                throw new ArgumentNullException("Saved state cannot be null");
            }

            this.GameState = game.GameState;

            this.printer.PrintLine("Game successfully loaded!");
        }
    }
}
