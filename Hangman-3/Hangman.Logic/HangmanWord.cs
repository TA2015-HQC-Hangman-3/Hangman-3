namespace Hangman
{
    using System;
    using System.Collections.Generic;

<<<<<<< HEAD
    /// <summary>
    /// Class representing a word in the game that should be guessed. 
    /// </summary>
    public class HangmanWord
=======
    using Logic.Contracts;

    public class HangmanWord : IWord
>>>>>>> b6e5466bce575ebb4498be25c79f1bf7c40f1770
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
            this.HiddenWord = this.GenerateHiddenWord();
            this.ListOfLettersTried = new List<char>();
        }

        public List<char> ListOfLettersTried { get; set; }

        public char[] HiddenWord { get; set; }

        public string TheChosenWord { get; set; }

<<<<<<< HEAD
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
=======
>>>>>>> b6e5466bce575ebb4498be25c79f1bf7c40f1770

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
            for (int i = 0; i < this.HiddenWord.Length; i++)
            {
                Console.Write("{0} ", this.HiddenWord[i]);
            }

            Console.WriteLine();
        }

<<<<<<< HEAD
        /// <summary>
        /// Method that generates an unknown word - represents it as underlines.
        /// </summary>
        /// <returns>Collection of the exact count of letters as underlines.</returns>
        public char[] GenerateUnknownWord()
=======
        public char[] GenerateHiddenWord()
>>>>>>> b6e5466bce575ebb4498be25c79f1bf7c40f1770
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
        /// method for checking if the word is guessed.
        /// </summary>
        /// <returns>True or false.</returns>
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
        /// Method for cheking of the proposed letter is in the word.
        /// </summary>
        /// <param name="letter">The proposed letter.</param>
        /// <returns>True or false.</returns>
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
        /// Method for counting how many letters are guessed.
        /// </summary>
        /// <param name="letter">The guessed letter.</param>
        /// <returns>Number of right guesses.</returns>
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
        /// Method for creating unknown words.
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

        public List<char> GetAllTriedLetters()
        {
            return this.ListOfLettersTried;
        }

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
