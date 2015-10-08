namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    public class ShowScoreboardCommand : IHangmanCommand
    {
        public void Execute(IGameContext context)
        {
            context.Scoreboard.PrintScore();
        }
    }
}
