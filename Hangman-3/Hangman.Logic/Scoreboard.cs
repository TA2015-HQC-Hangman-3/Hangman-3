namespace Hangman
{
    using System;
    using System.Collections.Generic;

    public class Scoreboard
    {
        public const int IndexOfTheLastPersonShownOnTheScoreboard = 4;
        public const string MessageWhenNameAlreadyExistsInTheScoreBoard = "This name already exists in the Scoreboard! Type another: ";
        public const string MessageForEmptyScoreboard = "Scoreboard is empty!";
        
        // private Dictionary<string, int> score;
        private readonly IPrinter printer;

        public Scoreboard(IPrinter printer)
        {
            this.Score = new Dictionary<string, int>();
            this.printer = printer;
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
                foreach (var item in this.Score)
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

            this.Score.Add(name, mistakes);
        }

        public void PrintScore()
        {
            if (this.Score.Count == 0)
            {
                this.printer.Print(MessageForEmptyScoreboard);
                return;
            }

            List<KeyValuePair<string, int>> key = new List<KeyValuePair<string, int>>();
            foreach (var item in this.Score)
            {
                KeyValuePair<string, int> current = new KeyValuePair<string, int>(item.Key, item.Value);
                key.Add(current);
            }

            key.Sort(new OutComparer());
            this.printer.Print("Scoreboard:");
            for (int i = 0; i < this.Score.Count; i++)
            {
                var scoreEntry = string.Format("{0}. {1} --> {2} mistake", i + 1, key[i].Key, key[i].Value);
                this.printer.Print(scoreEntry);
                if (i == IndexOfTheLastPersonShownOnTheScoreboard)
                {
                    break;
                }
            }

            this.printer.Print("\n");
        }
    }
}
