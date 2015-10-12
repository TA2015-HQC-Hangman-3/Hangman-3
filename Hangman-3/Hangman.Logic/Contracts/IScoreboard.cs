// <copyright file="IScoreboard.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface IScoreboard.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Contracts
{
    /// <summary>
    /// Declares the methods for each scoreboard object.
    /// </summary>
    public interface IScoreboard
    {
        /// <summary>
        /// Adds a score to the scoreboard.
        /// </summary>
        /// <param name="mistakes">Number of mistakes the scorer has made.</param>
        void AddScore(int mistakes);

        /// <summary>
        /// Print the scoreboard.
        /// </summary>
        void PrintScore();
    }
}
