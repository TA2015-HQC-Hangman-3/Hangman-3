namespace Hangman
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private const string START_MESSAGE = "Welcome to “Hangman” game. Please try to guess my secret word. \n" +
           "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' \nto cheat and 'exit' " +
           "to quit the game.";

        private bool isHelpUsed = false;
        private bool isRestartRequested = false;
        private int mistakeCounter = 0;
        private HangmanWord theWord;
        private Scoreboard scoreboard;
        // isGameRunning is never used. We must figure out whether we are going to use it for something or not.
        private bool isGameRunning;

        public Engine()
        {
            scoreboard = new Scoreboard();
            theWord = new HangmanWord(new SimpleRandomWordGenerator());
            Console.WriteLine(START_MESSAGE);
            isHelpUsed = false;
            mistakeCounter = 0;
            isGameRunning = true;
        }

        public void Start()
        {
            do
            {
                Console.WriteLine();
                this.theWord.PrintTheWord();
                Console.Write("Enter a letter: ");
                string enteredLetter = Console.ReadLine();
                ExecuteCommand(enteredLetter);

                if (isRestartRequested)
                {
                    break;
                }

            } while (!this.theWord.IsWordGuessed());
            
            if (isRestartRequested)
            {
                isRestartRequested = false;
                Console.WriteLine();
            }

            if (!isHelpUsed)
            {
                Console.WriteLine("You won with {0} mistakes.", mistakeCounter);
                this.theWord.PrintTheWord();
                Console.Write("Please enter your name for the top scoreboard: ");
                scoreboard.AddScore(mistakeCounter);
                mistakeCounter = 0;
                scoreboard.PrintScore();
            }
            else
            {
                Console.WriteLine("You won with {0} mistakes but you have cheated. You are not allowed", mistakeCounter);
                Console.WriteLine("to enter into the scoreboard.");
                this.theWord.PrintTheWord();
            }
        }

        private void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "top":
                    scoreboard.PrintScore();
                    break;
                case "restart":
                    isRestartRequested = true;
                    break;
                case "help":
                    isHelpUsed = true;
                    this.theWord.GetNextUnknownLetterOfWord();
                    break;
                case "exit":
                    Console.WriteLine("Good bye!");
                    Environment.Exit(1);
                    break;
                default:
                    if (this.theWord.IsValidLetter(command))
                    {
                        if (this.theWord.IsLetterInTheWord(command))
                        {
                            var lettersGuessed = this.theWord.GetNumberOfLettersThatAreGuessed(command);
                            Console.WriteLine("Good job! You revealed {0} letters.", lettersGuessed);
                        }
                        else
                        {
                            Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\".", command);
                            mistakeCounter++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect guess or command!");
                    }
                    break;
            }
        }
    }
}