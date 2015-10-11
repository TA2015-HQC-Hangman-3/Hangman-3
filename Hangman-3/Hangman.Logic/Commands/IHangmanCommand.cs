// <copyright file="IHangmanCommand.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Interface IHangmanCommand.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.Commands
{
    using Hangman.Logic;

    public interface IHangmanCommand
    {
        void Execute(IGameContext context);
    }
}
