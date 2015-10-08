namespace Hangman.Logic.Contracts
{
    using System.Collections.Generic;

    public interface IDataManager
    {
        Dictionary<string, int> Read(string filePath);

        void Write(string name, int count, string filePath);
    }
}