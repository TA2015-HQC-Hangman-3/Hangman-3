namespace Hangman.UI
{
    using Hangman.Logic;

    public class StartGame
    {
        public static void Main()
        {
            var game = HangmanGame.Instance;
            game.Run();
        }
    }
}
