namespace Hangman.Commands
{
    using Hangman.Logic;
    using Hangman.Logic.Contracts;

    public class LoadCommand : IHangmanCommand
    {
        private ISaverLoader gameSaver;

        public LoadCommand(ISaverLoader gameSaver)
        {
            this.gameSaver = gameSaver;
        }

        public void Execute(IGameContext context)
        {
            this.gameSaver.LoadGame();
            context.Load(this.gameSaver.GameState);
        }
    }
}
