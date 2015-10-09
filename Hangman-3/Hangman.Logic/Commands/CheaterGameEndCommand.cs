namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    /// <summary>
    /// Class representing the command type for end game when cheated.
    /// </summary>
    public class CheaterGameEndCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheaterGameEndCommand"/> class.
        /// </summary>
        /// <param name="printer">Accepts parameter from type IPrinter used to print Game context`s current message.</param>
        public CheaterGameEndCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        /// <summary>
        /// Method for executing command.
        /// </summary>
        /// <param name="context">Contains the current message.</param>
        public void Execute(IGameContext context)
        {
            context.CurrentMessage = string.Format(GameContext.WinByCheatingMessage, context.CurrentMistakes);
            this.printer.PrintLine(context.CurrentMessage);

            context.Word.PrintTheWord();

            context.CurrentMessage = GameContext.PromptForCommand;
            this.printer.PrintLine(context.CurrentMessage);
        }
    }
}
