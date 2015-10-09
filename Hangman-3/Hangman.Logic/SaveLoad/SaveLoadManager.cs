namespace Hangman.Logic.SaveLoad
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    using Contracts;
    using DataManagers;

    public class SaveLoadManager : ISaveLoadManager
    { 
        private IPrinter printer;
        private IDataManager<SaveLoadManager> gameStateInfoManager;

        public SaveLoadManager()
        {
            // Poor man's IoC
            this.printer = new ConsolePrinter();
            this.gameStateInfoManager = new XmlGameStateManager<SaveLoadManager>();
        }

        public SaveLoadManager(IPrinter printer, IDataManager<SaveLoadManager> dataManager)
        {
            this.printer = printer;
            this.gameStateInfoManager = dataManager;
        }

        public Memento GameState { get; set; }

        public void SaveGame()
        {
            this.gameStateInfoManager.Write(this);

            this.printer.PrintLine("Game successfully saved!");
        }

        public void LoadGame()
        {
            SaveLoadManager game = this.gameStateInfoManager.Read();

            if (game == null)
            {
                throw new ArgumentNullException("Saved state cannot be null");
            }

            this.GameState = game.GameState;

            this.printer.PrintLine("Game successfully loaded!");
        }
    }
}
