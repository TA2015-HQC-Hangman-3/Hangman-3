// <copyright file="ISorter.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface ISorter.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic
{
    using System.Collections.Generic;

    /// <summary>
    /// Declares the method for each sorting object in the game.
    /// </summary>
    public interface ISorter
    {
        /// <summary>
        /// Provides with sorting of a collection.
        /// </summary>
        /// <param name="scores">The scores to be sorted.</param>
        /// <returns>A sorted collection.</returns>
        IEnumerable<KeyValuePair<string, int>> Sort(IEnumerable<KeyValuePair<string, int>> scores);
    }
}