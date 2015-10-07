namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Hangman.Logic;
    using System.Linq;

    public class Scoreboard
    {
        public const int IndexOfTheLastPersonShownOnTheScoreboard = 4;
        public const string MessageWhenNameAlreadyExistsInTheScoreBoard = "This name already exists in the Scoreboard! Type another: ";
        public const string MessageForEmptyScoreboard = "Scoreboard is empty!";
        public const string DefaultScoreFilePath = "../../../Hangman.Logic/files/scores.txt";

        private readonly IPrinter printer;
        private ISorter sorter;
        private string scoreFilePath;

        public Scoreboard(IPrinter printer, ISorter sorter)
            : this(printer, sorter, DefaultScoreFilePath)
        {

        }

        public Scoreboard(IPrinter printer, ISorter sorter, string scoreFilePath)
        {
            this.printer = printer;
            this.sorter = sorter;
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
                var scores = this.ReadScores(this.scoreFilePath);
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

            this.WriteScore(name, mistakes, this.scoreFilePath);
        }

        public void PrintScore()
        {
            var scores = this.ReadScores(this.scoreFilePath);

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

        private Dictionary<string, int> ReadScores(string filePath)
        {
            StreamReader scoresReader = new StreamReader(filePath);
            Dictionary<string, int> result = new Dictionary<string, int>();

            using (scoresReader)
            {
                while (true) {
                    var currLine = scoresReader.ReadLine();
                    if(currLine  == null || currLine.Trim() == "")
                    {
                        break;
                    }
                    string[] data = currLine.Split(' ');
                    string name = string.Empty;
                    int score;

                    if (data.Length == 2)
                    {
                        name = data[0];
                        score = int.Parse(data[1]);
                    }
                    else
                    {
                        for (int i = 0; i < data.Length - 1; i++)
                        {
                            if (i == data.Length - 2)
                            {
                                name += data[i];
                            }
                            else
                            {
                                name += data[i] + " ";
                            }
                        }

                        score = int.Parse(data[data.Length - 1]);
                    }

                    result.Add(name, score);
                }
            }

            return result;
        }

        private void WriteScore(string name, int mistakes, string filePath)
        {
            StreamWriter scoreWriter = new StreamWriter(filePath, true);

            using (scoreWriter)
            {
                scoreWriter.WriteLine("{0} {1}", name, mistakes);
            }
        }
    }
}
