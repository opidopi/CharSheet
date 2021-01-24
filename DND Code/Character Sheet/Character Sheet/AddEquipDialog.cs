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
    public partial class AddEquipDialog : Form
    {
        PlayerCharacter player;

        public AddEquipDialog(PlayerCharacter pPlayer)
        {
            InitializeComponent();
            Equipment customEquip = new Equipment();
            customEquip.Name = "Custom";
            customEquip.Description = new string[] { "" };
            EquipCombo.Items.Add(customEquip);
            EquipCombo.SelectedItem = EquipCombo.Items[0];
            player = pPlayer;
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            Equipment selectedEquip = (Equipment)EquipCombo.SelectedItem;
            selectedEquip.Name = NameTextBox.Text;
            selectedEquip.Description = DescriptionTextBox.Text.Split('\n');
            player.EquipmentList.Add(selectedEquip);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void EquipCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Equipment equipment = (Equipment)EquipCombo.SelectedItem;
            NameTextBox.Text = equipment.Name;
            string equipDesc = "";
            foreach (string featureline in equipment.Description)
                equipDesc += featureline + "\n";
            if (equipDesc.Equals("\n"))
                equipDesc = "";
            DescriptionTextBox.Text = equipDesc;
            if (equipment.Name.Equals("Custom"))
            {
                NameTextBox.ReadOnly = false;
                DescriptionTextBox.ReadOnly = false;
            }
            else
            {
                NameTextBox.ReadOnly = true;
                DescriptionTextBox.ReadOnly = true;
            }
        }
    }
}
