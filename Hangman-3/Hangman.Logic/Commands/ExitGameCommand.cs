namespace Hangman.Logic.Commands
{
    using System;
    using Hangman.Logic;

    public class ExitGameCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        public ExitGameCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        public void Execute(IGameContext context)
        {
            context.CurrentMessage = GameContext.GoodbyeMessage;
            this.printer.Print(context.CurrentMessage);
            Environment.Exit(1);
        }
    }
}
