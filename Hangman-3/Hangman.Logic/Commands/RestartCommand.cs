namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    /// <summary>
    /// Class representing command for restarting the game.
    /// </summary>
    public class RestartCommand : IHangmanCommand
    {
        private readonly IPrinter printer;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestartCommand"/> class.
        /// </summary>
        /// <param name="printer">Accepts one parameter of type IPrinter used to print Game context`s current message.</param>
        public RestartCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        /// <summary>
        /// method for executing restart command.
        /// </summary>
        /// <param name="context">Accepts game context object as parameter.</param>
        public void Execute(IGameContext context)
        {
            this.printer.ClearScreen();
            context.Reset();
            context.IsGameRunning = true;
            this.printer.PrintLine(context.CurrentMessage);
        }
    }
}
