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
