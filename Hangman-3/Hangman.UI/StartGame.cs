namespace Hangman.UI
{
    using Hangman.Logic;

    /// <summary>
    /// Entry point of the game.
    /// </summary>
    public class StartGame
    {
        public static void Main()
        {
            var game = HangmanGame.Instance;
            game.Run();
        }
    }
}
