namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Hangman.Logic;
    using Hangman.Logic.Contracts;
    using Hangman.Logic.DataManagers;

    public class Scoreboard
    {
        public const int IndexOfTheLastPersonShownOnTheScoreboard = 4;
        public const string MessageWhenNameAlreadyExistsInTheScoreBoard = "This name already exists in the Scoreboard! Type another: ";
        public const string MessageForEmptyScoreboard = "Scoreboard is empty!";
        public const string DefaultScoreFilePath = "../../../Hangman.Logic/files/scores.txt";

        private readonly IPrinter printer;
        private ISorter sorter;
        private IDataManager<Dictionary<string, int>> scoresDataManager;
        private string scoreFilePath;

        public Scoreboard(IPrinter printer, ISorter sorter)
            : this(printer, sorter, DefaultScoreFilePath, new TextFileScoreboardDataManager<Dictionary<string, int>>())
        {

        }

        public Scoreboard(IPrinter printer, ISorter sorter, string scoreFilePath, IDataManager<Dictionary<string, int>> scoresDataManager)
        {
            this.Score = new Dictionary<string, int>();
            this.printer = printer;
            this.sorter = sorter;
            this.scoreFilePath = scoreFilePath;
            this.scoresDataManager = new TextFileScoreboardDataManager<Dictionary<string, int>>();
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

                var scores = this.scoresDataManager.Read(this.scoreFilePath);
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

            this.scoresDataManager.Write(this.scoreFilePath, this.Score);
            this.Score.Remove(name);
        }

        public void PrintScore()
        {
            var scores = this.scoresDataManager.Read(this.scoreFilePath);

            if (scores.Count == 0)
            {
                this.printer.Print(MessageForEmptyScoreboard);
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

            this.printer.Print("Scoreboard:");
            var index = 0;
            foreach (var score in sortedScores)
            {
                var scoreEntry = string.Format("{0}. {1} --> {2} mistake", index + 1, score.Key, score.Value);
                this.printer.Print(scoreEntry);
                if (index == IndexOfTheLastPersonShownOnTheScoreboard)
                {
                    break;
                }
                index += 1;
            }

            this.printer.Print("\n");
        } 
    }
}
