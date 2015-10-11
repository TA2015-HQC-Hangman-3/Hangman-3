// <copyright file="IPrinter.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface IPrinter.</summary>
// <author>Team Hangman 3</author>
namespace Hangman
{
    /// <summary>
    /// Declares the methods for each printer object.
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Shows text on the same line.
        /// </summary>
        /// <param name="text">The text to be shown.</param>
        void Print(string text);

        /// <summary>
        /// Shows empty line.
        /// </summary>
        void PrintLine();

        /// <summary>
        /// Show text on a new line.
        /// </summary>
        /// <param name="text">The text to be shown.</param>
        void PrintLine(string text);

        /// <summary>
        /// Deletes the text.
        /// </summary>
        void ClearScreen();
    }
}
