namespace Hangman.Commands
{
    public class RestartCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        public RestartCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        public void Execute(GameContext context)
        {
            this.printer.ClearScreen();
            context.Reset();
            context.IsGameRunning = true;
            this.printer.Print(context.CurrentMessage);
        }
    }
}
