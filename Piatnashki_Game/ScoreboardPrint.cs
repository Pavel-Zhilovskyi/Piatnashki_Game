namespace Piatnashki_Game
{
    static class ScoreboardPrint
    {
        static public void ShowScoreboard(List<Score> scores)
        {
            Console.Clear();

            if(scores.Count != 0)
            {
                foreach (Score score in scores)
                {
                    Thread.Sleep(300);
                    Console.WriteLine($"{score.name} {score.time.Hours} h {score.time.Minutes} min " +
                        $"{score.time.Seconds} sec. Game mode: {score.mode}");
                }
            }
            else
            {
                Console.WriteLine("The scoreboard is empty");
            }

            Console.WriteLine();
        }
    }
}