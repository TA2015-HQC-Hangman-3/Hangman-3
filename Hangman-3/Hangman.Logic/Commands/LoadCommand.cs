// <copyright file="LoadCommand.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Class LoadCommand.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Commands
{
    using System;
    using System.IO;
    using Hangman.Logic;
    using Hangman.Logic.Contracts;

    /// <summary>
    /// Represents object for loading the game of type command.
    /// </summary>
    public class LoadCommand : IHangmanCommand
    {
        private ISaveLoadManager gameSaver;
        private IPrinter printer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadCommand"/> class.
        /// </summary>
        /// <param name="gameSaver">The object having the game state that is loaded.</param>
        /// <param name="printer">The object used to show messages.</param>
        public LoadCommand(ISaveLoadManager gameSaver, IPrinter printer)
        {
            this.gameSaver = gameSaver;
            this.printer = printer;
        }

        /// <summary>
        /// Implements the execution of the load game command.
        /// </summary>
        /// <param name="context">The game context for the execution of the command.</param>
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
