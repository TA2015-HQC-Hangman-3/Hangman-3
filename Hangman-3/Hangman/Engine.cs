﻿namespace Hangman
{

    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private string[] someWords = {
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
        public const string START_MESSAGE = "Welcome to “Hangman” game. Please try to guess my secret word. \n" +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' \nto cheat and 'exit' " +
            "to quit the game.";
        public bool isCheated = false;
        public bool isRestartRequested = false;

        public int mistakeCounter = 0;

        public string theChosenWord;
        public char[] unknownWord;
        public Dictionary<string, int> score;
        public bool isGameRunning;

        public Engine()
        {
            score = new Dictionary<string, int>();
            GenerateWord();
            Console.WriteLine(START_MESSAGE);
            isCheated = false;
            mistakeCounter = 0;
            isGameRunning = true;
        }

        public void Start()
        {
            do
            {
                Console.WriteLine();
                PrintTheWord();
                Console.Write("Enter your guess: ");
                string enteredString = Console.ReadLine();
                ExecuteCommand(enteredString);
                if (isRestartRequested)
                {
                    break;
                }

            } while (!IsWordKnown());
            if (isRestartRequested)
            {
                isRestartRequested = false;
                Console.WriteLine();
            }
            if (!isCheated)
            {
                Console.WriteLine("You won with {0} mistakes.", mistakeCounter);
                PrintTheWord();
                Console.Write("Please enter your name for the top scoreboard: ");
                AddInScoreboard(score);



                PrintScoreboard(score);
            }
            else
            {
                Console.WriteLine("You won with {0} mistakes but you have cheated. You are not allowed", mistakeCounter);
                Console.WriteLine("to enter into the scoreboard.");
                PrintTheWord();
            }
        }

        public void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "top":
                    PrintScoreboard(score);
                    break;
                case "restart":
                    isRestartRequested = true;
                    break;

                case "help":
                    isCheated = true;
                    Help();


                    break;
                case "exit":
                    Console.WriteLine("Good bye!");
                    Environment.Exit(1);
                    break;
                default:
                    if (IsValidSymbol(command))
                    {
                        bool isLetterInTheWord = false;
                        int letterKnown = 0;
                        char enteredSymbol = char.Parse(command);
                        for (int i = 0; i < unknownWord.Length; i++)
                        {
                            if (theChosenWord[i] == enteredSymbol)
                            {
                                unknownWord[i] = enteredSymbol;
                                letterKnown++;
                                isLetterInTheWord = true;
                            }
                        }
                        if (isLetterInTheWord)
                        {
                            Console.WriteLine("Good job! You revealed {0} letters.", letterKnown);
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

        private bool IsValidSymbol(string enteredString)
        {
            char enteredSymbol;
            if ((char.TryParse(enteredString, out enteredSymbol)) &&
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

        private void GenerateWord()
        {
            Random randomNumber = new Random();
            theChosenWord = someWords[randomNumber.Next(0, 10)];
            int lengthOfTheWord = theChosenWord.Length;
            unknownWord = new char[lengthOfTheWord];
            for (int i = 0; i < lengthOfTheWord; i++)
            {
                unknownWord[i] = '_';
            }
        }

        private bool IsWordKnown()
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

        private void AddInScoreboard(Dictionary<string, int> score)
        {
            string name = string.Empty;
            bool hasDouble = false;
            do
            {
                hasDouble = false;
                name = Console.ReadLine();
                foreach (var item in score)
                {
                    if (item.Key == name)
                    {
                        Console.Write("This name already exists in the Scoreboard! Type another: ");
                        hasDouble = true;
                        //podari fakta che Dictionary-to ne e Multi (Wintellect Power Collections), ne moje da povarqme imena
                    }
                }
            } while (hasDouble);
            score.Add(name, mistakeCounter);
            mistakeCounter = 0;
        }

        private void PrintScoreboard(Dictionary<string, int> score)
        {
            if (score.Count == 0)
            {
                Console.WriteLine("Empty Scoreboard!");
                return;
            }
            List<KeyValuePair<string, int>> key = new List<KeyValuePair<string, int>>();
            foreach (var item in score)
            {
                KeyValuePair<string, int> current = new KeyValuePair<string, int>(item.Key, item.Value);
                key.Add(current);
            }
            key.Sort(new OutComparer());
            Console.WriteLine("Scoreboard:");
            for (int i = 0; i < score.Count; i++)
            {
                Console.WriteLine("{0}. {1} --> {2} mistake", i + 1, key[i].Key, key[i].Value);
                if (i == 4)
                {
                    //Ima izlishak ot informacia, pokazvame samo parvite 5, no pazim vsichki (izlishno moje bi)
                    break;
                }
            }
            Console.WriteLine();
        }

        private void Help()
        {
            isCheated = true;
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