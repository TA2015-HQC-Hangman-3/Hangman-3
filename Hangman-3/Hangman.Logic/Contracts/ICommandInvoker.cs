namespace Hangman.Logic.Contracts
{
    using Commands;

    public interface ICommandInvoker
    {
        void ExecuteCommand(IHangmanCommand command, IGameContext context);
    }
}
