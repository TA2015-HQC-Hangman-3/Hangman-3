namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    public class RestartCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        public RestartCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        public void Execute(IGameContext context)
        {
            this.printer.ClearScreen();
            context.Reset();
            context.IsGameRunning = true;
            this.printer.PrintLine(context.CurrentMessage);
        }
    }
}
