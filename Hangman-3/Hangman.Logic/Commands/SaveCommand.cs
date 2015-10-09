namespace Hangman.Logic.Commands
{
    using Hangman.Logic;
    using Hangman.Logic.Contracts;

    /// <summary>
    /// Class representing the command for saving current game state.
    /// </summary>
    public class SaveCommand : IHangmanCommand
    {
        private ISaveLoadManager gameSaver;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveCommand"/> class.
        /// </summary>
        /// <param name="gameSaver">Accepts a parameter of type ISaveLoadManager used to save current game context. </param>
        public SaveCommand(ISaveLoadManager gameSaver)
        {
            this.gameSaver = gameSaver;
        }

        /// <summary>
        /// method for executing Save command.
        /// </summary>
        /// <param name="context">Accepts game context object as parameter.</param>
        public void Execute(IGameContext context)
        {
            this.gameSaver.GameState = context.Save();
            this.gameSaver.SaveGame();
        }
    }
}
