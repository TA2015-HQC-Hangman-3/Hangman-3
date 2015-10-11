// <copyright file="Memento.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Class Memento.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.SaveLoad
{
    /// <summary>
    /// Provides a state of the game.
    /// </summary>
    public class Memento
    {
        /// <summary>
        /// Gets or sets a word for the game state.
        /// </summary>
        /// <value>Returns a Word.</value>
        public HangmanWordProxy Word { get; set; }

        /// <summary>
        /// Gets or sets number of mistakes for the game state.
        /// </summary>
        /// <value>Returns the current mistakes count.</value>
        public int CurrentMistakes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player has cheated.
        /// </summary>
        /// <value>Returns bool value, whether the player has cheated or not.</value>
        public bool HasCheated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the game is running.
        /// </summary>
        /// <value>Returns bool value, whether the game is running or not.</value>
        public bool IsGameRunning { get; set; }
    }
}
