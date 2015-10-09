namespace Hangman
{
    using System;

    /// <summary>
    /// Class representing random word provider. Contains list of available words and methods for randomly choosing one.
    /// </summary>
    public class SimpleRandomWordProvider : IRandomWordProvider
    {
        private static Random rand = new Random();

        private readonly string[] availableWords = 
                                                    {
                                                    "computer",
                                                    "programmer",
                                                    "software",
                                                    "debugger",
                                                    "compiler",
                                                    "developer",
                                                    "algorithm",
                                                    "array",
                                                    "method",
                                                    "variable"
                                                    };

        public HangmanWord GetWord()
        {
            var theChosenWord = this.availableWords[rand.Next(0, this.availableWords.Length)];
            return new HangmanWord(theChosenWord);
        }
    }
}
