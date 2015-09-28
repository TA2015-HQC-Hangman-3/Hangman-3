namespace Hangman.Commands
{
    public class CommandFactory
    {
        public IHangmanCommand GetCommand(string command)
        {
            // The string command will come from a ConsoleInputParser/Reader and it will be validated there;
            switch (command)
            {
                case "restart":
                    return new RestartCommand();
                case "top":
                    return new ShowScoreboardCommand();
                case "help":
                    return new GetHelpCommand();
                case "exit":
                    return new ExitGameCommand();
                case "save":
                    return new SaveCommand();
                case "load":
                    return new LoadCommand();
                case "finishGame":
                    return new NormalGameEndCommand();
                case "cheater":
                    return new CheaterGameEndCommand();
                default:
                    return new HandleLetterCommand(command);
            }
        }
    }
}
