namespace Piatnashki_Game;

static class BoardPrinter
{
    public static void ShowBoard(Board board)
    {
        Console.WriteLine();
        for (int i = 0; i < board.Rows; i++)
        {
            for (int j = 0; j < board.Cols; j++)
            {
                int value = board.GetValue(i, j);

                if (value > 0 && value < 10)
                {
                    Console.Write(value + "  ");
                }
                else if (value == 0)
                {
                    Console.Write("_" + "  ");
                }
                else
                {
                    Console.Write(value + " ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}