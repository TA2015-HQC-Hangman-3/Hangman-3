namespace Hangman.Commands
{
    using System;

    public class HandleLetterCommand : IHangmanCommand
    {
        public HandleLetterCommand(string guessLetter)
        {
            this.GuessLetter = guessLetter;
        }

        public string GuessLetter { get; private set; }

        public void Execute(GameContext context)
        {
            if (context.Word.IsValidLetter(this.GuessLetter))
            {
                if (context.Word.IsLetterInTheWord(this.GuessLetter))
                {
                    var lettersGuessed = context.Word.GetNumberOfLettersThatAreGuessed(this.GuessLetter);
                    context.CurrentMessage = string.Format(GameContext.RevealedLetterMessage, lettersGuessed);
                    Console.WriteLine(context.CurrentMessage);
                }
                else
                {
                    context.CurrentMessage = string.Format(GameContext.NotRevealedLetterMessage, this.GuessLetter);
                    Console.WriteLine(context.CurrentMessage);
                    context.CurrentMistakes++;
                }
            }
            else
            {
                context.CurrentMessage = GameContext.IncorrectGuessOrCommandMessage;
                Console.WriteLine(context.CurrentMessage);
            }
        }
    }
}
