namespace Piatnashki_Game
{
    internal class ScoreManager
    {
        private string baseDir = AppDomain.CurrentDomain.BaseDirectory;

        private string filePath;

        public ScoreManager()
        { 
            string folder = Path.Combine(baseDir, "Piatnashki_Game_Score", "Score");

            Directory.CreateDirectory(folder);

            filePath = Path.Combine(folder, "score.txt");
        }

        private string ScoreToString(Score score)
        {
            return score.Name + ";" + score.Time.ToString() + ";" + score.Mode.ToString();
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

            Score score;

            for (int i = 0; i < lines.Length; i++)
            {
                parts = lines[i].Split(';');

                if (Enum.TryParse(parts[2], true, out GameMode mode))
                {
                    score = new Score(parts[0], TimeSpan.Parse(parts[1]), mode);
                }
                else
                {
                    score = new Score(parts[0], TimeSpan.Parse(parts[1]), GameMode.Default);
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
                Console.WriteLine("You have successfully cleared the scoreboard.\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }
        }

        public void ScoreBoardMenu()
        {
            ConsoleKeyInfo keyInfo;
            Console.Clear();

            do
            {
                Console.WriteLine("1 - Show scoreboard");
                Console.WriteLine("2 - Clear scoreboard");
                Console.WriteLine("Esc - Quit scoreboard menu");

                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Score.ShowScoreboard(ReadScoreFromFile());
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        ClearScoreboardFile();
                        break;

                    case ConsoleKey.Escape:
                        Console.Clear();
                        return;

                    default:
                        Console.Clear();
                        Console.Beep();
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}