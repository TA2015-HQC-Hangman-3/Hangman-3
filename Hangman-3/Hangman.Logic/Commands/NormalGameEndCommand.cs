namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    public class NormalGameEndCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        public NormalGameEndCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        public void Execute(IGameContext context)
        {
            context.CurrentMessage = string.Format(GameContext.WinMessage, context.CurrentMistakes);
            this.printer.Print(context.CurrentMessage);
            context.Word.PrintTheWord();

            context.CurrentMessage = GameContext.PromptForUserName;
            this.printer.Print(context.CurrentMessage);
            context.Scoreboard.AddScore(context.CurrentMistakes);

            context.Scoreboard.PrintScore();

            context.CurrentMessage = GameContext.PromptForCommand;
            this.printer.Print(context.CurrentMessage);
        }
    }
}
