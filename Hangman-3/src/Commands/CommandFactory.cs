﻿namespace Hangman.Commands
{
    public class CommandFactory
    {
        public IHangmanCommand GetCommand(string command, IPrinter printer)
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
                    return new SaveCommand();
                case "load":
                    return new LoadCommand();
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