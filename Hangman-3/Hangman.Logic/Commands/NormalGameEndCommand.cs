namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    /// <summary>
    /// Represents the command for normal end of the game.
    /// </summary>
    public class NormalGameEndCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalGameEndCommand"/> class.
        /// </summary>
        /// <param name="printer">The object used to show messages.</param>
        public NormalGameEndCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        /// <summary>
        /// Implements the execution of the command for normal ending.
        /// </summary>
        /// <param name="context">The game context for the current game.</param>
        public void Execute(IGameContext context)
        {
            context.CurrentMessage = string.Format(GameContext.WinMessage, context.CurrentMistakes);
            this.printer.PrintLine(context.CurrentMessage);
            context.Word.PrintTheWord();

            context.CurrentMessage = GameContext.PromptForUserName;
            this.printer.PrintLine(context.CurrentMessage);
            context.Scoreboard.AddScore(context.CurrentMistakes);

            context.Scoreboard.PrintScore();

            context.CurrentMessage = GameContext.PromptForCommand;
            this.printer.PrintLine(context.CurrentMessage);
        }
    }
}
