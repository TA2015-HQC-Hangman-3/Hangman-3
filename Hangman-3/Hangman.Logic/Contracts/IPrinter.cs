// <copyright file="IPrinter.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface IPrinter.</summary>
// <author>Team Hangman 3</author>
namespace Hangman
{
    public interface IPrinter
    {
        void Print(string text);

        void PrintLine();

        void PrintLine(string text);

        void ClearScreen();
    }
}
