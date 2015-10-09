namespace Hangman.Logic.Contracts
{
    using Hangman.Logic.SaveLoad;

    /// <summary>
    /// Interface stating that all save/load managers in the game must have Game State and implement methods for:
    /// - saving the game state
    /// - loading the game from previous state
    /// </summary>
    public interface ISaveLoadManager
    {
        Memento GameState { get; set; }

        void SaveGame();

        void LoadGame();
    }
}
