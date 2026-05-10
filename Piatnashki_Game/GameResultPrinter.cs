namespace Piatnashki_Game
{
    static class GameResultPrinter
    {
        public static void PrintGameResult(GameResult result, TimeSpan time = default, int movesCount = 0)
        {
            switch(result)
            {
                case GameResult.Win:
                    Console.WriteLine("You have successfully completed the board!\n");
                    Console.WriteLine("Time: " + time.ToString(@"hh\:mm\:ss"));
                    Console.WriteLine("Moves: " + movesCount + "\n");
                    break;

                case GameResult.GiveUp:
                    Console.Clear();
                    Console.WriteLine("\nYou decided to give up!\n");
                    break;

                case GameResult.Timeout:
                    Console.WriteLine("\nTime is out!\n");
                    break;
            }
        }
    }
}
