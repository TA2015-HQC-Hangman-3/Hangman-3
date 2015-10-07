namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Hangman.Logic;

    public class Scoreboard
    {
        public const int IndexOfTheLastPersonShownOnTheScoreboard = 4;
        public const string MessageWhenNameAlreadyExistsInTheScoreBoard = "This name already exists in the Scoreboard! Type another: ";
        public const string MessageForEmptyScoreboard = "Scoreboard is empty!";
        public const string ScoreFilePath = "../../../Hangman.Logic/files/scores.txt";
        
        private readonly IPrinter printer;
        private ISorter sorter;

        public Scoreboard(IPrinter printer, ISorter sorter)
        {
            this.printer = printer;
            this.sorter = sorter;
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
                var scores = this.ReadScores(ScoreFilePath);
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

            this.WriteScore(name, mistakes, ScoreFilePath);
        }

        public void PrintScore()
        {
            var scores = this.ReadScores(ScoreFilePath);

            if (scores.Count == 0)
            {
                this.printer.Print(MessageForEmptyScoreboard);
                return;
            }

            List<KeyValuePair<string, int>> listOfScores = new List<KeyValuePair<string, int>>();
            foreach (var item in scores)
            {
                KeyValuePair<string, int> current = new KeyValuePair<string, int>(item.Key, item.Value);
                listOfScores.Add(current);
            }

            this.sorter.Sort(listOfScores);
            this.printer.Print("Scoreboard:");
            for (int i = 0; i < scores.Count; i++)
            {
                var scoreEntry = string.Format("{0}. {1} --> {2} mistake", i + 1, listOfScores[i].Key, listOfScores[i].Value);
                this.printer.Print(scoreEntry);
                if (i == IndexOfTheLastPersonShownOnTheScoreboard)
                {
                    break;
                }
            }

            this.printer.Print("\n");
        }

        private Dictionary<string, int> ReadScores(string filePath)
        {
            StreamReader scoresReader = new StreamReader(filePath);
            Dictionary<string, int> result = new Dictionary<string, int>();
            string currLine = string.Empty;

            using (scoresReader)
            {
                while ((currLine = scoresReader.ReadLine()) != null)
                {
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
