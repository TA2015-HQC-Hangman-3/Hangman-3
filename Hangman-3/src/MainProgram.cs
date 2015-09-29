namespace Hangman
{
    using Commands;

    public class MainProgram
    {
        static void Main()
        {
            var context = new GameContext(new SimpleRandomWordProvider(), new Scoreboard());
            var game = new HangmanGame(context, new CommandFactory());
            game.Run();
        }
    }
}
