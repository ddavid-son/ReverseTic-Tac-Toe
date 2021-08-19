namespace Eot_Cat_Cit
{
    public class GameBoard
    {
        public int Size
        {
            get
            {
                return m_Size;
            }
            set
            {
                m_Size = value;
                m_BoardGame = new Tile[value, value];
                CleanBoard();
            }
        }

        public bool IsGameOver
        {
            get
            {
                return m_IsGameOver;
            }
            set
            {
                m_IsGameOver = value;
            }
        }

        public static GameBoard Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new GameBoard();
                }

                return m_instance;
            }
        }

        public void CleanBoard()
        {
            for (int index = 0; index < m_instance.Size; index++)
            {
                for (int index2 = 0; index2 < m_instance.Size; index2++)
                {
                    m_instance.GameBoardArray[index, index2].ClearTile();
                }
            }
        }

        public bool IsTileEmpty(int i_XAxis, int i_YAxis)
        {
            return (m_instance.m_BoardGame[i_XAxis, i_YAxis].PlayerSymbol) == ' ';
        }

        public char GetCharFromBoard(int i_X, int i_Y)
        {
            return m_BoardGame[i_X, i_Y].PlayerSymbol;
        }

        public Tile[,] GameBoardArray
        {
            get
            {
                return m_BoardGame;
            }
        }

        public void HaveILost(int i_X, int i_Y)
        {
            if (losingRow(i_X) || losingCol(i_Y) || losingDiagonal(i_X, i_Y))
            {
                m_IsGameOver = true;
            }
        }

        private GameBoard()
        {
            m_Size = 0;
            m_BoardGame = null;
            m_IsGameOver = false;
        }

        private bool losingRow(int i_X)
        {
            bool losingLine = true;
            for (int i = 1; i < Instance.m_Size; i++)
            {
                if (Instance.m_BoardGame[i_X - 1, 0].PlayerSymbol != Instance.m_BoardGame[i_X - 1, i].PlayerSymbol)
                {
                    losingLine = false;
                    break;
                }
            }

            return losingLine;
        }

        private bool losingCol(int i_Y)
        {
            bool losingCol = true;
            for (int i = 1; i < Instance.m_Size; i++)
            {
                if (Instance.m_BoardGame[0, i_Y - 1].PlayerSymbol != Instance.m_BoardGame[i, i_Y - 1].PlayerSymbol)
                {
                    losingCol = false;
                    break;
                }
            }

            return losingCol;
        }

        private bool losingDiagonal(int i_X, int i_Y)
        {
            bool losingDiagonal = false;

            if (i_X == i_Y)
            {
                losingDiagonal = mainDiagonalLose();
            }

            if (i_X + i_Y == Instance.m_Size + 1)
            {
                losingDiagonal = secondaryDiagonalLose();
            }

            return losingDiagonal;
        }

        private bool mainDiagonalLose()
        {
            bool losingMainDiagonal = true;

            for (int i = 1, j = 1; i < Instance.m_Size;)
            {
                if (Instance.m_BoardGame[0, 0].PlayerSymbol != Instance.m_BoardGame[i++, j++].PlayerSymbol)
                {
                    losingMainDiagonal = false;
                    break;
                }
            }

            return losingMainDiagonal;
        }

        public bool BoardIsFull()
        {
            bool boardIsAlreadyFull = true;

            foreach (Tile tile in Instance.m_BoardGame)
            {
                if (tile.IsEmpty())
                {
                    boardIsAlreadyFull = false;
                    break;
                }
            }

            return boardIsAlreadyFull;
        }

        private bool secondaryDiagonalLose()
        {
            bool losingSecondaryDiagonal = true;

            for (int i = Instance.m_Size - 2, j = 1; j < Instance.m_Size;)
            {
                if (Instance.m_BoardGame[Instance.m_Size - 1, 0].PlayerSymbol != Instance.m_BoardGame[i--, j++].PlayerSymbol)
                {
                    losingSecondaryDiagonal = false;
                    break;
                }
            }

            return losingSecondaryDiagonal;
        }

        private int m_Size;
        private bool m_IsGameOver;
        private Tile[,] m_BoardGame;
        private static GameBoard m_instance;
    } 
}