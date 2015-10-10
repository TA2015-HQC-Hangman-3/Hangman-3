namespace Hangman
{
    using System;
    using System.Collections.Generic;

    using Logic.Contracts;

    /// <summary>
    /// Representing the words used in Hangman game.
    /// </summary>
    public class HangmanWord : IWord
    {
        public const int LowerBoundaryFromTheAsciiTable = 97;
        public const int UpperBoundaryFromTheAsciiTable = 122;

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

        public List<char> ListOfLettersTried { get; set; }

        public char[] HiddenWord { get; set; }

        public string TheChosenWord { get; set; }

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
        public void PrintTheWord()
        {
            Console.Write("The secret word is: ");
            for (int i = 0; i < this.HiddenWord.Length; i++)
            {
                Console.Write("{0} ", this.HiddenWord[i]);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Providesthe word to be guessed as underlines.
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
            for (int i = 0; i < this.HiddenWord.Length; i++)
            {
                if (this.HiddenWord[i] == '_')
                {
                    return false;
                }
            }

            return true;
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
