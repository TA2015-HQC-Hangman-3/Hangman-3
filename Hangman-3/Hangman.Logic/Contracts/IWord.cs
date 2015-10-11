// <copyright file="IWord.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface IWord.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Declares the methods of each word in the game.
    /// </summary>
    public interface IWord
    {
        /// <summary>
        /// Checks if the letter is guessed for the first time.
        /// </summary>
        /// <param name="letter">The letter to be checked.</param>
        /// <returns>True, if the letter was guessed and false, if it was not.</returns>       
        bool IsLetterGuessedForFirstTime(string letter);

        /// <summary>
        /// Show the word as underlines.
        /// </summary>
        /// <param name="printer">The object to print it on the screen.</param>      
        void PrintTheWord(IPrinter printer);

        /// <summary>
        /// Provides the word to be guessed as underlines.
        /// </summary>
        /// <returns>A collection of underlines. Its length is the same as the word's. </returns>
        char[] GenerateHiddenWord();

        /// <summary>
        /// Checks if the word is guessed.
        /// </summary>
        /// <returns>True, if the word was guessed and false, if it was not.</returns>     
        bool IsWordGuessed();

        /// <summary>
        /// Checks if the letter is in the word.
        /// </summary>
        /// <param name="letter">The letter checked for.</param>
        /// <returns>True, if the letter was in the word and false, if it was not.</returns>
        bool IsLetterInTheWord(string letter);

        /// <summary>
        /// Calculates the number of same letters that were guessed in a word.
        /// </summary>
        /// <param name="letter">The letter to be counted.</param>
        /// <returns>The count of letters in the word.</returns>
        int GetNumberOfLettersThatAreGuessed(string letter);

        /// <summary>
        /// Generates hidden word of underlines.
        /// </summary>
        void GetNextUnknownLetterOfWord();

        /// <summary>
        /// Generates a list of all tried letters.
        /// </summary>
        /// <returns>A collection of the letters.</returns>
        List<char> GetAllTriedLetters();
    }
}
