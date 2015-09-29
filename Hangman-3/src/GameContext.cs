﻿namespace Hangman
{
    public class GameContext
    {
        private readonly IRandomWordProvider randWordProvider;

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
        public const string IncorrectGuessOrCommandMessage = "Incorrect guess or command!";

        public GameContext(IRandomWordProvider wordProvider, Scoreboard scoreboard)
        {
            this.randWordProvider = wordProvider;
            this.Word = this.randWordProvider.GetWord();
            this.Scoreboard = scoreboard;
            this.CurrentMessage = GameContext.StartMessage;
            this.CurrentMistakes = 0;
            this.HasCheated = false;
            this.IsGameRunning = true;
        }

        public HangmanWord Word { get; set; }

        public Scoreboard Scoreboard { get; set; }

        public int CurrentMistakes { get; set; }

        public bool HasCheated { get; set; }

        public bool IsGameRunning { get; set; }

        public string CurrentMessage { get; set; }

        public void Reset()
        {
            this.Word = this.randWordProvider.GetWord();
            this.CurrentMistakes = 0;
            this.CurrentMessage = GameContext.StartMessage;
            this.HasCheated = false;
        }
    }
}