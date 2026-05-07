namespace Piatnashki_Game
{
    static class GamePrinter
    {
        public static void DrawGameScreen(TimeSpan timeLeft, Board board, Settings settings)
        {
            Console.Clear();
            Console.WriteLine("Time left: " + timeLeft.ToString(@"hh\:mm\:ss"));
            BoardPrinter.ShowBoard(board);

            Console.WriteLine($"Use {settings.Controls} to move the empty tile.");
            Console.WriteLine("Q - Give up.");
        }
    }
}
