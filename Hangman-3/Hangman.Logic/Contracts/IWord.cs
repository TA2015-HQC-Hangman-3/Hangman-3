namespace Hangman.Logic.Contracts
{
    using System.Collections.Generic;

    public interface IWord
    {
        bool IsLetterGuessedForFirstTime(string letter);

        void PrintTheWord(IPrinter printer);

        char[] GenerateHiddenWord();

        bool IsWordGuessed();

        bool IsLetterInTheWord(string letter);

        int GetNumberOfLettersThatAreGuessed(string letter);

        void GetNextUnknownLetterOfWord();

        List<char> GetAllTriedLetters();
    }
}
