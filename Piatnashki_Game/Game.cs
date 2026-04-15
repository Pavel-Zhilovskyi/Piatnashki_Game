namespace Piatnashki_Game
{
    internal class Game
    {
        public void Menu()
        {
            FifteenPuzzleMenu choice;
            do
            {
                Console.WriteLine("Fifteen Puzzle\n");
                Console.WriteLine("1 - Play.");
                Console.WriteLine("2 - See rules.");
                Console.WriteLine("3 - Exit.");

                choice = (FifteenPuzzleMenu)InputHandler.ReadGameOptionInput(1, 3);

                switch (choice)
                {
                    case FifteenPuzzleMenu.Play:
                        Run();
                        break;

                    case FifteenPuzzleMenu.SeeRules:
                        Rules.ShowRules();
                        break;

                    case FifteenPuzzleMenu.Exit:
                        Console.Write("\nBYE!");
                        break;
                }
            } while (choice != FifteenPuzzleMenu.Exit);
        }

        public void Run()
        {
            Board board = new Board();
            FifteenPuzzleRun choice;
            Console.Clear();

            do
            {
                board.ShowBoard();

                Console.WriteLine("1 - Move the tile.");
                Console.WriteLine("2 - Give up.");

                choice = (FifteenPuzzleRun)InputHandler.ReadGameOptionInput(1, 2);

                switch (choice)
                {
                    case FifteenPuzzleRun.MoveTile:
                        int tile = InputHandler.ReadTileNumber();

                        if (board.MoveTile(tile))
                        {
                            Console.WriteLine("The tile was successfully moved.");
                            
                            if (board.IsSolved())
                            {
                                Console.WriteLine("You have successfully completed the board!");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nUnable to move the tile!(Read rules for more info.)");
                        }
                        break;
                    case FifteenPuzzleRun.GiveUp:
                        Console.WriteLine("\nYou decided to give up.\n");
                        return;
                }
            } while (choice != FifteenPuzzleRun.GiveUp);
        }
    }
}