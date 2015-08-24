namespace Hangman
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private string[] searchWords = {
                                "computer",
                                "programmer",
                                "software",
                                "debugger",
                                "compiler",
                                "developer",
                                "algorithm",
                                "array",
                                "method",
                                "variable"
                                };

        private const string START_MESSAGE = "Welcome to “Hangman” game. Please try to guess my secret word. \n" +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' \nto cheat and 'exit' " +
            "to quit the game.";
        private bool isHelpUsed = false;
        private bool isRestartRequested = false;

        private int mistakeCounter = 0;

        private string theChosenWord;
        private char[] unknownWord;
        private Scoreboard scoreboard;
        private bool isGameRunning;

        public Engine()
        {
            scoreboard = new Scoreboard();
            GenerateRandomWord();
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
                PrintTheWord();
                Console.Write("Enter a letter: ");
                string enteredLetter = Console.ReadLine();
                ExecuteCommand(enteredLetter);
                if (isRestartRequested)
                {
                    break;
                }

            } while (!IsWordGuessed());
            
            if (isRestartRequested)
            {
                isRestartRequested = false;
                Console.WriteLine();
            }

            if (!isHelpUsed)
            {
                Console.WriteLine("You won with {0} mistakes.", mistakeCounter);
                PrintTheWord();
                Console.Write("Please enter your name for the top scoreboard: ");
                scoreboard.AddInScoreboard(scoreboard.Score, mistakeCounter);
                mistakeCounter = 0;
                scoreboard.PrintScoreboard(scoreboard.Score);
            }
            else
            {
                Console.WriteLine("You won with {0} mistakes but you have cheated. You are not allowed", mistakeCounter);
                Console.WriteLine("to enter into the scoreboard.");
                PrintTheWord();
            }
        }

        private void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "top":
                    scoreboard.PrintScoreboard(scoreboard.Score);
                    break;
                case "restart":
                    isRestartRequested = true;
                    break;
                case "help":
                    isHelpUsed = true;
                    Help();
                    break;
                case "exit":
                    Console.WriteLine("Good bye!");
                    Environment.Exit(1);
                    break;
                default:
                    if (IsValidLetter(command))
                    {
                        bool isLetterInTheWord = false;
                        int lettersGuessed = 0;
                        char enteredSymbol = char.Parse(command);
                        for (int i = 0; i < unknownWord.Length; i++)
                        {
                            if (theChosenWord[i] == enteredSymbol)
                            {
                                unknownWord[i] = enteredSymbol;
                                lettersGuessed++;
                                isLetterInTheWord = true;
                            }
                        }
                        if (isLetterInTheWord)
                        {
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

        private bool IsValidLetter(string input)
        {
            char enteredSymbol;
            if ((char.TryParse(input, out enteredSymbol)) &&
                ((int)enteredSymbol >= 97 && (int)enteredSymbol <= 122))
            {
                return true;
            }
            return false;
        }

        private void PrintTheWord()
        {
            Console.Write("The secret word is: ");
            for (int i = 0; i < unknownWord.Length; i++)
            {
                Console.Write("{0} ", unknownWord[i]);
            }
            Console.WriteLine();
        }

        private void GenerateRandomWord()
        {
            Random randomNumber = new Random();
            theChosenWord = searchWords[randomNumber.Next(0, 10)];
            int lengthOfTheWord = theChosenWord.Length;
            unknownWord = new char[lengthOfTheWord];
            for (int i = 0; i < lengthOfTheWord; i++)
            {
                unknownWord[i] = '_';
            }
        }

        private bool IsWordGuessed()
        {
            for (int i = 0; i < unknownWord.Length; i++)
            {
                if (unknownWord[i] == '_')
                {
                    return false;
                }
            }
            return true;
        }

        private void Help()
        {
            isHelpUsed = true;
            for (int i = 0; i < unknownWord.Length; i++)
            {
                if (unknownWord[i] == '_')
                {
                    unknownWord[i] = theChosenWord[i];
                    break;
                }
            }
        }
    }
}