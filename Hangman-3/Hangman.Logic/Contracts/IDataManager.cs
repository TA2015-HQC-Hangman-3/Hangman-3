namespace Hangman.Logic.Contracts
{
    public interface IDataManager<T>
    {
        T Read(string filePath);

        void Write(string filePath, T information);
    }
}
