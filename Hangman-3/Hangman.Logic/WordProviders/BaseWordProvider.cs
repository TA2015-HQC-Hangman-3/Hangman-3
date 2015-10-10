namespace Hangman.Logic.WordProviders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Hangman.Logic.Contracts;

    /// <summary>
    /// Represents word provider and contains method for getting a word.
    /// </summary>
    public abstract class BaseWordProvider : IWordProvider
    {
        private static Random rand = new Random();

        protected IEnumerable<string> AvailableWords { get; set; }

        /// <summary>
        /// Gets a word.
        /// </summary>
        /// <returns>A word of type IWord</returns>
        public IWord GetWord()
        {
            var index = rand.Next(0, this.AvailableWords.Count());
            var theChosenWord = this.AvailableWords.ElementAt(index);
            return new HangmanWordProxy(theChosenWord);
        }
    }
}
