namespace Hangman
{
    using System;

    public class ConsolePrinter : IPrinter
    {
        public void Print(string currentText)
        {
            Console.Write(currentText);
        }

        public void PrintLine()
        {
            Console.WriteLine();
        }

        public void PrintLine(string currentText)
        {
            Console.WriteLine(currentText);
        }

        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
