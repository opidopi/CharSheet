using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Character_Sheet
{
    public partial class LoadForm : Form
    {
        CharacterSheet charSheetMain;
        PlayerCharacter player;
        public LoadForm(CharacterSheet pCharSheetMain, PlayerCharacter pPlayer)
        {
            InitializeComponent();
            charSheetMain = pCharSheetMain;
            player = pPlayer;
        }

        private void LoadForm_Load(object sender, EventArgs e)
        { 
            charSheetMain.Close();
            charSheetMain = new CharacterSheet(player);
            charSheetMain.Show();
            Close();
        }
    }
}
