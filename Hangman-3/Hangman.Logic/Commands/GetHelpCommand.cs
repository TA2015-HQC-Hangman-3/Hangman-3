namespace Hangman.Commands
{
    using Hangman.Logic;

    public class GetHelpCommand : IHangmanCommand
    {
        public void Execute(IGameContext context)
        {
            context.HasCheated = true;
            context.Word.GetNextUnknownLetterOfWord();
        }
    }
}
