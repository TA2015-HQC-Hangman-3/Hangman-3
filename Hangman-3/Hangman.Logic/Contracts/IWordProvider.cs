// <copyright file="IWordProvider.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface IWordProvider.</summary>
// <author>Team Hangman 3</author>
namespace Hangman
{
    using Hangman.Logic.Contracts;

    /// <summary>
    /// Declares the method for each word provider.
    /// </summary>
    public interface IWordProvider
    {
        /// <summary>
        /// Provides with a word.
        /// </summary>
        /// <returns>The word for the game.</returns>
        IWord GetWord();
    }
}
