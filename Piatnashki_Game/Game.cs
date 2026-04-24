using System.Diagnostics;

namespace Piatnashki_Game
{
    internal class Game
    {
        public void Menu()
        {
            ConsoleKeyInfo keyInfo;
            Settings settings = new Settings();

            do { 
                Console.WriteLine("Fifteen Puzzle\n");
                Console.WriteLine("1 - Play (4x4 board)");
                Console.WriteLine("2 - Fast game (3x3 board)");
                Console.WriteLine("3 - See rules");
                Console.WriteLine("4 - Settings");
                Console.WriteLine("Esc - Exit");
                Console.WriteLine("Press the key to choose.");

                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Board board = new Board(4, 4);
                        Run(board, settings);
                        break;

                    case ConsoleKey.D2:
                        Board field = new Board(3, 3);
                        Run(field, settings);
                        break;

                    case ConsoleKey.D3:
                        Rules.ShowRules();
                        break;

                    case ConsoleKey.D4:
                        settings.SettingsMenu();
                        break;

                    case ConsoleKey.Escape:
                        Console.Write("\nBYE!");
                        break;
                    
                    default:
                        Console.Clear();
                        Console.Beep();
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        private Direction? ConvertKey(ConsoleKeyInfo keyInfo, Settings settings)
        {
            switch (settings.Controls)
            {
                case ControlsSettings.WASD:
                    if(keyInfo.Key == ConsoleKey.W)
                    {
                        return Direction.Up;
                    }
                    else if(keyInfo.Key == ConsoleKey.S)
                    {
                        return Direction.Down;
                    }
                    else if (keyInfo.Key == ConsoleKey.A)
                    {
                        return Direction.Left;
                    }
                    else if (keyInfo.Key == ConsoleKey.D)
                    {
                        return Direction.Right;
                    }
                    Console.Beep();
                    return null;

                case ControlsSettings.Arrows:
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        return Direction.Up;
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        return Direction.Down;
                    }
                    else if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        return Direction.Left;
                    }
                    else if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        return Direction.Right;
                    }
                    Console.Beep();
                    return null;
                default:
                    return null;
            }
        }

        public void Run(Board board, Settings settings)
        {
            string playerName = InputHandler.ReadNameInput();
            ConsoleKeyInfo keyInfo;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            do
            {
                Console.Clear();
                board.ShowBoard();

                Console.WriteLine($"Use {settings.Controls} to move the empty tile.");
                Console.WriteLine("Q - Give up.");

                keyInfo = Console.ReadKey(true);

                if(keyInfo.Key == ConsoleKey.Q)
                {
                    Console.Clear();
                    Console.WriteLine("\nYou decided to give up!\n");
                    return;
                }

                Direction? direction = ConvertKey(keyInfo, settings);

                if(direction != null) {
                    if (board.MoveEmptyTile(direction))
                    {

                        if (board.IsSolved())
                        {
                            stopwatch.Stop();

                            Score score = new Score(playerName, stopwatch.Elapsed);

                            //todo Call Scoremanager here
                            
                            Console.Clear();
                            board.ShowBoard();
                            Console.WriteLine("You have successfully completed the board!\n");
                            return;
                        }
                    }
                    else
                    {
                        Console.Beep();
                    }
                }
            } while (true);
        }
    }
}