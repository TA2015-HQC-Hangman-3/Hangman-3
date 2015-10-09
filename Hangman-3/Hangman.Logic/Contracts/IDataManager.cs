namespace Hangman.Logic.Contracts
{
    public interface IDataManager<T>
    {
        T Read();

        void Write(T information);
    }
}
