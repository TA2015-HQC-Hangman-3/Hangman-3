namespace Hangman.Logic
{
    using System;

    using Hangman.Logic.SaveLoad;
    using Hangman.Logic.Contracts;

    /// <summary>
    /// Class representing the context of the game.
    /// </summary>
    public class GameContext : IGameContext
    {
        public const string StartMessage = "Welcome to “Hangman” game. Please try to guess my secret word. \n" +
                                           "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' \nto cheat and 'exit' " +
                                           "to quit the game.";

        public const string PropmtForUserGuess = "Enter a letter/command: ";
        public const string PromptForCommand = "Enter command - restart, top, exit: ";
        public const string WinMessage = "You won with {0} mistakes.";
        public const string WinByCheatingMessage = "You won with {0} mistakes but you have cheated. You are not allowed to enter into the scoreboard.";
        public const string PromptForUserName = "Please enter your name for the top scoreboard: ";
        public const string GoodbyeMessage = "Good bye!";
        public const string RevealedLetterMessage = "Good job! You revealed {0} letters.";
        public const string NotRevealedLetterMessage = "Sorry! There are no unrevealed letters \"{0}\".";
        public const string LetterHasBeenTriedMessage = "Sorry! You have tried entering \"{0}\" before!";
        public const string IncorrectGuessOrCommandMessage = "Incorrect guess or command!";
        public const string CurrentlyUsedLettersMessage = "Currently used letters: {0}";

        private readonly IWordProvider randWordProvider;

<<<<<<< HEAD
        /// <summary>
        /// Initializes a new instance of the <see cref="GameContext"/> class.
        /// </summary>
        /// <param name="wordProvider">Accepts first parameter of type IRandomWordProvider specifying the word for this game context. </param>
        /// <param name="scoreboard"> Second parameter from type Scoreboard to keep the score from this game context.</param>
        public GameContext(IRandomWordProvider wordProvider, Scoreboard scoreboard)
=======
        public GameContext(IWordProvider wordProvider, Scoreboard scoreboard)
>>>>>>> b6e5466bce575ebb4498be25c79f1bf7c40f1770
        {
            this.randWordProvider = wordProvider;
            this.Word = this.randWordProvider.GetWord();
            this.Scoreboard = scoreboard;
            this.CurrentMessage = GameContext.StartMessage;
            this.CurrentMistakes = 0;
            this.HasCheated = false;
            this.IsGameRunning = true;
        }

        public IWord Word { get; set; }

        public Scoreboard Scoreboard { get; set; }

        public int CurrentMistakes { get; set; }

        public bool HasCheated { get; set; }

        public bool IsGameRunning { get; set; }

        public string CurrentMessage { get; set; }

        /// <summary>
        /// Method for clearing game context and starting again.
        /// </summary>
        public void Reset()
        {
            this.Word = this.randWordProvider.GetWord();
            this.CurrentMistakes = 0;
            this.CurrentMessage = GameContext.StartMessage;
            this.HasCheated = false;
        }

        /// <summary>
        /// Method for saving the current game context.
        /// </summary>
        /// <returns>Object containing the information for the game context.</returns>
        public Memento Save()
        {
            return new Memento
            {
                Word = this.Word as HangmanWordProxy,
                CurrentMistakes = this.CurrentMistakes,
                HasCheated = this.HasCheated,
                IsGameRunning = this.IsGameRunning
            };
        }

        /// <summary>
        /// method for loading the game.
        /// </summary>
        /// <param name="gameState">The game state that must be loaded for the game.</param>
        public void Load(Memento gameState)
        {
            if (gameState == null)
            {
                throw new ArgumentNullException("Error: Loaded memento cannot be null!");
            }

            this.Word = gameState.Word;
            this.CurrentMistakes = gameState.CurrentMistakes;
            this.HasCheated = gameState.HasCheated;
            this.IsGameRunning = gameState.IsGameRunning;
        }
    }
}
