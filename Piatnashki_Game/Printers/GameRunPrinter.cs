namespace Piatnashki_Game
{
    static class GamePrinter
    {
        public static void DrawGameScreen(TimeSpan timeLeft, Board board, Settings settings, int movesCount)
        {
            Console.Clear();
            Console.WriteLine("Time left: " + timeLeft.ToString(@"hh\:mm\:ss"));
            Console.WriteLine("Moves: " + movesCount);
            BoardPrinter.ShowBoard(board);

            Console.WriteLine($"Use {settings.KeyControls} to move the empty tile.");
            Console.WriteLine("Q - Give up.");
        }
    }
}
