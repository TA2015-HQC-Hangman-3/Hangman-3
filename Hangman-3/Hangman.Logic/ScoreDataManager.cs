namespace Hangman.Logic
{
    using Hangman.Logic.Contracts;
    using System.Collections.Generic;
    using System.IO;

    public class ScoreDataManager : IDataManager
    {
        public Dictionary<string, int> Read(string filePath)
        {
            StreamReader scoresReader = new StreamReader(filePath);
            Dictionary<string, int> result = new Dictionary<string, int>();

            using (scoresReader)
            {
                while (true)
                {
                    var currLine = scoresReader.ReadLine();
                    if (currLine == null || currLine.Trim() == "")
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

        public void Write(string name, int mistakes, string filePath)
        {
            StreamWriter scoreWriter = new StreamWriter(filePath, true);

            using (scoreWriter)
            {
                scoreWriter.WriteLine("{0} {1}", name, mistakes);
            }
        }
    }
}
