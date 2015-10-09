namespace Hangman.Logic.Commands
{
    using System;
    using System.Linq;
    using Hangman.Logic;

    /// <summary>
    /// Class containing the logic for guessing letter of a word.
    /// </summary>
    public class HandleLetterCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleLetterCommand"/> class.
        /// </summary>
        /// <param name="guessLetter">Accepts parameter from type string, representing the letter - guess.</param>
        /// <param name="printer">Accepts parameter from type IPrinter used to print Game context`s current message.</param>
        public HandleLetterCommand(string guessLetter, IPrinter printer)
        {
            this.GuessLetter = guessLetter;
            this.printer = printer;
        }

        public string GuessLetter { get; private set; }

        /// <summary>
        /// Method for executing command.
        /// </summary>
        /// <param name="context">Contains the current message.</param>
        public void Execute(IGameContext context)
        {
            try
            {
                if (context.Word.IsLetterGuessedForFirstTime(this.GuessLetter))
                {
                    if (context.Word.IsLetterInTheWord(this.GuessLetter))
                    {
                        var lettersGuessed = context.Word.GetNumberOfLettersThatAreGuessed(this.GuessLetter);
                        var allCurrentlyGuessedLetters = string.Join(", ", context.Word.GetAllTriedLetters().Select(x => x.ToString()).ToArray());
                        context.CurrentMessage = string.Format(GameContext.CurrentlyUsedLettersMessage, allCurrentlyGuessedLetters) + "\n" + string.Format(GameContext.RevealedLetterMessage, lettersGuessed);
                        this.printer.PrintLine(context.CurrentMessage);
                    }
                    else
                    {
                        var allCurrentlyGuessedLetters = string.Join(", ", context.Word.GetAllTriedLetters().Select(x => x.ToString()).ToArray());
                        context.CurrentMessage = string.Format(GameContext.CurrentlyUsedLettersMessage, allCurrentlyGuessedLetters) + "\n" + string.Format(GameContext.NotRevealedLetterMessage, this.GuessLetter);
                        this.printer.PrintLine(context.CurrentMessage);
                        context.CurrentMistakes++;
                    }
                }
                else
                {
                    var allCurrentlyGuessedLetters = string.Join(", ", context.Word.GetAllTriedLetters().Select(x => x.ToString()).ToArray());
                    context.CurrentMessage = string.Format(GameContext.CurrentlyUsedLettersMessage, allCurrentlyGuessedLetters) + "\n" + string.Format(GameContext.LetterHasBeenTriedMessage, this.GuessLetter);
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
