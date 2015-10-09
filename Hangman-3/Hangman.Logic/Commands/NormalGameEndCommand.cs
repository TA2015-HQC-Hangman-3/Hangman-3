namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    /// <summary>
    /// Class representing command for normal game ending.
    /// </summary>
    public class NormalGameEndCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalGameEndCommand"/> class.
        /// </summary>
        /// <param name="printer">Accepts one parameter of type IPrinter used to print Game context`s current message.</param>
        public NormalGameEndCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        /// <summary>
        /// Method for executing NormalGameEnd command.
        /// </summary>
        /// <param name="context">Accepts game context object as parameter.</param>
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
