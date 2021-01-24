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
    public partial class SkillTab : UserControl
    {
        public Stat cStat;
        private CharacterSheet charSheetMain;
        public SkillTab(Stat pStat, CharacterSheet pCharSheetMain)
        {
            InitializeComponent();
            cStat = pStat;
            charSheetMain = pCharSheetMain;
            SkillLabel.Text = cStat.Name + " (" + cStat.SubType.Substring(0,3) + ")";
        }
        public void Calculate()
        {
            if (Proficiency.Checked)
            {
                charSheetMain.player.CharacterStats.ProficiencyBonus.Calculate();
                cStat.AddModifiers("Proficiency", charSheetMain.player.CharacterStats.ProficiencyBonus.Value);
                if(Expertise.Checked) cStat.AddModifiers("Expertise", charSheetMain.player.CharacterStats.ProficiencyBonus.Value);
            }
            int result;
            string pmText = PlayerMod.Text;
            if (pmText.Contains("+")) pmText = pmText.Remove(0, 1);
            if (int.TryParse(pmText, out result)) cStat.AddModifiers("PlayerMod", result);
            cStat.Calculate();
            int statTotal = cStat.Value;
            foreach (CoreAttribute baseStat in charSheetMain.player.CharacterStats.CoreAttributes)
                if(cStat.SubType.Equals(baseStat.Name))
                {
                    baseStat.Calculate();
                    statTotal += baseStat.AbilityModifier;
                    break;
                }
            if (statTotal >= 0) SkillTotal.Text = "+" + statTotal.ToString();
            else SkillTotal.Text = statTotal.ToString();
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
                if (pmText.Contains("+")) pmText = pmText.Remove(0, 1);
                if (int.TryParse(pmText, out result))
                {
                    if (result > 30) result = 30;
                    else if (result < -30) result = -30;
                }
                else
                    result = 0;
                if (result > 0) PlayerMod.Text = "+" + result.ToString();
                else PlayerMod.Text = result.ToString();
                charSheetMain.Refresh_Click(this, null);

            }
        }

        private void IncPlayerMod_Click(object sender, EventArgs e)
        {
            int result;
            string pmText = PlayerMod.Text;
            if (pmText.Contains("+")) pmText = pmText.Remove(0, 1);
            if (int.TryParse(pmText, out result))
            {
                if (result >= 30) result = 30;
                else if (result < -30) result = -30;
                else
                    result++;
            }
            else
                result = 0;
            if (result >= 0) PlayerMod.Text = "+" + result.ToString();
            else PlayerMod.Text = result.ToString();
            charSheetMain.Refresh_Click(this, null);
        }

        private void DecPlayerMod_Click(object sender, EventArgs e)
        {
            int result;
            string pmText = PlayerMod.Text;
            if (pmText.Contains("+")) pmText = pmText.Remove(0, 1);
            if (int.TryParse(pmText, out result))
            {
                if (result > 30) result = 30;
                else if (result <= -30) result = -30;
                else
                    result--;
            }
            else
                result = 0;
            if (result >= 0) PlayerMod.Text = "+" + result.ToString();
            else PlayerMod.Text = result.ToString();
            charSheetMain.Refresh_Click(this, null);
        }

        private void Proficiency_CheckedChanged(object sender, EventArgs e)
        {
            if (!Proficiency.Checked && Expertise.Checked)
                Expertise.Checked = false;
            else
                charSheetMain.Refresh_Click(this, null);
        }

        private void Expertise_CheckedChanged(object sender, EventArgs e)
        {
            if (Expertise.Checked && !Proficiency.Checked)
                Proficiency.Checked = true;
            else
                charSheetMain.Refresh_Click(this, null);
        } 
    }
}
