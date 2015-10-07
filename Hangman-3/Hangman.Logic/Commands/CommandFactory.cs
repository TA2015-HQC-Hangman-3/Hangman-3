namespace Hangman.Commands
{
    using Hangman.Logic.Contracts;

    public class CommandFactory
    {
        public IHangmanCommand GetCommand(string command, IPrinter printer, ISaverLoader gameSaver)
        {
            // The string command will come from a ConsoleInputParser/Reader and it will be validated there;
            switch (command)
            {
                case "restart":
                    return new RestartCommand(printer);
                case "top":
                    return new ShowScoreboardCommand();
                case "help":
                    return new GetHelpCommand();
                case "exit":
                    return new ExitGameCommand(printer);
                case "save":
                    return new SaveCommand(gameSaver);
                case "load":
                    return new LoadCommand(gameSaver);
                case "finishGame":
                    return new NormalGameEndCommand(printer);
                case "cheater":
                    return new CheaterGameEndCommand(printer);
                default:
                    return new HandleLetterCommand(command, printer);
            }
        }
    }
}
