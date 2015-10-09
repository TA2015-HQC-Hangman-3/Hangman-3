 namespace Hangman
{
    using System;

     /// <summary>
     /// Contains methods for printing on the console
     /// </summary>
    public class ConsolePrinter : IPrinter
    {
        /// <summary>
        /// Method for printing text on the current line.
        /// </summary>
        /// <param name="currentText">The text that must be printed.</param>
        public void Print(string currentText)
        {
            Console.Write(currentText);
        }

        /// <summary>
        /// Method for printing empty line.
        /// </summary>
        public void PrintLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Method for printing text on new line.
        /// </summary>
        /// <param name="currentText">The text that must be printed.</param>
        public void PrintLine(string currentText)
        {
            Console.WriteLine(currentText);
        }

        /// <summary>
        /// Method for clearing all text from the screen.
        /// </summary>
        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
