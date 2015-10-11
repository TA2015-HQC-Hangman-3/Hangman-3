// <copyright file="HangmanWord.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Class HangmanWord.</summary>
// <author>Team Hangman 3</author>
namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Logic.Contracts;

    /// <summary>
    /// Representing the words used in Hangman game.
    /// </summary>
    public class HangmanWord : IWord
    {
        private string theChosenWord;

        /// <summary>
        /// Initializes a new instance of the <see cref="HangmanWord"/> class.
        /// </summary>
        public HangmanWord()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HangmanWord"/> class.
        /// </summary>
        /// <param name="chosenWord">The word for the current game.</param>
        public HangmanWord(string chosenWord)
        {
            this.TheChosenWord = chosenWord;
            this.HiddenWord = this.GenerateHiddenWord();
            this.ListOfLettersTried = new List<char>();
        }

        /// <summary>
        /// Gets or sets a collection of all letters tried.
        /// </summary>
        /// <value>Returns all currently tried letters.</value>
        public List<char> ListOfLettersTried { get; set; }

        /// <summary>
        /// Gets or sets a word of underlines.
        /// </summary>
        /// <value>Returns a set of underlines.</value>
        public char[] HiddenWord { get; set; }

        /// <summary>
        /// Gets or sets the word for the game.
        /// </summary>
        /// <value>Returns the chosen word.</value>
        public string TheChosenWord
        {
            get
            {
                return this.theChosenWord;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Invalid value for word");
                }

                this.theChosenWord = value;
            }
        }

        /// <summary>
        /// Checks if the letter is guessed for the first time.
        /// </summary>
        /// <param name="letter">The letter to be checked.</param>
        /// <returns>True, if the letter was guessed and false, if it was not.</returns>
        public bool IsLetterGuessedForFirstTime(string letter)
        {
            char enteredLetter = Convert.ToChar(letter);
            if (this.ListOfLettersTried.Contains(enteredLetter))
            {
                return false;
            }

            this.ListOfLettersTried.Add(enteredLetter);
            return true;
        }

        /// <summary>
        /// Show the word as underlines.
        /// </summary>
        /// <param name="printer">The object to print it on the screen.</param>
        public void PrintTheWord(IPrinter printer)
        {
            printer.Print("The secret word is: ");
            var wordAsString = string.Join(" ", this.HiddenWord);
            printer.Print(wordAsString + " ");
            printer.PrintLine();
        }

        /// <summary>
        /// Provides the word to be guessed as underlines.
        /// </summary>
        /// <returns>A collection of underlines. Its length is the same as the word's. </returns>
        public char[] GenerateHiddenWord()
        {
            var lengthOfTheWord = this.TheChosenWord.Length;
            var hiddenWord = new char[lengthOfTheWord];
            for (int i = 0; i < lengthOfTheWord; i++)
            {
                hiddenWord[i] = '_';
            }

            return hiddenWord;
        }

        /// <summary>
        /// Checks if the word is guessed.
        /// </summary>
        /// <returns>True, if the word was guessed and false, if it was not.</returns>
        public bool IsWordGuessed()
        {
            return !this.HiddenWord.Any(ch => ch == '_');
        }

        /// <summary>
        /// Checks if the letter is in the word.
        /// </summary>
        /// <param name="letter">The letter checked for.</param>
        /// <returns>True, if the letter was in the word and false, if it was not.</returns>
        public bool IsLetterInTheWord(string letter)
        {
            bool isLetterInTheWord = false;
            char enteredSymbol = char.Parse(letter);
            for (int i = 0; i < this.HiddenWord.Length; i++)
            {
                if (this.TheChosenWord[i] == enteredSymbol)
                {
                    this.HiddenWord[i] = enteredSymbol;
                    isLetterInTheWord = true;
                }
            }

            return isLetterInTheWord;
        }

        /// <summary>
        /// Calculates the number of same letters that were guessed in a word.
        /// </summary>
        /// <param name="letter">The letter to be counted.</param>
        /// <returns>The count of letters in the word.</returns>
        public int GetNumberOfLettersThatAreGuessed(string letter)
        {
            var lettersGuessed = 0;
            char enteredSymbol = char.Parse(letter);
            for (int i = 0; i < this.HiddenWord.Length; i++)
            {
                if (this.TheChosenWord[i] == enteredSymbol)
                {
                    lettersGuessed++;
                }
            }

            return lettersGuessed;
        }

        /// <summary>
        /// Generates hidden word of underlines.
        /// </summary>
        public void GetNextUnknownLetterOfWord()
        {
            for (int i = 0; i < this.HiddenWord.Length; i++)
            {
                if (this.HiddenWord[i] == '_')
                {
                    this.HiddenWord[i] = this.TheChosenWord[i];
                    break;
                }
            }
        }

        /// <summary>
        /// Generates a list of all tried letters.
        /// </summary>
        /// <returns>A collection of the letters.</returns>
        public List<char> GetAllTriedLetters()
        {
            return this.ListOfLettersTried;
        }

        /// <summary>
        /// Checks if this is the chosen word.
        /// </summary>
        /// <param name="obj">The word to be checked.</param>
        /// <returns>True, if it is the chosen word and false, if it was not.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            HangmanWord word = obj as HangmanWord;
            if (word == null)
            {
                return false;
            }

            return this.TheChosenWord == word.TheChosenWord;
        }
    }
}
