namespace Hangman.Logic
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface declaring that all Sorters in the game must implement Sort method.
    /// </summary>
    public interface ISorter
    {
        IEnumerable<KeyValuePair<string, int>> Sort(IEnumerable<KeyValuePair<string, int>> scores);
    }
}