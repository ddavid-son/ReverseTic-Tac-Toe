using System.Drawing;
using System.Windows.Forms;

namespace GameForms
{
    public class TileButton : Button
    {
        private Point m_TileIndices;

        public Point TileIndices
        {
            get { return m_TileIndices; }
            set { m_TileIndices = value; }
        }

        public TileButton(int i_X, int i_Y)
        {
            m_TileIndices.X = i_X;
            m_TileIndices.Y = i_Y;
        }

        public virtual void TileSymbol_Changed(string i_PlayerSymbol)
        {
            const bool v_TileButtunIsEnabled = true;
            Enabled = i_PlayerSymbol == " " ? v_TileButtunIsEnabled : !v_TileButtunIsEnabled;
            Text = i_PlayerSymbol;
            BackColor = Color.Gray;
            ForeColor = Color.Black;
            UseVisualStyleBackColor = true;
            Font = new Font(this.Name, 10f, FontStyle.Bold);
        }
    }
}