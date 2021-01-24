using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Character_Sheet
{
    public partial class MovementTab : UserControl
    {
        private Stat cStat;
        private CharacterSheet charSheetMain;
        public MovementTab(Stat pStat, CharacterSheet pCharSheetMain)
        {
            InitializeComponent();
            cStat = pStat;
            charSheetMain = pCharSheetMain;
            MovementName.Text = cStat.Name;
        }

        public void Calculate()
        {
            cStat.Calculate();
            Speed.Text = cStat.Value.ToString();
        }

        private void EditSpeed_Click(object sender, EventArgs e)
        {
            if (EditSpeed.BackColor == SystemColors.Control)
            {
                EditSpeed.BackColor = SystemColors.ControlDark;
                Speed.ReadOnly = false;
            }
            else
            {
                EditSpeed.BackColor = SystemColors.Control;
                Speed.ReadOnly = true;
                int result;
                string acText = Speed.Text;
                if (int.TryParse(acText, out result))
                {
                    if (result > 1000) result = 1000;
                    else if (result < 0) result = 0;
                    else result = result - (result % 5);
                }
                else
                    result = 0;
                cStat.StatBase = cStat.StatBase + (result - cStat.Value);
                charSheetMain.Refresh_Click(this, null);
            }
        }

        private void IncSpeed_Click(object sender, EventArgs e)
        {
            int result = cStat.StatBase;
            if (result >= 1000) result = 1000;
            else if (result < 0) result = 0;
            else
            {
                result += 5;
                result = result - (result % 5);
            }
            cStat.StatBase = result;
            charSheetMain.Refresh_Click(this, null);
        }

        private void DecSpeed_Click(object sender, EventArgs e)
        {
            int result = cStat.StatBase;
            if (result > 1000) result = 1000;
            else if (result <= 0) result = 0;
            else
            {
                result -= 5;
                result = result - (result % 5);
            }
            cStat.StatBase = result;
            charSheetMain.Refresh_Click(this, null);
        }

        private void RemoveMovement_Click(object sender, EventArgs e)
        {
            charSheetMain.player.CharacterStats.Speed.Remove((Stat)this.Tag);
            this.Parent.Controls.Remove(this);
            Dispose();
        }
    }
}
