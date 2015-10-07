namespace Hangman.Commands
{
    using Hangman.Logic;
    using Hangman.Logic.Contracts;

    public class SaveCommand : IHangmanCommand
    {
        private ISaverLoader gameSaver;

        public SaveCommand(ISaverLoader gameSaver)
        {
            this.gameSaver = gameSaver;
        }

        public void Execute(IGameContext context)
        {
            this.gameSaver.GameState = context.Save();
            this.gameSaver.SaveGame();
        }
    }
}
