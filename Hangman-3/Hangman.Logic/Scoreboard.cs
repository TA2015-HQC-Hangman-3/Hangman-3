namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Hangman.Logic;
    using System.Linq;
using Hangman.Logic.Contracts;

    public class Scoreboard
    {
        public const int IndexOfTheLastPersonShownOnTheScoreboard = 4;
        public const string MessageWhenNameAlreadyExistsInTheScoreBoard = "This name already exists in the Scoreboard! Type another: ";
        public const string MessageForEmptyScoreboard = "Scoreboard is empty!";
        public const string DefaultScoreFilePath = "../../../Hangman.Logic/files/scores.txt";

        private readonly IPrinter printer;
        private ISorter sorter;
        private IDataManager scoreManager;
        private string scoreFilePath;

        public Scoreboard(IPrinter printer, ISorter sorter, IDataManager scoreManager)
            : this(printer, sorter, scoreManager, DefaultScoreFilePath)
        {

        }

        public Scoreboard(IPrinter printer, ISorter sorter, IDataManager scoreManager, string scoreFilePath)
        {
            this.printer = printer;
            this.sorter = sorter;
            this.scoreManager = scoreManager;
            this.scoreFilePath = scoreFilePath;
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
                var scores = this.scoreManager.Read(this.scoreFilePath);
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

            this.scoreManager.Write(name, mistakes, this.scoreFilePath);
        }

        public void PrintScore()
        {
            var scores = this.scoreManager.Read(this.scoreFilePath);

            if (scores.Count == 0)
            {
                this.printer.PrintLine(MessageForEmptyScoreboard);
                return;
            }


            //List<KeyValuePair<string, int>> listOfScores = scores.ToList();

            //List<KeyValuePair<string, int>> listOfScores = new List<KeyValuePair<string, int>>();
            //foreach (var item in scores)
            //{
            //    KeyValuePair<string, int> current = new KeyValuePair<string, int>(item.Key, item.Value);
            //    listOfScores.Add(current);
            //}

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

            this.printer.PrintLine();
        }
    }
}
