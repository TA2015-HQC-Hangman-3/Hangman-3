namespace Hangman.Logic.Commands
{
    using System;
    using System.IO;

    using Hangman.Logic;
    using Hangman.Logic.Contracts;

    public class LoadCommand : IHangmanCommand
    {
        private ISaveLoadManager gameSaver;
        private IPrinter printer;

        public LoadCommand(ISaveLoadManager gameSaver, IPrinter printer)
        {
            this.gameSaver = gameSaver;
            this.printer = printer;
        }

        public void Execute(IGameContext context)
        {
            try
            {
                this.gameSaver.LoadGame();
                context.Load(this.gameSaver.GameState);
            }
            catch (FileNotFoundException ex)
            {
                this.printer.PrintLine(ex.Message);
            }
            catch (ArgumentNullException nullEx)
            {
                this.printer.PrintLine(nullEx.Message);
            }            
        }
    }
}
