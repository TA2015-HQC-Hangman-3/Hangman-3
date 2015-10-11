// <copyright file="IWordProvider.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface IWordProvider.</summary>
// <author>Team Hangman 3</author>
namespace Hangman
{
    using Hangman.Logic.Contracts;

    public interface IWordProvider
    {
        IWord GetWord();
    }
}
