namespace Hangman
{
    using System;

    using Commands;

    public class HangmanGame
    {
        private const string NormalGameEndingCommandName = "finishGame";
        private const string CheaterGameEndingCommandName = "cheater";

        private readonly GameContext context;
        private readonly CommandFactory commandFactory;
        private readonly IPrinter printer;

        public HangmanGame(GameContext context, CommandFactory commandFactory, IPrinter printer)
        {
            this.context = context;
            this.commandFactory = commandFactory;
            this.printer = printer;
        }

        public void Run()
        {
            printer.Print(this.context.CurrentMessage);

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

                printer.Print("\n");
                printer.Print(this.context.CurrentMessage);
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
            var command = this.commandFactory.GetCommand(commandName, this.printer);
            command.Execute(this.context);
        }
    }
}