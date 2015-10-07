
namespace Hangman.Commands
{
    using Hangman.Logic;

    public interface IHangmanCommand
    {
        void Execute(IGameContext context);
    }
}
