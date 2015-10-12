// <copyright file="Scoreboard.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Class Scoreboard.</summary>
// <author>Team Hangman 3</author>
namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Hangman.Logic;
    using Hangman.Logic.Contracts;
    using Hangman.Logic.DataManagers;

    /// <summary>
    /// Represents the scoreboard of the game.
    /// </summary>
    public class Scoreboard
    {
        /// <summary>
        /// Sets how many results should be shown on the console - the value + 1.
        /// </summary>
        public const int IndexOfTheLastPersonShownOnTheScoreboard = 4;

        /// <summary>
        /// Message to show when user inputs a name that is already on the scoreboard.
        /// </summary>
        public const string MessageWhenNameAlreadyExistsInTheScoreBoard = "This name already exists in the Scoreboard! Type another: ";

        /// <summary>
        /// Message to show when there are no results in the scoreboard.
        /// </summary>
        public const string MessageForEmptyScoreboard = "Scoreboard is empty!";

        private readonly IPrinter printer;
        private ISorter sorter;
        private IDataManager<Dictionary<string, int>> scoresDataManager;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Scoreboard"/> class.
        /// </summary>
        /// <param name="printer">The object used to show messages.</param>
        /// <param name="sorter">The object used to sort scores.</param>
        /// <param name="scoresDataManager">The object from which scores are read and written in.</param>
        public Scoreboard(IPrinter printer, ISorter sorter, IDataManager<Dictionary<string, int>> scoresDataManager)
        {
            this.Score = new Dictionary<string, int>();
            this.printer = printer;
            this.sorter = sorter;
            this.scoresDataManager = scoresDataManager;
        }

        /// <summary>
        /// Gets or sets score for the game's scoreboard.
        /// </summary>
        /// <value>Returns dictionary with all players and their scores.</value>
        public Dictionary<string, int> Score { get; set; }

        /// <summary>
        /// Implementation of adding score.
        /// </summary>
        /// <param name="mistakes">The number of mistakes done.</param>
        public void AddScore(int mistakes)
        {
            string name = string.Empty;
            bool hasDouble = false;
            do
            {
                hasDouble = false;
                name = Console.ReadLine();
                this.Score.Add(name, mistakes);

                var scores = this.scoresDataManager.Read();
                foreach (var item in scores)
                {
                    if (item.Key == name)
                    {
                        this.printer.Print(MessageWhenNameAlreadyExistsInTheScoreBoard);
                        hasDouble = true;
                    }
                }
            }
            while (hasDouble);

            this.scoresDataManager.Write(this.Score);
            this.Score.Remove(name);
        }

        /// <summary>
        /// Implementation of score printing.
        /// </summary>
        public void PrintScore()
        {
            Dictionary<string, int> scores;
            try
            {
                scores = this.scoresDataManager.Read();

                if (scores.Count == 0)
                {
                    this.printer.PrintLine(MessageForEmptyScoreboard);
                    return;
                }

                var sortedScores = this.sorter.Sort(scores);

                this.printer.PrintLine("Scoreboard:");
                var index = 0;
                foreach (var score in sortedScores)
                {
                    var scoreEntry = string.Format("{0}. {1} --> {2} mistake", index + 1, score.Key, score.Value);
                    this.printer.PrintLine(scoreEntry);
                    if (index == IndexOfTheLastPersonShownOnTheScoreboard)
                    {
                        break;
                    }

                    index += 1;
                }
            }
            catch (FileNotFoundException ex)
            {
                this.printer.Print(MessageForEmptyScoreboard + " " + ex.Message);
            }

            this.printer.PrintLine();
        }
    }
}
