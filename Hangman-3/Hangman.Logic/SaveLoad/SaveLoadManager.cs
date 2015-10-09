namespace Hangman.Logic.SaveLoad
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    using Contracts;
    using DataManagers;

    /// <summary>
    /// Class the saving of the game state.
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

<<<<<<< HEAD
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveLoadManager"/> class.
        /// </summary>
        /// <param name="printer">Accepts parameter of type IPrinter to show message if the game was saved.</param>
        public SaveLoadManager(IPrinter printer)
        {
            this.printer = printer;
            this.gameStateInfoManager = new XmlGameStateManager<SaveLoadManager>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveLoadManager"/> class.
        /// </summary>
        /// <param name="printer">Accepts parameter of type IPrinter to show message if the game was saved.</param>
        /// <param name="dataManager">Accepts parameter of type IDataManager to keep information about the current game state.</param>
=======
>>>>>>> b6e5466bce575ebb4498be25c79f1bf7c40f1770
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
