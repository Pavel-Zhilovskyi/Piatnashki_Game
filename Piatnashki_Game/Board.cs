namespace Piatnashki_Game
{
    internal class Board
    {
        private const int rows = 4;
        private const int cols = 4;
        private int[,] board;

        private int emptyRow;
        private int emptyCol;

        private int tileToMoveRow;
        private int tileToMoveCol;

        public Board()
        {
            int[] tempArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };

            do
            {
                Random.Shared.Shuffle(tempArr);
            } while (!IsSolvable(tempArr));


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

            int emptyTileIndex = Array.IndexOf(tempArr, 0);

            int rowFromTop = emptyTileIndex / rows;

            int rowFromBottom = rows - rowFromTop;

            if ((inversionCount % 2) != (rowFromBottom % 2))
            {
                return true;
            }
            return false;
        }

        public void ShowBoard()
        {
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

        private void FindTile(int tileValue)
        {
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (board[i, j] == tileValue)
                    {
                        tileToMoveRow = i;
                        tileToMoveCol = j;
                        return;
                    }
                }
            }
        }

        private bool CanMove(int tileRow, int tileCol)
        {
            if ((tileRow - 1 == emptyRow && emptyCol == tileCol)
                || (tileRow + 1 == emptyRow && emptyCol == tileCol)
                    || (tileCol - 1 == emptyCol && emptyRow == tileRow)
                        || (tileCol + 1 == emptyCol && emptyRow == tileRow))
            {
                return true;
            }
            return false;
        }

        public bool MoveTile(int tileValue)
        {
            FindTile(tileValue);

            if (CanMove(tileToMoveRow, tileToMoveCol))
            {
                (board[tileToMoveRow, tileToMoveCol], board[emptyRow, emptyCol]) =
                    (board[emptyRow, emptyCol], board[tileToMoveRow, tileToMoveCol]);

                FindEmptyTile();
                return true;
            }
            return false;
        }

        public bool IsSolved()
        {
            int temp = 0;

            if (board[0, 0] != 1 || board[3, 3] != 0)
            {
                return false;
            }

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if(i == 3 && j == 3)
                    {
                        return true;
                    }
                    if(board[i, j] - temp != 1)
                    {
                        return false;
                    }
                    temp = board[i, j];
                }
            }
            return true;
        }
    }
}