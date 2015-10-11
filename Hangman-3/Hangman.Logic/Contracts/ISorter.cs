// <copyright file="ISorter.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface ISorter.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic
{
    using System.Collections.Generic;

    public interface ISorter
    {
        IEnumerable<KeyValuePair<string, int>> Sort(IEnumerable<KeyValuePair<string, int>> scores);
    }
}