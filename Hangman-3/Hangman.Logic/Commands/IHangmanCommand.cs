// <copyright file="IHangmanCommand.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface IHangmanCommand.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    /// <summary>
    /// Declares the method for each command object.
    /// </summary>
    public interface IHangmanCommand
    {
        /// <summary>
        /// Provides with command execution.
        /// </summary>
        /// <param name="context">The game context for the command.</param>
        void Execute(IGameContext context);
    }
}
