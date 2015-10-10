namespace Hangman.Logic.Commands
{
    using System;
    using Hangman.Logic;

    /// <summary>
    /// Represents the command for ending the game.
    /// </summary>
    public class ExitGameCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExitGameCommand"/> class.
        /// </summary>
        /// <param name="printer">The object used to show messages.</param>
        public ExitGameCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        /// <summary>
        /// The execution of the end game command.
        /// </summary>
        /// <param name="context">The game context for the current game.</param>
        public void Execute(IGameContext context)
        {
            context.CurrentMessage = GameContext.GoodbyeMessage;
            this.printer.PrintLine(context.CurrentMessage);
            Environment.Exit(1);
        }
    }
}
