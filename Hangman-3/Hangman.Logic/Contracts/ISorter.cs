namespace Hangman.Logic
{
    using System.Collections.Generic;

    public interface ISorter
    {
        List<KeyValuePair<string, int>> Sort(List<KeyValuePair<string, int>> scores);
    }
}