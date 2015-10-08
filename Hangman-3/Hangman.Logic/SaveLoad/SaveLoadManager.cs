namespace Hangman.Logic.SaveLoad
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    using Contracts;
    using DataManagers;

    public class SaveLoadManager : ISaveLoadManager
    {
        private const string SavePath = @"..\..\..\Hangman.Logic\files\savedGameState.xml";

        private IDataManager<SaveLoadManager> gameStateInfoManager;

        public SaveLoadManager()
        {
            // Poor man's IoC
            this.gameStateInfoManager = new XmlGameStateManager<SaveLoadManager>();
        }

        public Memento GameState { get; set;}

        public void SaveGame()
        {
            this.gameStateInfoManager.Write(SavePath, this);

            Console.WriteLine("Game successfully saved!");
        }

        public void LoadGame()
        {   
            SaveLoadManager game = this.gameStateInfoManager.Read(SavePath);

            if (game == null)
            {
                throw new ArgumentNullException("Saved state cannot be null");
            }

            this.GameState = game.GameState;

            Console.WriteLine("Game successfully loaded!");
        }
    }
}
