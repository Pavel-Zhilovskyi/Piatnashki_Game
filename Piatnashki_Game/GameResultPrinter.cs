namespace Piatnashki_Game
{
    static class GameResultPrinter
    {
        public static void PrintGameResult(GameResult result)
        {
            switch(result)
            {
                case GameResult.Win:
                    Console.WriteLine("You have successfully completed the board!\n");
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
