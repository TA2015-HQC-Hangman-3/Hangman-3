namespace Hangman
{
    using System;

    /// <summary>
    /// Represents printing on the Console.
    /// </summary>
    public class ConsolePrinter : IPrinter
    {
        /// <summary>
        /// Shows text on the same line.
        /// </summary>
        /// <param name="currentText">The text to be shown.</param>
        public void Print(string currentText)
        {
            Console.Write(currentText);
        }

        /// <summary>
        /// Shows empty line.
        /// </summary>
        public void PrintLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Show text on a new line.
        /// </summary>
        /// <param name="currentText">The text to be shown.</param>
        public void PrintLine(string currentText)
        {
            Console.WriteLine(currentText);
        }

        /// <summary>
        /// Deleting text.
        /// </summary>
        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
