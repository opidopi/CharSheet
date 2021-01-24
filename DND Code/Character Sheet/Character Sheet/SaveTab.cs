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
    public partial class SaveTab : UserControl
    {
        public Stat cStat;
        private CharacterSheet charSheetMain;
        public SaveTab(Stat pStat, CharacterSheet pCharSheetMain)
        {
            InitializeComponent();
            cStat = pStat;
            charSheetMain = pCharSheetMain;
            SaveLabel.Text = cStat.Name;
        }
        public void Calculate()
        {
            
            if (Proficiency.Checked)
            {
                charSheetMain.player.CharacterStats.ProficiencyBonus.Calculate();
                cStat.AddModifiers("Proficiency", charSheetMain.player.CharacterStats.ProficiencyBonus.Value);
            }
            int result = cStat.StatBase;
            string pmText = "";
            if (result > 0) pmText += "+";
            pmText += result.ToString();
            PlayerMod.Text = pmText;
            cStat.Calculate();
            int statTotal = cStat.Value;
            foreach (CoreAttribute baseStat in charSheetMain.player.CharacterStats.CoreAttributes)
            {
                string trimmedName = cStat.Name.Remove(cStat.Name.Length - 5, 5);
                if (baseStat.Name.Equals(trimmedName))
                {
                    baseStat.Calculate();
                    statTotal += baseStat.AbilityModifier;
                    break;
                }
            }
                
            if (statTotal >= 0) SaveTotal.Text = "+" + statTotal.ToString();
            else SaveTotal.Text = statTotal.ToString();
        }

        private void Proficiency_CheckedChanged(object sender, EventArgs e)
        {
            charSheetMain.Refresh_Click(this, null);
        }

        private void EditPlayermod_Click(object sender, EventArgs e)
        {
            if (EditPlayermod.BackColor == SystemColors.Control)
            {
                EditPlayermod.BackColor = SystemColors.ControlDark;
                PlayerMod.ReadOnly = false;
            }
            else
            {
                EditPlayermod.BackColor = SystemColors.Control;
                PlayerMod.ReadOnly = true;
                int result;
                string pmText = PlayerMod.Text;
                if (pmText.Contains("+")) pmText = pmText.Remove('+');
                if (!int.TryParse(pmText, out result))
                    result = 0;
                cStat.StatBase = result;
                charSheetMain.Refresh_Click(this, null);

            }
        }

        private void IncPlayerMod_Click(object sender, EventArgs e)
        {
            cStat.StatBase++;
            charSheetMain.Refresh_Click(this, null);
        }

        private void DecPlayerMod_Click(object sender, EventArgs e)
        {
            cStat.StatBase--;
            charSheetMain.Refresh_Click(this, null);
        }
    }
}
