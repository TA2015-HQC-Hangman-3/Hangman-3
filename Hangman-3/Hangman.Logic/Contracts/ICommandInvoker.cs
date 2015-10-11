// <copyright file="ICommandInvoker.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface ICommandInvoker.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Contracts
{
    using Commands;

    public interface ICommandInvoker
    {
        void ExecuteCommand(IHangmanCommand command, IGameContext context);
    }
}
