// <copyright file="IDataManager.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface IDataManager.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Contracts
{
    /// <summary>
    /// Declares the methods for each data manager.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    public interface IDataManager<T>
    {
        /// <summary>
        /// Provides the reading of data.
        /// </summary>
        /// <returns>Object of type specified.</returns>
        T Read();

        /// <summary>
        /// Provides with the writing of information.
        /// </summary>
        /// <param name="information">The information to be written.</param>
        void Write(T information);
    }
}
