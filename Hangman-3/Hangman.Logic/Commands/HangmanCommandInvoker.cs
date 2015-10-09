namespace Hangman.Logic.Commands
{
    using Contracts;

    /// <summary>
    /// Class for executing commands.
    /// </summary>
    public class HangmanCommandInvoker : ICommandInvoker
    {
        /// <summary>
        /// Method for executing command.
        /// </summary>
        /// <param name="command">The command that should be executed.</param>
        /// <param name="context">The game context of the command.</param>
        public void ExecuteCommand(IHangmanCommand command, IGameContext context)
        {
            command.Execute(context);
        }
    }
}
