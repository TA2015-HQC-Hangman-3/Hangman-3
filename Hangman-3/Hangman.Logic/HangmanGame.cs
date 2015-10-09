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
<<<<<<< HEAD
    
    /// <summary>
    /// Class containing the logic of the game.
    /// </summary>
    public class HangmanGame
=======
    using Logic.WordProviders;

    public class HangmanGame : IGameEngine
>>>>>>> b6e5466bce575ebb4498be25c79f1bf7c40f1770
    {
        private const string NormalGameEndingCommandName = "finishGame";
        private const string CheaterGameEndingCommandName = "cheater";
        
        private readonly IGameContext context;
        private readonly CommandFactory commandFactory;
        private readonly IPrinter printer;
        private ISaveLoadManager gameSaver;
        private ICommandInvoker commandExecutioner;
<<<<<<< HEAD
        
        /// <summary>
        /// Prevents a default instance of the <see cref="HangmanGame"/> class from being created.
        /// </summary>
        private HangmanGame()
=======

        public HangmanGame()
>>>>>>> b6e5466bce575ebb4498be25c79f1bf7c40f1770
        {
            this.printer = new ConsolePrinter();
            this.context = new GameContext(SimpleRandomWordProvider.Instance, new Scoreboard(new ConsolePrinter(), new SelectionSorter(), new TextFileScoreboardDataManager<Dictionary<string, int>>()));
            this.commandFactory = new CommandFactory();
            this.gameSaver = new SaveLoadManager(this.printer, new XmlGameStateManager<SaveLoadManager>());
            this.commandExecutioner = new HangmanCommandInvoker();
        }

        public HangmanGame(IPrinter printer, ISorter sorter, IDataManager<Dictionary<string, int>> scoresDataManager, IDataManager<SaveLoadManager> gameStateManager,
                           CommandFactory commandFactory, ICommandInvoker commandExecutioner, IWordProvider wordProvider)
        {
            this.printer = printer;
            this.context = new GameContext(wordProvider, new Scoreboard(printer, sorter, scoresDataManager));
            this.commandFactory = new CommandFactory();
            this.gameSaver = new SaveLoadManager(this.printer, gameStateManager);
            this.commandExecutioner = new HangmanCommandInvoker();
        }

        /// <summary>
        /// Method for starting the game.
        /// </summary>
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

        /// <summary>
        /// Method for ending the game.
        /// </summary>
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

        /// <summary>
        /// Method for executing command in the game.
        /// </summary>
        /// <param name="commandName">Specifies which command should be executed.</param>
        private void ExecuteCommand(string commandName)
        {
            var command = this.commandFactory.GetCommand(commandName, this.printer, this.gameSaver);
            this.commandExecutioner.ExecuteCommand(command, this.context);
        }
    }
}