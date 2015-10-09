using System.Collections.Generic;
namespace Hangman.Logic.Contracts
{
    public interface IWord
    {
        bool IsLetterGuessedForFirstTime(string letter);

        void PrintTheWord();

        char[] GenerateUnknownWord();

        bool IsWordGuessed();

        bool IsLetterInTheWord(string letter);

        int GetNumberOfLettersThatAreGuessed(string letter);

        void GetNextUnknownLetterOfWord();

        List<char> GetAllTriedLetters();
    }
}
