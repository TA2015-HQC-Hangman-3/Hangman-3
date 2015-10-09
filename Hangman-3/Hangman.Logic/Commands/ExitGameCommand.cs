namespace Hangman.Logic.Commands
{
    using System;
    using Hangman.Logic;

    /// <summary>
    /// Class representing the type of command that exits the game.
    /// </summary>
    public class ExitGameCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExitGameCommand"/> class.
        /// </summary>
        /// <param name="printer">Accepts parameter from type IPrinter used to print Game context`s current message.</param>
        public ExitGameCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        /// <summary>
        /// Method for executing command.
        /// </summary>
        /// <param name="context">Contains the current message.</param>
        public void Execute(IGameContext context)
        {
            context.CurrentMessage = GameContext.GoodbyeMessage;
            this.printer.PrintLine(context.CurrentMessage);
            Environment.Exit(1);
        }
    }
}
