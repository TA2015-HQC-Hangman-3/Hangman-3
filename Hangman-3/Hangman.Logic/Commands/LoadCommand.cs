namespace Hangman.Logic.Commands
{
    using System;
    using System.IO;

    using Hangman.Logic;
    using Hangman.Logic.Contracts;

    /// <summary>
    /// Class representing the command for loading the game.
    /// </summary>
    public class LoadCommand : IHangmanCommand
    {
        private ISaveLoadManager gameSaver;
        private IPrinter printer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadCommand"/> class. 
        /// </summary>
        /// <param name="gameSaver">Accepts first parameter of type ISaveLoadManager to call the saved game state.</param>
        /// <param name="printer">Accepts second parameter of type IPrinter used to print Game context`s current message.</param>
        public LoadCommand(ISaveLoadManager gameSaver, IPrinter printer)
        {
            this.gameSaver = gameSaver;
            this.printer = printer;
        }

        /// <summary>
        /// Method for executing load command.
        /// </summary>
        /// <param name="context">Accepts parameter for game context.</param>
        public void Execute(IGameContext context)
        {
            try
            {
                this.gameSaver.LoadGame();
                context.Load(this.gameSaver.GameState);
            }
            catch (FileNotFoundException ex)
            {
                this.printer.PrintLine(ex.Message);
            }
            catch (ArgumentNullException nullEx)
            {
                this.printer.PrintLine(nullEx.Message);
            }            
        }
    }
}
