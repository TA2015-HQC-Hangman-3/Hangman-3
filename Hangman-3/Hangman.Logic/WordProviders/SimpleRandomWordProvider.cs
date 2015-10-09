namespace Hangman.Logic.WordProviders
{
    using System;

    using Logic;
    using Hangman.Logic.Contracts;

    public sealed class SimpleRandomWordProvider : BaseWordProvider
    {
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
            this.AvailableWords = this.availableWords;
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
    }
}
