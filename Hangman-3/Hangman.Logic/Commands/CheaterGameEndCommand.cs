// <copyright file="CheaterGameEndCommand.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Class CheaterGameEndCommand.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    /// <summary>
    /// Represents the command executed at the end of the game if the player has cheated. Provides method to execute.
    /// </summary>
    public class CheaterGameEndCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheaterGameEndCommand"/> class 
        /// that contains printer to show messages.
        /// </summary>
        /// <param name="printer">The printer used to show messages.</param>
        public CheaterGameEndCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        /// <summary>
        /// Executes the command for cheater game end.
        /// </summary>
        /// <param name="context">The game context for which the command is executed.</param>
        public void Execute(IGameContext context)
        {
            context.CurrentMessage = string.Format(GameContext.WinByCheatingMessage, context.CurrentMistakes);
            this.printer.PrintLine(context.CurrentMessage);

            context.Word.PrintTheWord(this.printer);

            context.CurrentMessage = GameContext.PromptForCommand;
            this.printer.PrintLine(context.CurrentMessage);
        }
    }
}
