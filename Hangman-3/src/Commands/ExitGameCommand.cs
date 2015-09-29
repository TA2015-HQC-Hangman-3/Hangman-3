namespace Hangman.Commands
{
    using System;

    public class ExitGameCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        public ExitGameCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        public void Execute(GameContext context)
        {
            context.CurrentMessage = GameContext.GoodbyeMessage;
            this.printer.Print(context.CurrentMessage);
            Environment.Exit(1);
        }
    }
}
