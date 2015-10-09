namespace Hangman.Logic.Commands
{
    using Hangman.Logic;
    using Hangman.Logic.Contracts;

    public class SaveCommand : IHangmanCommand
    {
        private ISaveLoadManager gameSaver;

        public SaveCommand(ISaveLoadManager gameSaver)
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
