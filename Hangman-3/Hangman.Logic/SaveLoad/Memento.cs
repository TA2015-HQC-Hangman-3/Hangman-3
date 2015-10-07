namespace Hangman.Logic.SaveLoad
{
    public class Memento
    {
        public HangmanWord Word { get; set; }

        public int CurrentMistakes { get; set; }

        public bool HasCheated { get; set; }

        public bool IsGameRunning { get; set; }
    }
}
