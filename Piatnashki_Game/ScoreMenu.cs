namespace Piatnashki_Game
{
    internal class ScoreMenu
    {
        public void ScoreBoardMenu(ScoreStorage scoreStorage)
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
                        Score.ShowScoreboard(scoreStorage.ReadScoreFromFile());
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        scoreStorage.ClearScoreboardFile();
                        Console.WriteLine("You have successfully cleared the scoreboard!\n");
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