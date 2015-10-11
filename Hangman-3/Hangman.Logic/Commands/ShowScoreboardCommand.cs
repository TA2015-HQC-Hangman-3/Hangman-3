// <copyright file="ShowScoreboardCommand.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Class ShowScoreboardCommand.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    /// <summary>
    /// Represents object for showing scoreboard of the game of type command. 
    /// </summary>
    public class ShowScoreboardCommand : IHangmanCommand
    {
        /// <summary>
        /// Implements the execution of the showing scoreboard game command.
        /// </summary>
        /// <param name="context">The game context for the execution of the commands.</param>
        public void Execute(IGameContext context)
        {
            context.Scoreboard.PrintScore();
        }
    }
}
