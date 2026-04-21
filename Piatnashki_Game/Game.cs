namespace Piatnashki_Game
{
    internal class Game
    {
        public void Menu()
        {
            ConsoleKeyInfo keyInfo;
            Console.WriteLine("Fifteen Puzzle\n");

            do
            {
                Console.WriteLine("1 - Play.(4x4 board)");
                Console.WriteLine("2 - Fast game.(3x3 board)");
                Console.WriteLine("3 - See rules.");
                Console.WriteLine("Esc - Exit.");
                Console.WriteLine("Press the key to chose.");

                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Board board = new Board(4, 4);
                        Run(board);
                        break;

                    case ConsoleKey.D2:
                        Board field = new Board(3, 3);
                        Run(field);
                        break;

                    case ConsoleKey.D3:
                        Rules.ShowRules();
                        break;

                    case ConsoleKey.Escape:
                        Console.Write("\nBYE!");
                        break;
                    
                    default:
                        Console.WriteLine("\nWrong key!\n");
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        public void Run(Board board)
        {
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                board.ShowBoard();

                Console.WriteLine("W/A/S/D - Move the empty tile.");
                Console.WriteLine("Q - Give up.");

                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D:
                    case ConsoleKey.S:
                    case ConsoleKey.A:
                    case ConsoleKey.W:

                        if (board.MoveTile(keyInfo))
                        {
                            
                            if (board.IsSolved())
                            {
                                Console.WriteLine("You have successfully completed the board!");
                                return;
                            }
                        }
                        else
                        {
                            Console.Beep();
                            Console.WriteLine("\nUnable to move the tile!(Read rules for more info.)");
                            Thread.Sleep(900);
                        }
                        break;
                    case ConsoleKey.Q:
                        Console.WriteLine("\nYou decided to give up.\n");
                        return;
                }
            } while (keyInfo.Key != ConsoleKey.Q);
        }
    }
}