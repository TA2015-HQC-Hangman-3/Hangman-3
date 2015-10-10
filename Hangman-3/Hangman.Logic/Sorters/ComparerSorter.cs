namespace Hangman.Logic.Sorters
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Arranging by comparison, provides method for sorting.
    /// </summary>
    public class ComparerSorter : ISorter
    {
        /// <summary>
        /// Sorting by numeric values - scores.
        /// </summary>
        /// <param name="scores">Representation of the scores collection to be sorted.</param>
        /// <returns>The sorted collection.</returns>
        public IEnumerable<KeyValuePair<string, int>> Sort(IEnumerable<KeyValuePair<string, int>> scores)
        {
            return scores.OrderBy(score => score.Value);
        }
    }
}
