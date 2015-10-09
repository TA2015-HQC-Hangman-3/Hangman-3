namespace Hangman
{
    using System;

    using Logic;
    using Hangman.Logic.Contracts;

    public class SimpleRandomWordProvider : IWordProvider
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

        public IWord GetWord()
        {
            var theChosenWord = this.availableWords[rand.Next(0, this.availableWords.Length)];
            return new HangmanWordProxy(theChosenWord);
        }
    }
}
