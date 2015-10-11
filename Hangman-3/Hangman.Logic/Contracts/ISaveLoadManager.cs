// <copyright file="ISaveLoadManager.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface ISaveLoadManager.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Contracts
{
    using Hangman.Logic.SaveLoad;

    /// <summary>
    /// Declares methods for saving and loading of the game.
    /// </summary>
    public interface ISaveLoadManager
    {
        /// <summary>
        /// Gets or sets the game state.
        /// </summary>
        /// <value>The value is of type <see cref="Memento"/> class.</value>
        Memento GameState { get; set; }

        /// <summary>
        /// Saves the game state.
        /// </summary>
        void SaveGame();

        /// <summary>
        /// Loads the game from a game state.
        /// </summary>
        void LoadGame();
    }
}
