namespace Hangman.Commands
{
    using System;

    public class ExitGameCommand : IHangmanCommand
    {
        public void Execute(GameContext context)
        {
            context.CurrentMessage = GameContext.GoodbyeMessage;
            Console.WriteLine(context.CurrentMessage);
            Environment.Exit(1);
        }
    }
}
