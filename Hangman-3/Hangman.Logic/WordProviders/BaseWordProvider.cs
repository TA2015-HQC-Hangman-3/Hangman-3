using Hangman.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Logic.WordProviders
{
    public abstract class BaseWordProvider:IWordProvider
    {
        protected IEnumerable<string> AvailableWords {get; set;}

        private static Random rand = new Random();

        public IWord GetWord()
        {
            var index = rand.Next(0, this.AvailableWords.Count());
            var theChosenWord = this.AvailableWords.ElementAt(index);
            return new HangmanWordProxy(theChosenWord);
        }
    }
}
