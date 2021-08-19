using System.Drawing;

namespace Eot_Cat_Cit
{
    public delegate void PlayerScoreHasChangedDelegate(string playerName);

    public class Player
    {
        private int m_PlayerScore;
        private string m_PlayerName;
        private readonly char r_PlayerSymbol;
        public event PlayerScoreHasChangedDelegate AfterScoreIncreased;

        public Player(char i_Symbol)
        {
            r_PlayerSymbol = i_Symbol;
        }

        public int PlayerScore
        {
            get { return m_PlayerScore; }

            set
            {
                m_PlayerScore = value;
                OnScoreGoneUp(m_PlayerName);
            }
        }
        
        protected virtual void OnScoreGoneUp(string i_PlayerName)
        {
            if (AfterScoreIncreased != null)
            {
                AfterScoreIncreased.Invoke(PlayerName);
            }
        }

        public bool MakeAMove(Point i_CurrentMove)
        {
            bool isMoveLegal = true;

            if (GameBoard.Instance.GameBoardArray[i_CurrentMove.X, i_CurrentMove.Y].IsEmpty())
            {
                GameBoard.Instance.GameBoardArray[i_CurrentMove.X, i_CurrentMove.Y].PlayerSymbol = r_PlayerSymbol;
                GameBoard.Instance.HaveILost(i_CurrentMove.X + 1, i_CurrentMove.Y + 1);
            }
            else
            {
                isMoveLegal = false;
            }

            return isMoveLegal;
        }

        public string PlayerName
        {
            get { return m_PlayerName; }
            set { m_PlayerName = value; }
        }
    }
}