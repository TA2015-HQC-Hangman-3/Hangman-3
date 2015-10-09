namespace Hangman
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class representing a word in the game that should be guessed. 
    /// </summary>
    public class HangmanWord
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
        /// <param name="chosenWord">Accepts parameter from type string to be the chosen word.</param>
        public HangmanWord(string chosenWord)
        {
            this.TheChosenWord = chosenWord;
            this.UnknownWord = this.GenerateUnknownWord();
            this.ListOfLettersTried = new List<char>();
        }

        public List<char> ListOfLettersTried { get; set; }

        public char[] UnknownWord { get; set; }

        public string TheChosenWord { get; set; }

        /// <summary>
        /// Validation of the letter entered.
        /// </summary>
        /// <param name="input">The letter entered.</param>
        /// <returns>True or False.</returns>
        public bool IsValidLetter(string input)
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

        /// <summary>
        /// Method for evaluating if the letter is guessed from the first time.
        /// </summary>
        /// <param name="letter">The letter guessed.</param>
        /// <returns>true or False.</returns>
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
        /// Method that prints the word that must be guessed anonymously.
        /// </summary>
        public void PrintTheWord()
        {
            Console.Write("The secret word is: ");
            for (int i = 0; i < this.UnknownWord.Length; i++)
            {
                Console.Write("{0} ", this.UnknownWord[i]);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Method that generates an unknown word - represents it as underlines.
        /// </summary>
        /// <returns>Collection of the exact count of letters as underlines.</returns>
        public char[] GenerateUnknownWord()
        {
            var lengthOfTheWord = this.TheChosenWord.Length;
            var unknownWord = new char[lengthOfTheWord];
            for (int i = 0; i < lengthOfTheWord; i++)
            {
                unknownWord[i] = '_';
            }

            return unknownWord;
        }

        /// <summary>
        /// method for checking if the word is guessed.
        /// </summary>
        /// <returns>True or false.</returns>
        public bool IsWordGuessed()
        {
            for (int i = 0; i < this.UnknownWord.Length; i++)
            {
                if (this.UnknownWord[i] == '_')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Method for cheking of the proposed letter is in the word.
        /// </summary>
        /// <param name="letter">The proposed letter.</param>
        /// <returns>True or false.</returns>
        public bool IsLetterInTheWord(string letter)
        {
            bool isLetterInTheWord = false;
            char enteredSymbol = char.Parse(letter);
            for (int i = 0; i < this.UnknownWord.Length; i++)
            {
                if (this.TheChosenWord[i] == enteredSymbol)
                {
                    this.UnknownWord[i] = enteredSymbol;
                    isLetterInTheWord = true;
                }
            }

            return isLetterInTheWord;
        }

        /// <summary>
        /// Method for counting how many letters are guessed.
        /// </summary>
        /// <param name="letter">The guessed letter.</param>
        /// <returns>Number of right guesses.</returns>
        public int GetNumberOfLettersThatAreGuessed(string letter)
        {
            var lettersGuessed = 0;
            char enteredSymbol = char.Parse(letter);
            for (int i = 0; i < this.UnknownWord.Length; i++)
            {
                if (this.TheChosenWord[i] == enteredSymbol)
                {
                    lettersGuessed++;
                }
            }

            return lettersGuessed;
        }

        /// <summary>
        /// Method for creating unknown words.
        /// </summary>
        public void GetNextUnknownLetterOfWord()
        {
            for (int i = 0; i < this.UnknownWord.Length; i++)
            {
                if (this.UnknownWord[i] == '_')
                {
                    this.UnknownWord[i] = this.TheChosenWord[i];
                    break;
                }
            }
        }
    }
}
