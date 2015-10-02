namespace Hangman
{
    using System;
    using System.Collections.Generic;

    public class Scoreboard
    {
        private readonly IPrinter printer;
        private Dictionary<string, int> score;

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
                        this.printer.Print("This name already exists in the Scoreboard! Type another: ");
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
                this.printer.Print("Empty Scoreboard!");
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
                if (i == 4)
                {
                    // Ima izlishak ot informacia, pokazvame samo parvite 5, no pazim vsichki (izlishno moje bi)
                    break;
                }
            }

            this.printer.Print("\n");
        }
    }
}
