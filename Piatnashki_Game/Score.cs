namespace Piatnashki_Game
{
    internal class Score
    {
        public string Name { get; }

        public TimeSpan Time { get; }

        public GameMode Mode { get; }

        public Score(string name, TimeSpan time, GameMode mode)
        {
            Name = name;
            Time = time;
            Mode = mode;
        }

        static public void ShowScoreboard(List<Score> scores)
        {
            Console.Clear();

            foreach (Score score in scores)
            {
                Thread.Sleep(300);
                Console.WriteLine($"{score.Name} {score.Time.Hours} h {score.Time.Minutes} min " +
                    $"{score.Time.Seconds} sec. Game mode: {score.Mode}");
            }
            Console.WriteLine();
            Thread.Sleep(300);
        }
    }
}