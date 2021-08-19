using System;
using System.Drawing;
using System.Windows.Forms;
using Eot_Cat_Cit;

namespace GameForms
{
    public partial class GameBoardForm : Form
    {
        private int m_BoardSize;
        private string m_Player1Name;
        private string m_Player2Name;
        private bool m_Player2IsComputer;
        private TileButton[,] m_TileButtons;
        private Label m_Player1ScoreLabel = new Label();
        private Label m_Player2ScoreLabel = new Label();
        private GameplayLogic m_GameInstance = GameplayLogic.GameInstance;

        private const float k_FontSize = 7.8f;
        private const int k_PaddingWidth = 60;
        private const int k_PaddingLength = 90;
        private const int k_CorrectPaddingBy5 = 5;
        private const int k_CorrectPaddingBy10 = 10;
        private const int k_CorrectPaddingBy30 = 30;

        public  int BoardSize
        {
            get { return m_BoardSize; }
            set { m_BoardSize = value; }
        }

        public string Player1Name
        {
            get { return m_Player1Name; }
            set { m_Player1Name = value; }
        }

        public string Player2Name
        {
            get { return m_Player2Name; }
            set { m_Player2Name = value; }
        }

        public bool Player2IsComputer
        {
            get { return m_Player2IsComputer; }
            set { m_Player2IsComputer = value; }
        }

        public GameBoardForm(int i_BoardSize, string i_Player1Name, string i_Player2Name, bool i_Player2IsComputer)
        {
            membersInitializer(i_BoardSize, i_Player1Name, i_Player2Name, i_Player2IsComputer);
            formAndBoardInitializer();
            gameBoardControlsInitializer();
            playerScoreLabelInitializer();
        }

        private void membersInitializer(int i_BoardSize, string i_Player1Name, string i_Player2Name, bool i_Player2IsComputer)
        {
            m_BoardSize = i_BoardSize;
            m_Player1Name = i_Player1Name;
            m_Player2Name = i_Player2Name;
            m_Player2IsComputer = i_Player2IsComputer;
        }

        private void formAndBoardInitializer()
        {
            m_GameInstance.BoardInstance.Size = BoardSize;
            m_GameInstance.AfterDraw += game_OnEndedWithTie;
            m_GameInstance.IsGameVsComputer = Player2IsComputer;

            m_GameInstance.Player1.PlayerName = Player1Name;
            m_GameInstance.Player1.AfterScoreIncreased += player_OnWin;
            m_GameInstance.Player1.AfterScoreIncreased += board_OnScoreChanged;

            m_GameInstance.Player2.PlayerName = Player2Name;
            m_GameInstance.Player2.AfterScoreIncreased += player_OnWin;
            m_GameInstance.Player2.AfterScoreIncreased += board_OnScoreChanged;

            Size = new Size(BoardSize * k_PaddingWidth + k_PaddingWidth, BoardSize * k_PaddingWidth + k_PaddingLength);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Text = "TicTacToeMisere";
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void game_OnEndedWithTie()
        {
            DialogResult messageBoxResult = MessageBox.Show(
              string.Format("Tie!{0} Would you like to play another round?", Environment.NewLine),
              "A Tie!", MessageBoxButtons.YesNo);

            if (messageBoxResult == DialogResult.Yes)
            {
                GameplayLogic.GameInstance.RestartGame();
            }
            else
            {
                Close();
            }
        }

        private void player_OnWin(string i_PlayerName)
        {
            DialogResult messageBoxResult = MessageBox.Show(
                string.Format("The Winner is {0}{1}Would you like to play another round?", i_PlayerName, Environment.NewLine),
                "A Win!", MessageBoxButtons.YesNo);

            if (messageBoxResult == DialogResult.Yes)
            {
                GameplayLogic.GameInstance.RestartGame();
            }
            else
            {
                this.Close();
            }
        }

        private void gameBoardControlsInitializer()
        {
            const int k_TileButtonSize = 55;
            m_TileButtons = new TileButton[BoardSize, BoardSize];

            for (int rowIndex = 0; rowIndex < BoardSize; rowIndex++)
            {
                for (int colIndex = 0; colIndex < BoardSize; colIndex++)
                {
                    m_TileButtons[rowIndex, colIndex] = new TileButton(rowIndex, colIndex);
                    m_GameInstance.BoardInstance.GameBoardArray[rowIndex, colIndex].AfterSymbolPlaced +=
                        m_TileButtons[rowIndex, colIndex].TileSymbol_Changed;
                    m_TileButtons[rowIndex, colIndex].Location = new Point(rowIndex * k_PaddingWidth + k_CorrectPaddingBy30, colIndex * k_PaddingWidth + k_CorrectPaddingBy10);
                    m_TileButtons[rowIndex, colIndex].Size = new Size(k_TileButtonSize, k_TileButtonSize);
                    m_TileButtons[rowIndex, colIndex].Click += tileButton_Clicked;
                    m_TileButtons[rowIndex, colIndex].Text = "";
                    m_TileButtons[rowIndex, colIndex].AutoSize = true;
                    m_TileButtons[rowIndex, colIndex].TabStop = false;
                    Controls.Add(m_TileButtons[rowIndex, colIndex]);
                }
            }
        }

        private void playerScoreLabelInitializer()
        {
            Controls.Add(m_Player1ScoreLabel);
            Controls.Add(m_Player2ScoreLabel);
            m_Player1ScoreLabel.AutoSize = true;
            m_Player2ScoreLabel.AutoSize = true;

            m_Player1ScoreLabel.Text = m_GameInstance.Player1.PlayerName + " : " + m_GameInstance.Player1.PlayerScore;
            m_Player1ScoreLabel.Font = new Font(m_Player1ScoreLabel.Name, k_FontSize, FontStyle.Bold);
            m_Player2ScoreLabel.Text = m_GameInstance.Player2.PlayerName + " : " + m_GameInstance.Player2.PlayerScore;

            m_Player1ScoreLabel.Top = ClientSize.Height - m_Player1ScoreLabel.Size.Height - k_CorrectPaddingBy10;
            m_Player1ScoreLabel.Left = Size.Width / 2 - m_Player1ScoreLabel.Size.Width - k_CorrectPaddingBy5;

            m_Player2ScoreLabel.Top = m_Player1ScoreLabel.Top;
            m_Player2ScoreLabel.Left = m_Player1ScoreLabel.Right + k_CorrectPaddingBy5;
        }

        private void tileButton_Clicked(object sender, EventArgs e)
        {
            TileButton currentClickedTile = sender as TileButton;
            m_GameInstance.MoveExecution(currentClickedTile.TileIndices);
            if (!m_GameInstance.IsGameVsComputer)
            {
                refreshTurnIndicator();
            }
        }

        private void refreshTurnIndicator()
        {
            if (m_GameInstance.IsItPlayer1Turn != true)
            {
                m_Player1ScoreLabel.Font = new Font(m_Player1ScoreLabel.Name, 7.8f, FontStyle.Regular);
                m_Player2ScoreLabel.Font = new Font(m_Player1ScoreLabel.Name, 7.8f, FontStyle.Bold);
            }
            else
            {
                m_Player1ScoreLabel.Font = new Font(m_Player1ScoreLabel.Name, 7.8f, FontStyle.Bold);
                m_Player2ScoreLabel.Font = new Font(m_Player1ScoreLabel.Name, 7.8f, FontStyle.Regular);
            }
        }

        private void board_OnScoreChanged(string i_PlayerName)
        {
            if (m_GameInstance.Player1.PlayerName == i_PlayerName)
            {
                m_Player1ScoreLabel.Text = string.Format("{0} : {1}",
                    i_PlayerName, m_GameInstance.Player1.PlayerScore);
            }
            else
            {
                m_Player2ScoreLabel.Text = string.Format("{0} : {1}",
                    i_PlayerName, m_GameInstance.Player2.PlayerScore);
            }
        }
    }
}
