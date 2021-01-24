using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Character_Sheet
{
    public partial class MovementSelect : Form
    {
        PlayerCharacter player;
        public MovementSelect(PlayerCharacter pPlayer)
        {
            player = pPlayer;
            InitializeComponent();

            StreamReader reader = new StreamReader("Movement.json");
            string json = reader.ReadToEnd();
            List<Stat> moveList = JsonConvert.DeserializeObject<List<Stat>>(json);
            foreach (Stat stat in moveList)
                MoveCombo.Items.Add(stat);
            MoveCombo.SelectedItem = MoveCombo.Items[0];
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MoveCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(((Stat)MoveCombo.SelectedItem).Name.Equals("Other"))
            {
                NewNameLabel.Visible = true;
                NewNameLabel.Enabled = true;
                NewNameTextbox.Visible = true;
                NewNameTextbox.Enabled = true;
            }
            else
            {
                NewNameLabel.Visible = false;
                NewNameLabel.Enabled = false;
                NewNameTextbox.Visible = false;
                NewNameTextbox.Enabled = false;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Stat newMove = new Stat();
            if (((Stat)MoveCombo.SelectedItem).Name.Equals("Other"))
            {
                if (!string.IsNullOrEmpty(NewNameTextbox.Text))
                    newMove.Name = NewNameTextbox.Text;
                else
                {
                    MessageBox.Show("No Custom Name Entered!");
                    return;
                }
            }
            else
                newMove.Name = MoveCombo.Text;
            newMove.Type = "Speed";
            int speed = 0;
            if (int.TryParse(SpeedTextBox.Text, out speed))
            {
                newMove.StatBase = speed - speed % 5;
            }
            player.CharacterStats.Speed.Add(newMove);
            Close();
        }
    }
}
