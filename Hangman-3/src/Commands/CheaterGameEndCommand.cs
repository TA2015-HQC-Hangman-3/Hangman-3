﻿namespace Hangman.Commands
{
    public class CheaterGameEndCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        public CheaterGameEndCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        public void Execute(GameContext context)
        {
            context.CurrentMessage = string.Format(GameContext.WinByCheatingMessage, context.CurrentMistakes);
            this.printer.Print(context.CurrentMessage);

            context.Word.PrintTheWord();

            context.CurrentMessage = GameContext.PromptForCommand;
            this.printer.Print(context.CurrentMessage);
        }
    }
}
