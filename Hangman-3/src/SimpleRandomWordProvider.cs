namespace Hangman
{
    using System;

    public class SimpleRandomWordProvider : IRandomWordProvider
    {
        private static Random rand = new Random();

        private readonly string[] availableWords = {
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
            var theChosenWord = availableWords[rand.Next(0, availableWords.Length)];
            return new HangmanWord(theChosenWord);
        }
    }
}
