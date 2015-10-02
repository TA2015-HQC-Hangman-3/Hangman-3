namespace Hangman.Commands
{
    public class ShowScoreboardCommand : IHangmanCommand
    {
        public void Execute(GameContext context)
        {
            context.Scoreboard.PrintScore();
        }
    }
}
