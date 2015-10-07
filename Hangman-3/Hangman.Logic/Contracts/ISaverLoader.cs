namespace Hangman.Logic.Contracts
{
    using Hangman.Logic.SaveLoad;

     public interface ISaverLoader
    {
         Memento GameState {get; set;}

         void SaveGame();

         void LoadGame();
    }
}
