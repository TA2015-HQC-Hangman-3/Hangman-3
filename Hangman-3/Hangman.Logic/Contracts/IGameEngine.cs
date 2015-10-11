// <copyright file="IGameEngine.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface IGameEngine.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Contracts
{
    /// <summary>
    /// Declares the method for each game engine object.
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        /// Provides the game starting.
        /// </summary>
        void Run();
    }
}
