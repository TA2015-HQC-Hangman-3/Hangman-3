namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using Hangman.Logic;
    using Hangman.Logic.Commands;
    using Hangman.Logic.Contracts;
    using Hangman.Logic.DataManagers;
    using Hangman.Logic.SaveLoad;
    using Hangman.Logic.Sorters;

    public class HangmanGame
    {
        private const string NormalGameEndingCommandName = "finishGame";
        private const string CheaterGameEndingCommandName = "cheater";

        private static volatile HangmanGame hangmanGameInstance;
        private static object syncLock = new object();

        private readonly GameContext context;
        private readonly CommandFactory commandFactory;
        private readonly IPrinter printer;
        private ISorter sorter;
        private IDataManager<Dictionary<string, int>> scoresDataManager;
        private ISaveLoadManager gameSaver;
        private ICommandInvoker commandExecutioner;

        private HangmanGame()
        {
            this.printer = new ConsolePrinter();
            this.sorter = new SelectionSorter();
            this.scoresDataManager = new TextFileScoreboardDataManager<Dictionary<string, int>>();
            this.context = new GameContext(new SimpleRandomWordProvider(), new Scoreboard(this.printer, this.sorter, this.scoresDataManager));
            this.commandFactory = new CommandFactory();
            this.gameSaver = new SaveLoadManager(this.printer);
            this.commandExecutioner = new HangmanCommandInvoker();
        }

        public static HangmanGame Instance
        {
            get
            {
                if (hangmanGameInstance == null)
                {
                    lock (syncLock)
                    {
                        if (hangmanGameInstance == null)
                        {
                            hangmanGameInstance = new HangmanGame();
                        }
                    }
                }

                return hangmanGameInstance;
            }
        }

        public void Run()
        {
            this.printer.PrintLine(this.context.CurrentMessage);
            this.printer.PrintLine();

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
                
                this.printer.PrintLine();
                this.printer.Print(this.context.CurrentMessage);
                string userInput = Console.ReadLine();
                this.ExecuteCommand(userInput);

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
                this.ExecuteCommand(userInput);
            }
            else
            {
                this.ExecuteCommand(CheaterGameEndingCommandName);

                string userInput = Console.ReadLine();
                this.ExecuteCommand(userInput);
            }

            this.context.Reset();
        }

        private void ExecuteCommand(string commandName)
        {
            var command = this.commandFactory.GetCommand(commandName, this.printer, this.gameSaver);
            this.commandExecutioner.ExecuteCommand(command, this.context);
        }
    }
}