namespace Piatnashki_Game
{
    static class ScoreboardPrint
    {
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