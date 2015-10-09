namespace Hangman
{
    /// <summary>
    /// Interface stating that all word providers must have method for getting a word.
    /// </summary>
    public interface IRandomWordProvider
    {
        HangmanWord GetWord();
    }
}
