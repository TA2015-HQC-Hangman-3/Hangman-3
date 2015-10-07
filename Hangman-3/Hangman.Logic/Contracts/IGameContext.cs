namespace Hangman.Logic
{
    public interface IGameContext
    {
        HangmanWord Word { get; set; }

        Scoreboard Scoreboard { get; set; }

        int CurrentMistakes { get; set; }

        bool HasCheated { get; set; }

        bool IsGameRunning { get; set; }

        string CurrentMessage { get; set; }

        void Reset();

    }
}
