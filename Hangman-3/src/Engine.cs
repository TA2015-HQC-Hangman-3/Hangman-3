namespace Hangman
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private bool isRestartRequested = false;
        private readonly GameContext context;
        // Scoreboard will probably be made Singleton. Maybe with Save() capabillities (Memento);
        private Scoreboard scoreboard;
        private bool isGameRunning;

        public Engine()
        {
            this.context = new GameContext(new SimpleRandomWordProvider());
            scoreboard = new Scoreboard();
            isGameRunning = false;
        }

        public void Run()
        {
            Console.WriteLine(this.context.CurrentMessage);
            this.isGameRunning = true;

            while (true)
            {
                if (this.isRestartRequested)
                {
                    this.isRestartRequested = false;
                    this.isGameRunning = true;
                    Console.Clear();
                    this.context.Reset();
                    Console.WriteLine(this.context.CurrentMessage);
                }

                if (this.isGameRunning)
                {
                    this.context.CurrentMessage = GameContext.PropmtForUserGuess;
                    this.context.Word.PrintTheWord();
                }
                else
                {
                    this.context.CurrentMessage = GameContext.PromptForCommand;
                }                

                Console.WriteLine();
                Console.WriteLine(this.context.CurrentMessage);
                string userInput = Console.ReadLine();
                ExecuteCommand(userInput);

                if (this.context.Word.IsWordGuessed())
                {
                    this.EndCurrentGame();
                }
            }            
        }

        private void EndCurrentGame()
        {
            this.isGameRunning = false;

            if (!this.context.HasCheated)
            {
                this.context.CurrentMessage = string.Format(GameContext.WinMessage, this.context.CurrentMistakes);
                Console.WriteLine(this.context.CurrentMessage);
                this.context.Word.PrintTheWord();

                this.context.CurrentMessage = GameContext.PromptForUserName;
                Console.WriteLine(this.context.CurrentMessage);
                scoreboard.AddScore(this.context.CurrentMistakes);

                scoreboard.PrintScore();

                this.context.CurrentMessage = GameContext.PromptForCommand;
                Console.WriteLine(this.context.CurrentMessage);

                string userInput = Console.ReadLine();
                ExecuteCommand(userInput); 
            }
            else
            {
                this.context.CurrentMessage = string.Format(GameContext.WinByCheatingMessage, this.context.CurrentMistakes);
                Console.WriteLine(this.context.CurrentMessage);

                this.context.Word.PrintTheWord();
                
                this.context.CurrentMessage = GameContext.PromptForCommand;
                Console.WriteLine(this.context.CurrentMessage);

                string userInput = Console.ReadLine();
                ExecuteCommand(userInput);
            }

            this.context.Reset();
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
                    this.context.HasCheated = true;
                    this.context.Word.GetNextUnknownLetterOfWord();
                    break;
                case "exit":
                    Console.WriteLine("Good bye!");
                    Environment.Exit(1);
                    break;
                default:
                    if (this.context.Word.IsValidLetter(command))
                    {
                        if (this.context.Word.IsLetterInTheWord(command))
                        {
                            var lettersGuessed = this.context.Word.GetNumberOfLettersThatAreGuessed(command);
                            Console.WriteLine("Good job! You revealed {0} letters.", lettersGuessed);
                        }
                        else
                        {
                            Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\".", command);
                            this.context.CurrentMistakes++;
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