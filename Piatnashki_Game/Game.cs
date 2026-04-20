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
                Console.WriteLine("1 - Play.");
                Console.WriteLine("2 - See rules.");
                Console.WriteLine("Esc - Exit.");
                Console.WriteLine("Press the key to chose.");

                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Run();
                        break;

                    case ConsoleKey.D2:
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

        public void Run()
        {
            Board board = new Board(3, 3);
            ConsoleKeyInfo keyInfo;
            

            do
            {
                Console.Clear();
                board.ShowBoard();

                Console.WriteLine("W/A/S/D - Move the tile.");
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