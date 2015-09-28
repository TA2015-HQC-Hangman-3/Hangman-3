namespace Hangman.Commands
{
    using System;

    public class CheaterGameEndCommand : IHangmanCommand
    {
        public void Execute(GameContext context)
        {
            context.CurrentMessage = string.Format(GameContext.WinByCheatingMessage, context.CurrentMistakes);
            Console.WriteLine(context.CurrentMessage);

            context.Word.PrintTheWord();

            context.CurrentMessage = GameContext.PromptForCommand;
            Console.WriteLine(context.CurrentMessage);
        }
    }
}
