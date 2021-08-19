using System;
using System.Windows.Forms;

namespace GameForms
{
    public partial class SettingsForm : Form
    {
        private bool m_Player2IsComputer;
        private string m_Player1Name;
        private string m_Player2Name;
        private int m_BoardSize;

        public bool Player2IsComputer
        {
            get { return m_Player2IsComputer; }
        }

        public string Player1Name
        {
            get { return m_Player1Name; }
        }

        public string Player2Name
        {
            get { return m_Player2Name; }
        }

        public int BoardSize
        {
            get { return m_BoardSize; }
        }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpDownCols.Value = UpDownRows.Value;
        }

        private void Player2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Player2TextBox.Enabled = !Player2TextBox.Enabled;
            if (!Player2TextBox.Enabled)
            {
                Player2TextBox.Text = "[Computer]";
            }
        }

        private void UpDownCols_ValueChanged(object sender, EventArgs e)
        {
            UpDownRows.Value = UpDownCols.Value;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            const int k_PlayerNameMaxLength = 10;
            if (playersNameAreValid(k_PlayerNameMaxLength))
            {
                string errorMessage = string.Format(
                    "Name of players should be between 1 and {0} characters{1}and different from each other",
                    k_PlayerNameMaxLength, Environment.NewLine);
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult = DialogResult.OK;
                m_Player1Name = Player1TextBox.Text;
                m_Player2Name = Player2TextBox.Text;
                m_BoardSize = (int)UpDownRows.Value;
                m_Player2IsComputer = !Player2CheckBox.Checked;
                Close();
            }
        }

        private bool playersNameAreValid(int i_PlayerNameMaxLength)
        {
            return Player1TextBox.Text.Length > i_PlayerNameMaxLength || Player1TextBox.Text.Length < 1 ||
                   Player2TextBox.Text.Length > i_PlayerNameMaxLength || Player2TextBox.Text.Length < 1 ||
                   Player1TextBox.Text == Player2TextBox.Text;
        }
    }
}