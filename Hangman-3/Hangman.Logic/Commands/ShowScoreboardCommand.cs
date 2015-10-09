namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    /// <summary>
    /// Class representing command to show scores.
    /// </summary>
    public class ShowScoreboardCommand : IHangmanCommand
    {
        /// <summary>
        /// Method for executing show scoreboard command.
        /// </summary>
        /// <param name="context">Accepts game context object as parameter.</param>
        public void Execute(IGameContext context)
        {
            context.Scoreboard.PrintScore();
        }
    }
}
