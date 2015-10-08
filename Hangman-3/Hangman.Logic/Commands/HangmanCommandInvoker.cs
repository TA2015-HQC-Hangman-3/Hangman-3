namespace Hangman.Logic.Commands
{
    using Contracts;

    public class HangmanCommandInvoker : ICommandInvoker
    {
        public void ExecuteCommand(IHangmanCommand command, IGameContext context)
        {
            command.Execute(context);
        }
    }
}
