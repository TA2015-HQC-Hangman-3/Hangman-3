namespace Hangman.UI
{
    using Commands;

    public class StartGame
    {
        public static void Main()
        {
            var game = HangmanGame.Instance;
            game.Run();
        }
    }
}
