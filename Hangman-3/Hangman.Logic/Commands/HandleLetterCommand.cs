﻿namespace Hangman.Logic.Commands
{
    using System;

    using Hangman.Logic;

    public class HandleLetterCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        public HandleLetterCommand(string guessLetter, IPrinter printer)
        {
            this.GuessLetter = guessLetter;
            this.printer = printer;
        }

        public string GuessLetter { get; private set; }

        public void Execute(IGameContext context)
        {
            try
            {
                if (context.Word.IsLetterGuessedForFirstTime(this.GuessLetter))
                {
                    if (context.Word.IsLetterInTheWord(this.GuessLetter))
                    {
                        var lettersGuessed = context.Word.GetNumberOfLettersThatAreGuessed(this.GuessLetter);
                        context.CurrentMessage = string.Format(GameContext.RevealedLetterMessage, lettersGuessed);
                        this.printer.PrintLine(context.CurrentMessage);
                    }
                    else
                    {
                        context.CurrentMessage = string.Format(GameContext.NotRevealedLetterMessage, this.GuessLetter);
                        this.printer.PrintLine(context.CurrentMessage);
                        context.CurrentMistakes++;
                    }
                }
                else
                {
                    context.CurrentMessage = string.Format(GameContext.LetterHasBeenTriedMessage, this.GuessLetter);
                    this.printer.PrintLine(context.CurrentMessage);
                }
            }
            catch(ArgumentException ex)
            {
                context.CurrentMessage = GameContext.IncorrectGuessOrCommandMessage;
                this.printer.PrintLine(context.CurrentMessage + " " + ex.ParamName);
            }
        }
    }
}
