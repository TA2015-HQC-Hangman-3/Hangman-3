namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    /// <summary>
    /// Class representing the command for getting help.
    /// </summary>
    public class GetHelpCommand : IHangmanCommand
    {
        /// <summary>
        /// Method for executing command.
        /// </summary>
        /// <param name="context">Contains the current message.</param>
        public void Execute(IGameContext context)
        {
            context.HasCheated = true;
            context.Word.GetNextUnknownLetterOfWord();
        }
    }
}
