namespace Hangman
{
    using System;

    public class SimpleRandomWordGenerator : IRandomWordGenerator
    {
        public string GenerateRandomWord(string[] words)
        {
            Random randomNumber = new Random();
            var theChosenWord = words[randomNumber.Next(0, 10)];
            return theChosenWord;
        }
    }
}
