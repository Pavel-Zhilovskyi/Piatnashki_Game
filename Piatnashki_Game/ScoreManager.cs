namespace Piatnashki_Game
{
    internal class ScoreManager
    {
        private string baseDir = AppDomain.CurrentDomain.BaseDirectory;

        private string filePath;

        public ScoreManager()
        { 
            string folder = Path.Combine(baseDir, "Piatnashki_Game", "Score");

            Directory.CreateDirectory(folder);

            filePath = Path.Combine(folder, "score.txt");
        }

        private string ScoreToString(Score score)
        {
            return score.Name + ";" + score.Time.ToString();
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
                Console.WriteLine("File not found!");
                return new List<Score>();
            }

            List<Score> scores = new List<Score>();

            string[] lines = File.ReadAllLines(filePath);
            string[] parts;

            for (int i = 0; i < lines.Length; i++)
            {
                parts = lines[i].Split(';');
                Score score = new Score(parts[0], TimeSpan.Parse(parts[1]));

                scores.Add(score);
            }

            return scores;
        }
    }
}