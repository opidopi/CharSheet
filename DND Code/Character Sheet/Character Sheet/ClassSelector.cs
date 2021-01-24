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
    public partial class ClassSelector : Form
    {
        PlayerCharacter player;
        public PlayerClass chosenClass;
        public ClassSelector(PlayerCharacter pPlayer)
        {
            InitializeComponent();
            player = pPlayer;
            foreach (PlayerClass pClass in player.PlayerClassList)
                ClassComboBox.Items.Add(pClass);
            if (ClassComboBox.Items.Count > 0)
                ClassComboBox.SelectedItem = ClassComboBox.Items[0];
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            chosenClass = (PlayerClass)ClassComboBox.SelectedItem;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void ClassSelector_Load(object sender, EventArgs e)
        {
            if (ClassComboBox.Items.Count == 0)
            {
                MessageBox.Show("No Character Classes found!\nSet a Class Level first!");
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
