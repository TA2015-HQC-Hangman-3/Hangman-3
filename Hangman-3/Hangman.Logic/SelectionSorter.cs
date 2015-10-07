namespace Hangman.Logic
{
    using System.Collections.Generic;

    public class SelectionSorter : ISorter
    {
        public List<KeyValuePair<string, int>> Sort(List<KeyValuePair<string, int>> scores)
        {
            // pos_min is short for position of min
            int minPosition;
            KeyValuePair<string, int> changer;

            for (int i = 0; i < scores.Count - 1; i++)
            {
                minPosition = i; // set pos_min to the current index of array
                for (int j = i + 1; j < scores.Count; j++)
                {
                    if (scores[j].Value < scores[minPosition].Value)
                    {
                        // pos_min will keep track of the index that min is in, this is needed when a swap happens
                        minPosition = j;
                    }
                }

                // if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                if (minPosition != i)
                {
                    changer = scores[i];
                    scores[i] = scores[minPosition];
                    scores[minPosition] = changer;
                }
            }

            return scores;
        }
    }
}
