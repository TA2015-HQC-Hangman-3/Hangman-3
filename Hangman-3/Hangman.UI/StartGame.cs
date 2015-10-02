namespace Hangman.UI
{
    using Commands;

    public class StartGame
    {
        public static void Main()
        {
            var printer = new ConsolePrinter();
            var context = new GameContext(new SimpleRandomWordProvider(), new Scoreboard(printer));
            var game = new HangmanGame(context, new CommandFactory(), printer);
            game.Run();
        }
    }
}
