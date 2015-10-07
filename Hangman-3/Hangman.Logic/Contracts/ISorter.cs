namespace Hangman.Logic
{
    using System.Collections.Generic;

    public interface ISorter
    {
        IEnumerable<KeyValuePair<string, int>> Sort(IEnumerable<KeyValuePair<string, int>> scores);
    }
}