namespace Piatnashki_Game
{
    internal class ScoreStorage
    {
        private string baseDir = AppDomain.CurrentDomain.BaseDirectory;

        private string filePath;

        public ScoreStorage()
        { 
            string folder = Path.Combine(baseDir, "Piatnashki_Game_Score", "Score");

            Directory.CreateDirectory(folder);

            filePath = Path.Combine(folder, "score.txt");
        }

        private string ScoreToString(Score score)
        {
            return score.Name + ";" + score.Time.ToString(@"hh\:mm\:ss") + ";" + score.Mode.ToString();
        }

        public void WriteScoreFile(Score score)
        {
            try
            {
                File.AppendAllText(filePath, ScoreToString(score) + "\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Score> ReadScoreFromFile()
        {
            if (!File.Exists(filePath))
            {
                return new List<Score>();
            }

            List<Score> scores = new List<Score>();

            string[] lines = File.ReadAllLines(filePath);
            string[] parts;

            Score score;

            foreach(string line in lines) 
            {
                parts = line.Split(';');

                if (parts.Length != 3)
                {
                    continue;
                } 
                else if(!TimeSpan.TryParse(parts[1], out TimeSpan time))  
                {
                    continue;
                }
                else if(!Enum.TryParse(parts[2], true, out GameMode mode))
                {
                    continue;
                }
                else
                {
                    score = new Score(parts[0], time, mode);
                }

                scores.Add(score);
            }

            return scores;
        }

        public void ClearScoreboardFile()
        {
            try
            {
                File.WriteAllText(filePath, string.Empty);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }
        }
    }
}