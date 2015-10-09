namespace Hangman
{
    /// <summary>
    /// Interface declaring that all printers must implement methods for:
    /// - printing text
    /// - printing empty line
    /// - printing text on new line
    /// - clearing the screen from messages.
    /// </summary>
    public interface IPrinter
    {
        void Print(string text);

        void PrintLine();

        void PrintLine(string text);

        void ClearScreen();
    }
}
