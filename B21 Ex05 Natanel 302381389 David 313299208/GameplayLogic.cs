using System;
using System.Drawing;

namespace Eot_Cat_Cit
{
    public delegate void GameEndesWithDrawDelegate();

    public class GameplayLogic
    {
        public event GameEndesWithDrawDelegate AfterDraw;

        public bool MoveExecution(Point i_CurrentMove)
        {
            bool wasMoveSuccessful = false;

            if (i_CurrentMove.X < 0 || i_CurrentMove.X >= BoardInstance.Size || i_CurrentMove.Y < 0 || i_CurrentMove.Y >= BoardInstance.Size)
            {
                wasMoveSuccessful = false;
            }
            else
            {
                wasMoveSuccessful = m_IsItPlayer1Turn ? player1.MakeAMove(i_CurrentMove) : player2.MakeAMove(i_CurrentMove);
                IsGameOver = BoardInstance.IsGameOver;

                if (wasMoveSuccessful)
                {
                    if (IsGameOver)
                    {
                        QuitGame();
                    }
                    else if (BoardInstance.BoardIsFull())
                    {
                        QuitGame();
                    }
                    else if (IsGameVsComputer == true && !IsGameOver && !BoardInstance.BoardIsFull())
                    {
                        Point aIMove = calculateAIMove(i_CurrentMove);
                        player2.MakeAMove(aIMove);
                        IsGameOver = BoardInstance.IsGameOver;

                        if (IsGameOver)
                        {
                            m_IsItPlayer1Turn = !m_IsItPlayer1Turn;
                            QuitGame();
                        }
                        if(BoardInstance.BoardIsFull())
                        {
                            QuitGame();
                        }
                    }
                    else
                    {
                        m_IsItPlayer1Turn = !m_IsItPlayer1Turn;
                    }
                }
            }

            return wasMoveSuccessful;
        }

        public int GetPlayerScore(int i_PlayerNumber)
        {
            return i_PlayerNumber == k_One ? player1.PlayerScore : player2.PlayerScore;
        }

        public GameBoard BoardInstance
        {
            get
            {
                return m_BoardInstance;
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

        public static GameplayLogic GameInstance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new GameplayLogic();
                }

                return s_Instance;
            }
        }

        public void QuitGame()
        {
            if (BoardInstance.BoardIsFull() && IsGameOver == false)
            {
                if(AfterDraw != null)
                {
                    AfterDraw.Invoke();
                }
            }
            else if (m_IsItPlayer1Turn)
            {
                player2.PlayerScore++;
            }
            else
            {
                player1.PlayerScore++;
            }

            IsGameOver = true;
        }

        public void RestartGame()
        {
            BoardInstance.CleanBoard();
            BoardInstance.IsGameOver = false;
            IsGameOver = false;
            m_IsItPlayer1Turn = true;
        }

        private GameplayLogic()
        {
            player1 = new Player(k_PlayerOneMark);
            player2 = new Player(k_PlayerTwoMark);
            m_IsItPlayer1Turn = true;
            IsGameVsComputer = false;
            IsGameOver = false;
            m_BoardInstance = GameBoard.Instance;
        }

        private Point calculateAIMove(Point i_Player1LastMove)
        {
            Point aIMove = new Point(s_Instance.BoardInstance.Size - 1, s_Instance.BoardInstance.Size - 1);
            aIMove.X -= i_Player1LastMove.X;
            aIMove.Y -= i_Player1LastMove.Y;
            
            if (!BoardInstance.IsTileEmpty(aIMove.X, aIMove.Y))
            {
                Random randomGenerator = new Random();
                while (v_WaitingForAValidComputerMove)
                {
                    aIMove.X = randomGenerator.Next(GameBoard.Instance.Size);
                    aIMove.Y = randomGenerator.Next(GameBoard.Instance.Size);

                    if (BoardInstance.IsTileEmpty(aIMove.X, aIMove.Y))
                    {
                        break;
                    }
                }
            }
           
            return aIMove;
        }

        public Player Player1
        {
            get { return player1; }
        }

        public Player Player2
        {
            get { return player2; }
        }

        public bool IsItPlayer1Turn
        {
            get { return m_IsItPlayer1Turn; }
        }

        public bool IsGameVsComputer { get; set; }

        private Player player1;
        private Player player2;
        private bool m_IsGameOver;
        private const int k_One = 1;
        private bool m_IsItPlayer1Turn;
        private  GameBoard m_BoardInstance;
        private const char k_PlayerOneMark = 'X';
        private const char k_PlayerTwoMark = 'O';
        private static GameplayLogic s_Instance = null;
        private const bool v_WaitingForAValidComputerMove = true;
    }
}
