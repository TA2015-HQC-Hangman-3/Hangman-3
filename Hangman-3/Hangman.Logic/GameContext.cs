namespace Hangman.Logic
{
    using System;
    using Hangman.Logic.Contracts;
    using Hangman.Logic.SaveLoad;

    /// <summary>
    /// Represents the information available for the current state o fteh game.
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

        /// <summary>
        /// Initializes a new instance of the <see cref="GameContext"/> class.
        /// </summary>
        /// <param name="wordProvider">The object that will provide the word.</param>
        /// <param name="scoreboard">The scoreboard where the result will be kept.</param>
        public GameContext(IWordProvider wordProvider, Scoreboard scoreboard)
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
        /// Start from the beginning.
        /// </summary>
        public void Reset()
        {
            this.Word = this.randWordProvider.GetWord();
            this.CurrentMistakes = 0;
            this.CurrentMessage = GameContext.StartMessage;
            this.HasCheated = false;
        }

        /// <summary>
        /// Save the current situation.
        /// </summary>
        /// <returns>An object containing information about the current state.</returns>
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
        /// Loads the game from the saved state.
        /// </summary>
        /// <param name="gameState">Represents the saved state.</param>
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
