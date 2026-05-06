namespace Piatnashki_Game
{
    static class GameRunInfoPrinter
    {
        public static void PrintRunInfo(TimeSpan timeLeft, Board board, Settings settings)
        {
            Console.Clear();
            Console.WriteLine("Time left: " + timeLeft.ToString(@"hh\:mm\:ss"));
            BoardPrinter.ShowBoard(board);

            Console.WriteLine($"Use {settings.Controls} to move the empty tile.");
            Console.WriteLine("Q - Give up.");
        }
    }
}
