using System;

namespace Hangman
{
    public class HangmanWord
    {        
        public HangmanWord(string chosenWord)
        {
            this.TheChosenWord = chosenWord;
            this.UnknownWord = this.GenerateUnknownWord();
        }

        public char[] UnknownWord { get; set; }
        public string TheChosenWord { get; set; }

        public bool IsValidLetter(string input)
        {
            char enteredSymbol;
            if ((char.TryParse(input, out enteredSymbol)) &&
                ((int)enteredSymbol >= 97 && (int)enteredSymbol <= 122))
            {
                return true;
            }
            return false;
        }

        public void PrintTheWord()
        {
            Console.Write("The secret word is: ");
            for (int i = 0; i < this.UnknownWord.Length; i++)
            {
                Console.Write("{0} ", this.UnknownWord[i]);
            }
            Console.WriteLine();
        }

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

        public bool IsLetterInTheWord(string letter)
        {
            bool isLetterInTheWord = false;
            char enteredSymbol = char.Parse(letter);
            for (int i = 0; i < this.UnknownWord.Length; i++)
            {
                if (TheChosenWord[i] == enteredSymbol)
                {
                    this.UnknownWord[i] = enteredSymbol;
                    isLetterInTheWord = true;
                }
            }

            return isLetterInTheWord;
        }

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
