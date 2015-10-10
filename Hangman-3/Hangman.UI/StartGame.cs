namespace Hangman.UI
{
    using System.Collections.Generic;
    using Hangman;
    using Hangman.Logic;
    using Hangman.Logic.Commands;
    using Hangman.Logic.Contracts;
    using Hangman.Logic.DataManagers;
    using Hangman.Logic.SaveLoad;
    using Hangman.Logic.Sorters;
    using Logic.WordProviders;
    using Ninject;

    /// <summary>
    /// Entry point of the game.
    /// </summary>
    public class StartGame
    {
        public static void Main()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IPrinter>().To<ConsolePrinter>();
            kernel.Bind<IDataManager<Dictionary<string, int>>>().To<TextFileScoreboardDataManager<Dictionary<string, int>>>();
            kernel.Bind<IDataManager<SaveLoadManager>>().To<XmlGameStateManager<SaveLoadManager>>();
            kernel.Bind<ISorter>().To<SelectionSorter>();
            kernel.Bind<ICommandInvoker>().To<HangmanCommandInvoker>();

            var printer = kernel.Get<IPrinter>();
            var sorter = kernel.Get<ISorter>();
            var scoresDataManager = kernel.Get<IDataManager<Dictionary<string, int>>>();
            var gameStateManager = kernel.Get<IDataManager<SaveLoadManager>>();
            var commandFactory = new CommandFactory();
            var commandExecutioner = kernel.Get<ICommandInvoker>();
            // var wordProvider = SimpleRandomWordProvider.Instance;
            var wordProvider = XmlWordProvider.Instance;

            var game = new HangmanGame(printer, sorter, scoresDataManager, gameStateManager, commandFactory, commandExecutioner, wordProvider);
            game.Run();
        }
    }
}
