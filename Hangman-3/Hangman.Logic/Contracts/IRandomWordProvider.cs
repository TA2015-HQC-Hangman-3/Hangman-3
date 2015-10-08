namespace Hangman
{
    using Hangman.Logic.Contracts;

    public interface IRandomWordProvider
    {
        IWord GetWord();
    }
}
