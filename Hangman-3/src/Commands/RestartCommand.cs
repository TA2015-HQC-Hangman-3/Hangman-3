namespace Hangman.Commands
{
    using System;

    public class RestartCommand : IHangmanCommand
    {
        public void Execute(GameContext context)
        {
            Console.Clear();
            context.Reset();
            context.IsGameRunning = true;
            Console.WriteLine(context.CurrentMessage);
        }
    }
}
