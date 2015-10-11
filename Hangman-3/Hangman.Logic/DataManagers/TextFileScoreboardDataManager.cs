// <copyright file="TextFileScoreboardDataManager.cs" company="Team Hangman 3">
// All rights reserved.
// </copyright>
// <summary>Class TextFileScoreboardDataManager.</summary>
// <author>Team Hangman 3</author>
namespace Hangman.Logic.DataManagers
{
    using System.Collections.Generic;
    using System.IO;

    using Contracts;

    /// <summary>
    /// Implements the transfer of information about the game state from and to text file.
    /// </summary>
    /// <typeparam name="T">The type of object that deals with saving and loading the game.</typeparam>
    public class TextFileScoreboardDataManager<T> : IDataManager<T> where T : Dictionary<string, int>
    {
        private const string DefaultScorePath = "../../../Hangman.Logic/files/scores.txt";

        private readonly string scoreFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileScoreboardDataManager{T}"/> class.
        /// </summary>
        public TextFileScoreboardDataManager()
        {
            this.scoreFilePath = DefaultScorePath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileScoreboardDataManager{T}"/> class.
        /// </summary>
        /// <param name="filePath">Specifies the path to the text file.</param>
        public TextFileScoreboardDataManager(string filePath)
        {
            this.scoreFilePath = filePath;
        }

        /// <summary>
        /// Implements the reading from the file.
        /// </summary>
        /// <returns>Object of the specified type.</returns>
        public T Read()
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

        /// <summary>
        /// Implements the writing in the text file.
        /// </summary>
        /// <param name="information">Specifies the information written in the file.</param>
        public void Write(T information)
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
