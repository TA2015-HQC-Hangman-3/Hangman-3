// <copyright file="IGameContext.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface IGameContext.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic
{
    using Hangman.Logic.Contracts;
    using Hangman.Logic.SaveLoad;

    /// <summary>
    /// Declares the methods and properties of the game.
    /// </summary>
    public interface IGameContext
    {
        /// <summary>
        /// Gets or sets the word for the game.
        /// </summary>
        /// <value>The value is of type <see cref="IWord"/>.</value>
        IWord Word { get; set; }

        /// /// <summary>
        /// Gets or sets the scoreboard for the game.
        /// </summary>
        /// <value>The value is of type <see cref="Scoreboard"/>.</value> 
        IScoreboard Scoreboard { get; set; }

        /// <summary>
        /// Gets or sets the number of mistakes.
        /// </summary>
        /// <value>The value is of type integer.</value>
        int CurrentMistakes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it was cheated.
        /// </summary>
        /// <value>The value is of type boolean.</value>
        bool HasCheated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether game is running.
        /// </summary>
        /// <value>The value is of type boolean.</value>
        bool IsGameRunning { get; set; }

        /// <summary>
        /// Gets or sets the current message.
        /// </summary>
        /// <value>The value is of type string.</value>
        string CurrentMessage { get; set; }

        /// <summary>
        /// Resets the game.
        /// </summary>
        void Reset();

        /// <summary>
        /// Saves the current game state.
        /// </summary>
        /// <returns>Object with the game context.</returns>
        Memento Save();

        /// <summary>
        /// Loads the game.
        /// </summary>
        /// <param name="gameState">The state from which the game is loaded.</param>
        void Load(Memento gameState);
    }
}
