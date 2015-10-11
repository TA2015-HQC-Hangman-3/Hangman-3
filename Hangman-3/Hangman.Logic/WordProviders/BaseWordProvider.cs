// <copyright file="BaseWordProvider.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Class BaseWordProvider.</summary>
// <author>Team Hangman 3</author>
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

        /// <summary>
        /// Gets or sets the Available words.
        /// </summary>
        /// <value>Returns the available words.</value>
        protected IEnumerable<string> AvailableWords { get; set; }

        /// <summary>
        /// Gets a word.
        /// </summary>
        /// <returns>A word of type IWord.</returns>
        public IWord GetWord()
        {
            var index = rand.Next(0, this.AvailableWords.Count());
            var theChosenWord = this.AvailableWords.ElementAt(index);
            return new HangmanWordProxy(theChosenWord);
        }
    }
}
