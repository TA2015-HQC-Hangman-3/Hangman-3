namespace Hangman.Logic
{
    using System;
    using System.Collections.Generic; 
    using Contracts;

    /// <summary>
    /// Representing the words used in Hangman game.
    /// </summary>
    public class HangmanWordProxy : IWord
    {
        private const int LowerBoundaryFromTheAsciiTable = 97;
        private const int UpperBoundaryFromTheAsciiTable = 122;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="HangmanWordProxy"/> class.
        /// </summary>
        public HangmanWordProxy()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HangmanWord"/> class.
        /// </summary>
        /// <param name="chosenWord">The word for the current game.</param>
        public HangmanWordProxy(string chosenWord)
        {
            this.Word = new HangmanWord(chosenWord);
        }

        public HangmanWord Word { get; set; }

        /// <summary>
        /// Adds validation before checking if the letter is guessed for the first time.
        /// </summary>
        /// <param name="letter">The letter to be checked.</param>
        /// <returns>True, if the letter was guessed and false, if it was not.</returns>
        public bool IsLetterGuessedForFirstTime(string letter)
        {
            if (this.IsValidLetter(letter))
            {
                return this.Word.IsLetterGuessedForFirstTime(letter);
            }
            else
            {
                throw new ArgumentException(letter);
            }
        }

        /// <summary>
        /// Show the word as underlines. 
        /// </summary> 
        public void PrintTheWord()
        {
            this.Word.PrintTheWord();
        }

        /// <summary>
        /// Provides the word to be guessed as underlines using <see cref="HangmanWord"/> class.
        /// </summary>
        /// <returns>A collection of underlines. Its length is the same as the word's. </returns>
        public char[] GenerateHiddenWord()
        {
            return this.Word.GenerateHiddenWord();
        }

        /// <summary>
        /// Checks if the word is guessed.
        /// </summary>
        /// <returns>True, if the word was guessed and false, if it was not.</returns>
        public bool IsWordGuessed()
        {
            return this.Word.IsWordGuessed();
        }

        /// <summary>
        /// Adds validation before checking if the letter is in the word.
        /// </summary>
        /// <param name="letter">The letter checked for.</param>
        /// <returns>True, if the letter was in the word and false, if it was not.</returns>      
        public bool IsLetterInTheWord(string letter)
        {
            if (this.IsValidLetter(letter))
            {
                return this.Word.IsLetterInTheWord(letter);
            }
            else
            {
                throw new ArgumentException(letter);
            }
        }

        /// <summary>
        /// Validates the calculation of the number of same letters that were guessed in a word using <see cref="HangmanWord"/> class.
        /// </summary>
        /// <param name="letter">The letter to be counted.</param>
        /// <returns>The count of letters in the word.</returns> 
        public int GetNumberOfLettersThatAreGuessed(string letter)
        {
            if (this.IsValidLetter(letter))
            {
                return this.Word.GetNumberOfLettersThatAreGuessed(letter);
            }
            else
            {
                throw new ArgumentException(letter);
            }
        }

        /// <summary>
        /// Generates hidden word of underlines.
        /// </summary>
        public void GetNextUnknownLetterOfWord()
        {
            this.Word.GetNextUnknownLetterOfWord();
        }

        /// <summary>
        /// Generates a list of all tried letters.
        /// </summary>
        /// <returns>A collection of the letters.</returns>
        public List<char> GetAllTriedLetters()
        {
            return this.Word.ListOfLettersTried;
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

            HangmanWordProxy word = obj as HangmanWordProxy;
            if (word == null)
            {
                return false;
            }

            return this.Word.Equals(word.Word);
        }

        /// <summary>
        /// Validates if the letter is right.
        /// </summary>
        /// <param name="input">The letter provided.</param>
        /// <returns>True, if it is right a letter and false, if it is not.</returns>
        private bool IsValidLetter(string input)
        {
            char enteredSymbol;
            if (char.TryParse(input, out enteredSymbol) &&
                ((int)enteredSymbol >= LowerBoundaryFromTheAsciiTable &&
                 (int)enteredSymbol <= UpperBoundaryFromTheAsciiTable))
            {
                return true;
            }

            return false;
        }
    }
}
