namespace Hangman
{
    using System;
    using System.Collections.Generic;

    using Logic.Contracts;

    public class HangmanWord : IWord
    {
        public const int LowerBoundaryFromTheAsciiTable = 97;
        public const int UpperBoundaryFromTheAsciiTable = 122;
        private string theChosenWord;

        public HangmanWord()
        {
        }

        public HangmanWord(string chosenWord)
        {
            this.TheChosenWord = chosenWord;
            this.HiddenWord = this.GenerateHiddenWord();
            this.ListOfLettersTried = new List<char>();
        }

        public List<char> ListOfLettersTried { get; set; }

        public char[] HiddenWord { get; set; }

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

        public void PrintTheWord()
        {
            Console.Write("The secret word is: ");
            for (int i = 0; i < this.HiddenWord.Length; i++)
            {
                Console.Write("{0} ", this.HiddenWord[i]);
            }

            Console.WriteLine();
        }

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
