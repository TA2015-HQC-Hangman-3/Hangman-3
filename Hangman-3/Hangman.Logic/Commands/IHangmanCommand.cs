namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    public interface IHangmanCommand
    {
        void Execute(IGameContext context);
    }
}
