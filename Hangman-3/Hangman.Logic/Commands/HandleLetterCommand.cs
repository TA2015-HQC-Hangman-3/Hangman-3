namespace Hangman.Logic.Commands
{
    using System;
    using System.Linq;
    using Hangman.Logic;

    /// <summary>
    /// Representing the command object that deals with letters that are guessed.
    /// </summary>
    public class HandleLetterCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleLetterCommand"/> class.
        /// </summary>
        /// <param name="guessLetter">Specifying the letter that the player has guessed.</param>
        /// <param name="printer">The object used to show messages.</param>
        public HandleLetterCommand(string guessLetter, IPrinter printer)
        {
            this.GuessLetter = guessLetter;
            this.printer = printer;
        }

        /// <summary>
        /// Gets the guessed letter.
        /// </summary>
        public string GuessLetter { get; private set; }

        /// <summary>
        /// The execution of the command for dealing with letters.
        /// </summary>
        /// <param name="context">The game context for the current game.</param>
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
            catch (ArgumentException ex)
            {
                context.CurrentMessage = GameContext.IncorrectGuessOrCommandMessage;
                this.printer.PrintLine(context.CurrentMessage + " " + ex.ParamName);
            }
        }
    }
}
