namespace Hangman.Commands
{
    public class GetHelpCommand : IHangmanCommand
    {
        public void Execute(GameContext context)
        {
            context.HasCheated = true;
            context.Word.GetNextUnknownLetterOfWord();
        }
    }
}
