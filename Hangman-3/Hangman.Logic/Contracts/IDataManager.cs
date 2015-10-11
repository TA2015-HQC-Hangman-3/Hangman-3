// <copyright file="IDataManager.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface IDataManager.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Contracts
{
    public interface IDataManager<T>
    {
        T Read();

        void Write(T information);
    }
}
