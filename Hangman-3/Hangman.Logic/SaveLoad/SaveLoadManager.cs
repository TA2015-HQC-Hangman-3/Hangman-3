namespace Hangman.Logic.SaveLoad
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using Contracts;
    using DataManagers;

    /// <summary>
    /// Represents the object for loading and saving the game state.
    /// </summary>
    public class SaveLoadManager : ISaveLoadManager
    { 
        private IPrinter printer;
        private IDataManager<SaveLoadManager> gameStateInfoManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveLoadManager"/> class.
        /// </summary>
        public SaveLoadManager()
        {
            // Poor man's IoC
            this.printer = new ConsolePrinter();
            this.gameStateInfoManager = new XmlGameStateManager<SaveLoadManager>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveLoadManager"/> class.
        /// </summary>
        /// <param name="printer">The object used to show messages.</param>
        /// <param name="dataManager">The object used to keeping game state information.</param>
        public SaveLoadManager(IPrinter printer, IDataManager<SaveLoadManager> dataManager)
        {
            this.printer = printer;
            this.gameStateInfoManager = dataManager;
        }

        public Memento GameState { get; set; }

        /// <summary>
        /// Implementing saving of the game.
        /// </summary>
        public void SaveGame()
        {
            this.gameStateInfoManager.Write(this);

            this.printer.PrintLine("Game successfully saved!");
        }

        /// <summary>
        /// Implementing loading of the game.
        /// </summary>
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
