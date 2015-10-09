namespace Hangman.Logic
{
    using Hangman.Logic.SaveLoad;

    /// <summary>
    /// Interface stating that a game context must have Word, Scoreboard,
    /// Current Mistakes count, if it was cheated, if the game is running and the current message.
    /// Also methods for: Load, Save and Reset.
    /// </summary>
    public interface IGameContext
    {
        HangmanWord Word { get; set; }

        Scoreboard Scoreboard { get; set; }

        int CurrentMistakes { get; set; }

        bool HasCheated { get; set; }

        bool IsGameRunning { get; set; }

        string CurrentMessage { get; set; }

        void Reset();

        Memento Save();

        void Load(Memento gameState);
    }
}
