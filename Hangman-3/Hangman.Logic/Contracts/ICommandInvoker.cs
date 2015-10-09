namespace Hangman.Logic.Contracts
{
    using Commands;

    /// <summary>
    /// Interface declaring every command invoker should contain ExecuteCommand method.
    /// </summary>
    public interface ICommandInvoker
    {
        /// <summary>
        /// The method for executing any command should be implemented.
        /// </summary>
        /// <param name="command">Specifying the command.</param>
        /// <param name="context">Specifying the game context object.</param>
        void ExecuteCommand(IHangmanCommand command, IGameContext context);
    }
}
