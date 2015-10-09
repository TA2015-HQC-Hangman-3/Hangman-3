namespace Hangman.Logic
{
    using System;

    using Contracts;
    using System.Collections.Generic; 

    public  class HangmanWordProxy : IWord
    {
        private const int LowerBoundaryFromTheAsciiTable = 97;
        private const int UpperBoundaryFromTheAsciiTable = 122;
        
        public HangmanWordProxy()
        {
        }

        public HangmanWordProxy(string chosenWord)
        {
            this.Word = new HangmanWord(chosenWord);
        }

        public HangmanWord Word{ get; set; }

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

        public void PrintTheWord()
        {
            this.Word.PrintTheWord();
        }

        public char[] GenerateHiddenWord()
        {
            return this.Word.GenerateHiddenWord();
        }

        public bool IsWordGuessed()
        {
            return this.Word.IsWordGuessed();
        }

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

        public void GetNextUnknownLetterOfWord()
        {
            this.Word.GetNextUnknownLetterOfWord();
        }

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

        public List<char> GetAllTriedLetters()
        {
            return this.Word.ListOfLettersTried;
        }

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
    }
}
