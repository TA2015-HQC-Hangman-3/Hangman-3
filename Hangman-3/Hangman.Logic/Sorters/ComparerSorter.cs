namespace Hangman.Logic.Sorters
{
    using System.Collections.Generic;
    using System.Linq;

    public class ComparerSorter : ISorter
    {
        public IEnumerable<KeyValuePair<string, int>> Sort(IEnumerable<KeyValuePair<string, int>> scores)
        {
            // scores.Sort(new OutComparer());
            // return scores;
            return scores.OrderBy(score => score.Value);
        }
    }
}
