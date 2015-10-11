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
    using Logic.WordProviders;

    /// <summary>
    /// Represents the game engine for Hangman game.
    /// </summary>
    public class HangmanGame : IGameEngine
    {
        private const string NormalGameEndingCommandName = "finishGame";
        private const string CheaterGameEndingCommandName = "cheater";
        
        private readonly IGameContext context;
        private readonly CommandFactory commandFactory;
        private readonly IPrinter printer;
        private ISaveLoadManager gameSaver;
        private ICommandInvoker commandExecutioner;

        /// <summary>
        /// Initializes a new instance of the <see cref="HangmanGame"/> class.
        /// Provides methods for running the game, ending the game and executing commands.
        /// </summary>
        public HangmanGame()
        {
            this.printer = new ConsolePrinter();
            this.context = new GameContext(SimpleRandomWordProvider.Instance, new Scoreboard(new ConsolePrinter(), new SelectionSorter(), new TextFileScoreboardDataManager<Dictionary<string, int>>()));
            this.commandFactory = new CommandFactory();
            this.gameSaver = new SaveLoadManager(this.printer, new XmlGameStateManager<SaveLoadManager>());
            this.commandExecutioner = new HangmanCommandInvoker();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HangmanGame"/> class.
        /// Provides methods for running the game, ending the game and executing commands.
        /// </summary>
        /// <param name="printer">The object used to show messages.</param>
        /// <param name="sorter">The object used to sort scores.</param>
        /// <param name="scoresDataManager">The object from which scores are read and written in.</param>
        /// <param name="gameStateManager">The object used to save the current game state.</param>
        /// <param name="commandFactory">The object used to deal with commands needed.</param>
        /// <param name="commandExecutioner">The object used for the execution of commands.</param>
        /// <param name="wordProvider">The object that provides the word for the current game.</param>
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
        /// Represents the initialization of the game.
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
                    this.context.Word.PrintTheWord(this.printer);
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
        /// Represents the ending of the current game.
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
        /// Represents the execution of commands in the game.
        /// </summary>
        /// <param name="commandName"></param>
        private void ExecuteCommand(string commandName)
        {
            var command = this.commandFactory.GetCommand(commandName, this.printer, this.gameSaver);
            this.commandExecutioner.ExecuteCommand(command, this.context);
        }
    }
}