namespace Hangman.Logic
{
    using System.Collections.Generic;

    public class ComparerSorter : ISorter
    {
        public List<KeyValuePair<string, int>> Sort(List<KeyValuePair<string, int>> scores)
        {
            scores.Sort(new OutComparer());
            return scores;
        }
    }
}
