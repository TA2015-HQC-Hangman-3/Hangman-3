namespace Hangman.Logic.Contracts
{
    /// <summary>
    /// Interface declaring that every Data Manager should contain Read and Write methods.
    /// </summary>
    /// <typeparam name="T">Represents the type of file for reading/writing.</typeparam>
    public interface IDataManager<T>
    {
        T Read(string filePath);

        void Write(string filePath, T information);
    }
}
