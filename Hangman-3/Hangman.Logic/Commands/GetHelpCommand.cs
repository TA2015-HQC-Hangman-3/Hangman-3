namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    /// <summary>
    /// Representing the object for command for getting help in the game. 
    /// </summary>
    public class GetHelpCommand : IHangmanCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetHelpCommand"/> class.
        /// </summary>
        /// <param name="context">The game context for the current game.</param>
        public void Execute(IGameContext context)
        {
            context.HasCheated = true;
            context.Word.GetNextUnknownLetterOfWord();
        }
    }
}
