namespace Hangman.Logic.SaveLoad
{
    /// <summary>
    /// Provides a state of the game.
    /// </summary>
    public class Memento
    {
        public HangmanWordProxy Word { get; set; }

        public int CurrentMistakes { get; set; }

        public bool HasCheated { get; set; }

        public bool IsGameRunning { get; set; }
    }
}
