using System.Diagnostics;
using Piatnashki_Game.Enums;

namespace Piatnashki_Game
{
    internal class Game
    {
        private int movesCount;
        private bool isFirstMove;

        public Game()
        {
            movesCount = 0;
            isFirstMove = true;
        }

        public void Run(Board board, Settings settings, ScoreStorage scoreStorage, GameMode mode)
        {
            string playerName = InputHandler.ReadNameInput();
            ConsoleKeyInfo keyInfo;
            TimeSpan timerLimit = settings.GetGameTimerMode(mode);

            Stopwatch stopwatch = new Stopwatch();

            while(stopwatch.Elapsed < timerLimit)
            {
                TimeSpan timeLeft = timerLimit - stopwatch.Elapsed;

                GamePrinter.DrawGameScreen(timeLeft, board, settings, movesCount);

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
                            if (isFirstMove)
                            {
                                stopwatch.Start();
                                SetIsFirstMoveFalse();
                            }

                            InreaseMovesCount();

                            if (board.IsSolved())
                            {
                                stopwatch.Stop();

                                Score score = new Score(playerName, stopwatch.Elapsed, mode);

                                scoreStorage.WriteScoreFile(score);

                                Console.Clear();
                                BoardPrinter.ShowBoard(board);
                                GameResultPrinter.PrintGameResult(GameResult.Win, stopwatch.Elapsed, movesCount);
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

        private void InreaseMovesCount()
        {
            movesCount++;
        }

        private void SetIsFirstMoveFalse()
        {
            isFirstMove = false;
        }

        private static void HandleGiveUp(Stopwatch stopwatch)
        {
            stopwatch.Stop();
            GameResultPrinter.PrintGameResult(GameResult.GiveUp);
        }
    }
}