namespace Hangman
{
    using Hangman.Logic.Contracts;

    public interface IWordProvider
    {
        IWord GetWord();
    }
}
