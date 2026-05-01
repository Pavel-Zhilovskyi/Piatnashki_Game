using System.Diagnostics;

namespace Piatnashki_Game
{
    internal class Game
    {
        public void Menu()
        {
            ConsoleKeyInfo keyInfo;
            
            SettingsManager settingsManager = new SettingsManager();
            Settings settings = settingsManager.LoadSettingsFromFile();
            SettingsMenuUI settingsMenu = new SettingsMenuUI();
            ScoreManager scoreManager = new ScoreManager();

            do { 
                Console.WriteLine("Fifteen Puzzle\n");
                Console.WriteLine("1 - Play (4x4 board)");
                Console.WriteLine("2 - Fast game (3x3 board)");
                Console.WriteLine("3 - Scoreboard");
                Console.WriteLine("4 - See rules");
                Console.WriteLine("5 - Settings");
                Console.WriteLine("Esc - Exit");
                Console.WriteLine("Press the key to choose.\n");

                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Board board = new Board(4, 4);
                        Run(board, settings, scoreManager, GameMode.Classic);
                        break;

                    case ConsoleKey.D2:
                        Board field = new Board(3, 3);
                        Run(field, settings, scoreManager, GameMode.FastGame);
                        break;

                    case ConsoleKey.D3:
                        scoreManager.ScoreBoardMenu();
                        break;

                    case ConsoleKey.D4:
                        Rules.ShowRules();
                        break;

                    case ConsoleKey.D5:
                        settingsMenu.SettingsMenu(settings, settingsManager);
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

        public void Run(Board board, Settings settings, ScoreManager scoreManager, GameMode mode)
        {
            string playerName = InputHandler.ReadNameInput();
            ConsoleKeyInfo keyInfo;
            TimeSpan timerLimit;

            switch (mode)
            {
                case GameMode.Classic:
                    timerLimit = settings.Time4x4;
                    break;

                case GameMode.FastGame:
                    timerLimit = settings.Time3x3;
                    break;

                default:
                    throw new InvalidOperationException("GameMode must be defined!");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while(stopwatch.Elapsed < timerLimit)
            {
                Console.Clear();
                TimeSpan timeLeft = timerLimit - stopwatch.Elapsed;
                Console.WriteLine("Time left: " + timeLeft.ToString(@"hh\:mm\:ss"));
                board.ShowBoard();

                Console.WriteLine($"Use {settings.Controls} to move the empty tile.");
                Console.WriteLine("Q - Give up.");

                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Q)
                    {
                        stopwatch.Stop();
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

                                Score score = new Score(playerName, stopwatch.Elapsed, mode);

                                scoreManager.WriteScoreFile(score);

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
                }
                Thread.Sleep(30);
            }
            Console.WriteLine("\nTime is out!\n");
        }
    }
}