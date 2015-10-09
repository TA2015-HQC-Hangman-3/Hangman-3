namespace Hangman.Logic.Commands
{
    using Hangman.Logic;
    
    /// <summary>
    /// Interface for command, contains execute method.
    /// </summary>
    public interface IHangmanCommand
    {
        /// <summary>
        /// Execute method to be implemented.
        /// </summary>
        /// <param name="context">Accepts one parameter for game context.</param>
        void Execute(IGameContext context);
    }
}
