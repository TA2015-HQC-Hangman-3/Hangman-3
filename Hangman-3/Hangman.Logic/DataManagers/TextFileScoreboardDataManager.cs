namespace Hangman.Logic.DataManagers
{
    using System.Collections.Generic;
    using System.IO;

    using Contracts;

    /// <summary>
    /// Class representing type Data Manager as Text File Scoreboard.
    /// </summary>
    /// <typeparam name="T">The type of the parameter is dictionary.</typeparam>
    public class TextFileScoreboardDataManager<T> : IDataManager<T> where T : Dictionary<string, int>
    {
<<<<<<< HEAD
        /// <summary>
        /// Method for reading from file.
        /// </summary>
        /// <param name="filePath">The path to the file to be read from.</param>
        /// <returns>Collection of type dictionary.</returns>
        public T Read(string filePath)
=======
        private const string DefaultScorePath = "../../../Hangman.Logic/files/scores.txt";

        private readonly string scoreFilePath;

        public TextFileScoreboardDataManager()
        {
            this.scoreFilePath = DefaultScorePath;
        }

        public TextFileScoreboardDataManager(string filePath)
        {
            this.scoreFilePath = filePath;
        }

        public T Read()
>>>>>>> b6e5466bce575ebb4498be25c79f1bf7c40f1770
        {
            StreamReader scoresReader = new StreamReader(this.scoreFilePath);
            Dictionary<string, int> result = new Dictionary<string, int>();

            using (scoresReader)
            {
                while (true)
                {
                    var currLine = scoresReader.ReadLine();
                    if (currLine == null || currLine.Trim() == string.Empty)
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

            return (T)result;
        }

<<<<<<< HEAD
        /// <summary>
        /// Method for writing in file.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <param name="information">Collection containing the information to be written in dictionary.</param>
        public void Write(string filePath, T information)
=======
        public void Write(T information)
>>>>>>> b6e5466bce575ebb4498be25c79f1bf7c40f1770
        {
            StreamWriter scoreWriter = new StreamWriter(this.scoreFilePath, true);

            string name = string.Empty;
            int mistakes = 0;
            foreach (var score in information)
            {
                name = score.Key;
                mistakes = score.Value;
            }

            using (scoreWriter)
            {
                scoreWriter.WriteLine("{0} {1}", name, mistakes);
            }
        }
    }
}
