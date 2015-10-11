// <copyright file="HangmanCommandInvoker.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Class HangmanCommandInvoker.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Commands
{
    using Contracts;

    /// <summary>
    /// Representing the calling of any command in the game.
    /// </summary>
    public class HangmanCommandInvoker : ICommandInvoker
    {
        /// <summary>
        /// The execution of a command for specific game context.
        /// </summary>
        /// <param name="command">Represents the command executed.</param>
        /// <param name="context">Represents the specific game context.</param>
        public void ExecuteCommand(IHangmanCommand command, IGameContext context)
        {
            command.Execute(context);
        }
    }
}
