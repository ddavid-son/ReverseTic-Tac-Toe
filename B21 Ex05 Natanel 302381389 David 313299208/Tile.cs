namespace Eot_Cat_Cit
{
    public delegate void TileSymbolWasChangedDelegate(string i_Symbol);
    public struct Tile
    {
        private char m_PlayerSymbol;
        private const char k_EmptyMark = ' ';
        public event TileSymbolWasChangedDelegate AfterSymbolPlaced;

        public char PlayerSymbol
        {
            get
            {
                if (m_PlayerSymbol == 0)
                {
                    m_PlayerSymbol = k_EmptyMark;
                }

                return m_PlayerSymbol;
            }
            set
            {
                m_PlayerSymbol = value;
                OnSymbolChanged();
            }
        }

        private void OnSymbolChanged()
        {
            if (AfterSymbolPlaced != null)
            {
                AfterSymbolPlaced.Invoke(m_PlayerSymbol.ToString());
            }
        }

        public bool IsEmpty()
        {
            return PlayerSymbol == k_EmptyMark;
        }

        public void ClearTile()
        {
            PlayerSymbol = k_EmptyMark;
        }
    }
}