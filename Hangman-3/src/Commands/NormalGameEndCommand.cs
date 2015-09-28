namespace Hangman.Commands
{
    using System;

    public class NormalGameEndCommand : IHangmanCommand
    {
        public void Execute(GameContext context)
        {
            context.CurrentMessage = string.Format(GameContext.WinMessage, context.CurrentMistakes);
            Console.WriteLine(context.CurrentMessage);
            context.Word.PrintTheWord();

            context.CurrentMessage = GameContext.PromptForUserName;
            Console.WriteLine(context.CurrentMessage);
            context.Scoreboard.AddScore(context.CurrentMistakes);

            context.Scoreboard.PrintScore();

            context.CurrentMessage = GameContext.PromptForCommand;
            Console.WriteLine(context.CurrentMessage);
        }
    }
}
