namespace Hangman.Commands
{
    public interface IHangmanCommand
    {
        void Execute(GameContext context);
    }
}
