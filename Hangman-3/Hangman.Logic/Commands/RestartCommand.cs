// <copyright file="RestartCommand.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Class RestartCommand.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    /// <summary>
    /// Represents the command for restarting the game.
    /// </summary>
    public class RestartCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestartCommand"/> class.
        /// </summary>
        /// <param name="printer">The object used to show messages.</param>
        public RestartCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        /// <summary>
        /// Implements the execution of the command for restarting the game.
        /// </summary>
        /// <param name="context">The game context for the execution of the command.</param>
        public void Execute(IGameContext context)
        {
            this.printer.ClearScreen();
            context.Reset();
            context.IsGameRunning = true;
            this.printer.PrintLine(context.CurrentMessage);
        }
    }
}
