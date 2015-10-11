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
        public HangmanWordProxy Word { get; set; }

        /// <summary>
        /// Gets or sets number of mistakes for the game state.
        /// </summary>
        public int CurrentMistakes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player has cheated.
        /// </summary>
        public bool HasCheated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the game is running.
        /// </summary>
        public bool IsGameRunning { get; set; }
    }
}
