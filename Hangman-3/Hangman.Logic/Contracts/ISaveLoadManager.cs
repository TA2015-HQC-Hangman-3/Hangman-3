// <copyright file="ISaveLoadManager.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface ISaveLoadManager.</summary>
// <author>Team Hangman 3</author>
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
