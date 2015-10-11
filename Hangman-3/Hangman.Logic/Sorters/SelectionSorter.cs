// <copyright file="SelectionSorter.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Class SelectionSorter.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Sorters
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Arranging by selection, provides method for sorting.
    /// </summary>
    public class SelectionSorter : ISorter
    {
        /// <summary>
        /// Sorting by numeric values.
        /// </summary>
        /// <param name="scores">The scores to be sorted.</param>
        /// <returns>The sorted collection.</returns>
        public IEnumerable<KeyValuePair<string, int>> Sort(IEnumerable<KeyValuePair<string, int>> scores)
        {
            var scoresToSort = scores.ToList();

            // pos_min is short for position of min
            int minPosition;
            KeyValuePair<string, int> changer;

            for (int i = 0; i < scoresToSort.Count - 1; i++)
            {
                minPosition = i; // set pos_min to the current index of array
                for (int j = i + 1; j < scoresToSort.Count; j++)
                {
                    if (scoresToSort[j].Value < scoresToSort[minPosition].Value)
                    {
                        // pos_min will keep track of the index that min is in, this is needed when a swap happens
                        minPosition = j;
                    }
                }

                // if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                if (minPosition != i)
                {
                    changer = scoresToSort[i];
                    scoresToSort[i] = scoresToSort[minPosition];
                    scoresToSort[minPosition] = changer;
                }
            }

            return scoresToSort;
        }
    }
}
