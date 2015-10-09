namespace Hangman.Logic.SaveLoad
{
    /// <summary>
    /// Class for saving  game states. Including
    /// - the word
    /// - Current mistakes
    /// - If the player has cheated.
    /// - is the game running
    /// </summary>
    public class Memento
    {
        public HangmanWord Word { get; set; }

        public int CurrentMistakes { get; set; }

        public bool HasCheated { get; set; }

        public bool IsGameRunning { get; set; }
    }
}
