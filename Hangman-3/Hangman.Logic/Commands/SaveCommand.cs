namespace Hangman.Logic.Commands
{
    using Hangman.Logic;
    using Hangman.Logic.Contracts;

    /// <summary>
    /// Represents object for saving the game of type command.
    /// </summary>
    public class SaveCommand : IHangmanCommand
    {
        private ISaveLoadManager gameSaver;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveCommand"/> class.
        /// </summary>
        /// <param name="gameSaver">The object that will hold the saved state.</param>
        public SaveCommand(ISaveLoadManager gameSaver)
        {
            this.gameSaver = gameSaver;
        }

        /// <summary>
        /// Implements the execution of the load game command.
        /// </summary>
        /// <param name="context">The game context for the execution of the command.</param>
        public void Execute(IGameContext context)
        {
            this.gameSaver.GameState = context.Save();
            this.gameSaver.SaveGame();
        }
    }
}
