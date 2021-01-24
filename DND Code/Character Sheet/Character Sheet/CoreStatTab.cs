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
    public partial class CoreStatTab : UserControl
    {
        private CoreAttribute cStat;
        private CharacterSheet charSheetMain;
        public CoreStatTab(CoreAttribute pStat, CharacterSheet pCharSheetMain)
        {
            InitializeComponent();
            cStat = pStat;
            charSheetMain = pCharSheetMain;
            StatName.Text = cStat.Name;
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (Edit.BackColor == SystemColors.Control)
            {
                Edit.BackColor = SystemColors.ControlDark;
                StatBase.ReadOnly = false;
            }
            else
            {
                Edit.BackColor = SystemColors.Control;
                StatBase.ReadOnly = true;
                int result;
                if (int.TryParse(StatBase.Text, out result))
                {
                    if (result > 30) result = 30;
                    else if (result < 0) result = 0;
                }
                else
                    result = 0;
                cStat.StatBase = result;
                charSheetMain.Refresh_Click(this, null);

            }
        }

        public void Calculate()
        {
            cStat.Calculate();
            StatBase.Text = cStat.StatBase.ToString();
            if (cStat.AbilityModifier >= 0)
                Modifier.Text = "+" + cStat.AbilityModifier.ToString();
            else
                Modifier.Text = cStat.AbilityModifier.ToString();
        }

        private void Increase_Click(object sender, EventArgs e)
        {
            int result = cStat.StatBase;
            if (result >= 30) result = 30;
            else if (result < 0) result = 0;
            else
                result++;
            cStat.StatBase = result;
            charSheetMain.Refresh_Click(this, null);

        }

        private void Decrease_Click(object sender, EventArgs e)
        {
            int result = cStat.StatBase;
            if (result > 30) result = 30;
            else if (result <= 0) result = 0;
            else
                result--;
            cStat.StatBase = result;
            charSheetMain.Refresh_Click(this, null);
        }
    }
}
