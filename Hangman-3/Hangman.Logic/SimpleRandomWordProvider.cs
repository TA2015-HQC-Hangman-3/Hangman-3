namespace Hangman
{
    using System;

    using Logic;
    using Hangman.Logic.Contracts;

    public sealed class SimpleRandomWordProvider : IWordProvider
    {
        private static Random rand = new Random();

        private static volatile SimpleRandomWordProvider randWordProviderInstance;
        private static object syncLock = new object();

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

        private SimpleRandomWordProvider()
        {

        }

        public static SimpleRandomWordProvider Instance
        {
            get
            {
                if (randWordProviderInstance == null)
                {
                    lock (syncLock)
                    {
                        if (randWordProviderInstance == null)
                        {
                            randWordProviderInstance = new SimpleRandomWordProvider();
                        }
                    }
                }

                return randWordProviderInstance;
            }
        }

        public IWord GetWord()
        {
            var theChosenWord = this.availableWords[rand.Next(0, this.availableWords.Length)];
            return new HangmanWordProxy(theChosenWord);
        }
    }
}
