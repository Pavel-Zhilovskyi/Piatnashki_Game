using System.Diagnostics;

namespace Piatnashki_Game
{
    static class Game
    {
        public static void Run(Board board, Settings settings, ScoreStorage scoreStorage, GameMode mode)
        {
            string playerName = InputHandler.ReadNameInput();
            ConsoleKeyInfo keyInfo;
            TimeSpan timerLimit = settings.GetGameTimerMode(mode);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while(stopwatch.Elapsed < timerLimit)
            {
                TimeSpan timeLeft = timerLimit - stopwatch.Elapsed;

                GamePrinter.DrawGameScreen(timeLeft, board, settings);

                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Q)
                    {
                        HandleGiveUp(stopwatch);
                        return;
                    }

                    Direction? direction = KeyInputConverter.ConvertKey(keyInfo, settings);

                    if (direction != null) {
                        if (board.MoveEmptyTile(direction))
                        {
                            if (board.IsSolved())
                            {
                                stopwatch.Stop();

                                Score score = new Score(playerName, stopwatch.Elapsed, mode);

                                scoreStorage.WriteScoreFile(score);

                                Console.Clear();
                                BoardPrinter.ShowBoard(board);
                                GameResultPrinter.PrintGameResult(GameResult.Win);
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
            GameResultPrinter.PrintGameResult(GameResult.Timeout);
        }

        private static void HandleGiveUp(Stopwatch stopwatch)
        {
            stopwatch.Stop();
            GameResultPrinter.PrintGameResult(GameResult.GiveUp);
        }
    }
}