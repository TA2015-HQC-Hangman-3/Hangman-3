// <copyright file="ICommandInvoker.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface ICommandInvoker.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Contracts
{
    using Commands;

    /// <summary>
    /// Declares the methods for each command invoker.
    /// </summary>
    public interface ICommandInvoker
    {
        /// <summary>
        /// Provides command execution.
        /// </summary>
        /// <param name="command">Specifies the command to be executed.</param>
        /// <param name="context">Specifies the game context.</param>
        void ExecuteCommand(IHangmanCommand command, IGameContext context);
    }
}
