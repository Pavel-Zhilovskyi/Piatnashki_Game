namespace Piatnashki_Game
{
    internal class Board
    {
        private readonly int[,] solvedBoard;
        private int rows;
        private int cols;

        private int[,] board;

        private int emptyRow;
        private int emptyCol;

        public Board(int Rows, int Cols)
        {
            rows = Rows;
            cols = Cols;
            int[] tempArr;

            switch ((rows, cols))
            {
                case (4, 4):
                    solvedBoard = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
                    tempArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
                    break;

                case (3, 3):
                    solvedBoard = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
                    tempArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            do
            {
                Random.Shared.Shuffle(tempArr);
            } while (!IsSolvable(tempArr) || IsSolved(tempArr));


            board = new int[rows, cols];

            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = tempArr[index++];
                }
            }
            FindEmptyTile();
        }

        private bool IsSolvable(int[] tempArr)
        {
            int inversionCount = 0;

            for (int i = 0; i < tempArr.Length; i++)
            {
                for (int j = i + 1; j < tempArr.Length; j++)
                {
                    if (tempArr[i] != 0 && tempArr[j] != 0)
                    {
                        if (tempArr[i] > tempArr[j])
                        {
                            inversionCount++;
                        }
                    }
                }
            }

            if (rows == 4 && cols == 4)
            {
                int emptyTileIndex = Array.IndexOf(tempArr, 0);

                int rowFromTop = emptyTileIndex / rows;

                int rowFromBottom = rows - rowFromTop;

                if ((inversionCount % 2) != (rowFromBottom % 2))
                {
                    return true;
                }
                return false;
            }
            
            if (inversionCount % 2 == 0)
            {
                return true;
            }
            return false;
        }

        public void ShowBoard()
        {
            Console.Write("\n");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i, j] > 0 && board[i, j] < 10)
                    {
                        Console.Write(board[i, j] + "  ");
                    }
                    else if (board[i, j] == 0)
                    {
                        Console.Write("_" + "  ");
                    }
                    else
                    {
                        Console.Write(board[i, j] + " ");
                    }
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        private void FindEmptyTile()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i, j] == 0)
                    {
                        emptyRow = i;
                        emptyCol = j;
                        return;
                    }
                }

            }
        }

        private bool CanMove(ConsoleKeyInfo keyInfo)
        {
            if ((keyInfo.Key == ConsoleKey.W && emptyRow > 0 && emptyRow <= rows) ||
                (keyInfo.Key == ConsoleKey.S && emptyRow >= 0 && emptyRow < rows - 1) ||
                (keyInfo.Key == ConsoleKey.A && emptyCol > 0 && emptyCol <= cols) ||
                (keyInfo.Key == ConsoleKey.D && emptyCol >= 0 && emptyCol < cols - 1))
            {
                return true;
            }
            return false;
        }

        public bool MoveTile(ConsoleKeyInfo keyInfo)
        {
            if (CanMove(keyInfo))
            {
                if (keyInfo.Key == ConsoleKey.W)
                {
                    (board[emptyRow, emptyCol], board[emptyRow - 1, emptyCol]) =
                        (board[emptyRow - 1, emptyCol], board[emptyRow, emptyCol]);
                }
                else if (keyInfo.Key == ConsoleKey.S)
                {
                    (board[emptyRow, emptyCol], board[emptyRow + 1, emptyCol]) =
                        (board[emptyRow + 1, emptyCol], board[emptyRow, emptyCol]);
                }
                else if (keyInfo.Key == ConsoleKey.A)
                {
                    (board[emptyRow, emptyCol], board[emptyRow, emptyCol - 1]) =
                        (board[emptyRow, emptyCol - 1], board[emptyRow, emptyCol]);
                }
                else if (keyInfo.Key == ConsoleKey.D)
                {
                    (board[emptyRow, emptyCol], board[emptyRow, emptyCol + 1]) =
                        (board[emptyRow, emptyCol + 1], board[emptyRow, emptyCol]);
                }

                FindEmptyTile();
                return true;
            }
            return false;
        }

        private bool IsSolved(int[] tempArr)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (tempArr[i * cols + j] != solvedBoard[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsSolved()
        {
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (board[i, j] != solvedBoard[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}