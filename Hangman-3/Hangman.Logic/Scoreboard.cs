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
    /// Class representing the scoreboard of the game. 
    /// </summary>
    public class Scoreboard
    {
        public const int IndexOfTheLastPersonShownOnTheScoreboard = 4;
        public const string MessageWhenNameAlreadyExistsInTheScoreBoard = "This name already exists in the Scoreboard! Type another: ";
        public const string MessageForEmptyScoreboard = "Scoreboard is empty!";

        private readonly IPrinter printer;
        private ISorter sorter;
        private IDataManager<Dictionary<string, int>> scoresDataManager;
<<<<<<< HEAD
        private string scoreFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="Scoreboard"/> class.
        /// </summary>
        /// <param name="printer">Accepts parameter printer to show messages.</param>
        /// <param name="sorter">Accepts parameter sorter to sort the scores.</param>
        /// <param name="scoresDataManager">Accepts parameter scores data manager to read the scores.</param>
        public Scoreboard(IPrinter printer, ISorter sorter, IDataManager<Dictionary<string, int>> scoresDataManager)
            : this(printer, sorter, scoresDataManager, DefaultScoreFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Scoreboard"/> class.
        /// </summary>
        /// <param name="printer">Accepts parameter printer to show messages.</param>
        /// <param name="sorter">Accepts parameter sorter to sort the scores.</param>
        /// <param name="scoresDataManager">Accepts parameter scores data manager to read the scores.</param>
        /// <param name="scoreFilePath">Accepts parameter score file path to show from where the score should be read.</param>
        public Scoreboard(IPrinter printer, ISorter sorter, IDataManager<Dictionary<string, int>> scoresDataManager, string scoreFilePath)
=======
        
        public Scoreboard(IPrinter printer, ISorter sorter, IDataManager<Dictionary<string, int>> scoresDataManager)
>>>>>>> b6e5466bce575ebb4498be25c79f1bf7c40f1770
        {
            this.Score = new Dictionary<string, int>();
            this.printer = printer;
            this.sorter = sorter;
            this.scoresDataManager = scoresDataManager;
        }

        public Dictionary<string, int> Score { get; set; }

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
                        // podari fakta che Dictionary-to ne e Multi (Wintellect Power Collections), ne moje da povarqme imena
                        this.printer.Print(MessageWhenNameAlreadyExistsInTheScoreBoard);
                        hasDouble = true;
                    }
                }
            }
            while (hasDouble);

            this.scoresDataManager.Write(this.Score);
            this.Score.Remove(name);
        }

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

                // List<KeyValuePair<string, int>> listOfScores = scores.ToList();
                // List<KeyValuePair<string, int>> listOfScores = new List<KeyValuePair<string, int>>();
                // foreach (var item in scores)
                // {
                // KeyValuePair<string, int> current = new KeyValuePair<string, int>(item.Key, item.Value);
                // listOfScores.Add(current);
                // }
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
