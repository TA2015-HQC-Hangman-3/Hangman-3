namespace Hangman
{
    using System;
    using System.Collections.Generic;

    using Commands;

    public class Engine
    {
        private const string NormalGameEndingCommandName = "finishGame";
        private const string CheaterGameEndingCommandName = "cheater";

        private readonly GameContext context;
        private readonly CommandFactory commandFactory;

        public Engine(GameContext context, CommandFactory commandFactory)
        {
            this.context = context;
            this.commandFactory = commandFactory;
        }

        public void Run()
        {
            Console.WriteLine(this.context.CurrentMessage);

            while (true)
            {
                if (this.context.IsGameRunning)
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
            this.context.IsGameRunning = false;

            if (!this.context.HasCheated)
            {
                this.ExecuteCommand(NormalGameEndingCommandName);                

                string userInput = Console.ReadLine();
                ExecuteCommand(userInput); 
            }
            else
            {
                this.ExecuteCommand(CheaterGameEndingCommandName);                

                string userInput = Console.ReadLine();
                ExecuteCommand(userInput);
            }

            this.context.Reset();
        }

        private void ExecuteCommand(string commandName)
        {
            var command = this.commandFactory.GetCommand(commandName);
            command.Execute(this.context);
        }
    }
}