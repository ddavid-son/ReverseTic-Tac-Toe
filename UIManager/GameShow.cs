using GameForms;
using System.Windows.Forms;

namespace UIManager
{ 
    public class GameShow
    {
        public static void RunGame()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SettingsForm settingsForm = new SettingsForm();
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                GameBoardForm gameUIForm = new GameBoardForm(
                settingsForm.BoardSize,
                settingsForm.Player1Name,
                settingsForm.Player2Name,
                settingsForm.Player2IsComputer);

                gameUIForm.ShowDialog();
            }           
        }
    }
}