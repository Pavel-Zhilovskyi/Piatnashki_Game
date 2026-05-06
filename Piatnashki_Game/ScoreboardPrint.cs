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
                Console.WriteLine($"{score.name} {score.time.Hours} h {score.time.Minutes} min " +
                    $"{score.time.Seconds} sec. Game mode: {score.mode}");
            }

            Console.WriteLine();
            Thread.Sleep(300);
        }
    }
}