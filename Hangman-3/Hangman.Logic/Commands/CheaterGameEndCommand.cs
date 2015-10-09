namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    public class CheaterGameEndCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        public CheaterGameEndCommand(IPrinter printer)
        {
            this.printer = printer;
        }

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
