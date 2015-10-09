namespace Hangman.Logic.Contracts
{
    using Hangman.Logic.SaveLoad;

    public interface ISaveLoadManager
    {
        Memento GameState { get; set; }

        void SaveGame();

        void LoadGame();
    }
}
