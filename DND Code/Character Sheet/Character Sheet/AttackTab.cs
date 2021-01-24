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
    public partial class AttackTab : UserControl
    {
        public Attack cAttack;
        private CharacterSheet charSheetMain;
        public AttackTab(Attack pAttack, CharacterSheet pCharSheetMain)
        {
            InitializeComponent();
            cAttack = pAttack;
            charSheetMain = pCharSheetMain;
            NameLabel.Text = cAttack.Name;
        }

        public void Calculate()
        {
            string damageString = "";
            string damageTypeString = "";
            int atkBonus = 0;
            foreach (string dmgType in cAttack.DamageTypes)
            {
                if (string.IsNullOrEmpty(damageTypeString))
                    damageTypeString = dmgType;
                else
                    damageTypeString += ", " + dmgType;
            }
            DamageLabel.Text = damageTypeString;
            foreach(KeyValuePair<int,int> dmgDie in cAttack.DamageDice)
            {
                if (string.IsNullOrEmpty(damageString))
                    damageString = dmgDie.Value.ToString() + "d" + dmgDie.Key.ToString();
                else
                    damageString += " + " + dmgDie.Value.ToString() + "d" + dmgDie.Key.ToString();
            }
            int flatDmg = cAttack.BonusDamage + cAttack.baseStat.AbilityModifier;
            if (!string.IsNullOrEmpty(damageString) && flatDmg > 0)
                damageString += " + ";
            damageString += flatDmg.ToString();
            DamageTotal.Text = damageString;
            if (cAttack.Proficient)
            {
                charSheetMain.player.CharacterStats.ProficiencyBonus.Calculate();
                atkBonus += charSheetMain.player.CharacterStats.ProficiencyBonus.Value;
            }
            atkBonus += cAttack.baseStat.AbilityModifier;
            atkBonus += cAttack.BonusAttack;
            if (atkBonus > 0)
                AttackTotal.Text = "+" + atkBonus.ToString();
            else
                AttackTotal.Text = atkBonus.ToString();
        }

        private void Selected_CheckedChanged(object sender, EventArgs e)
        {     
            foreach (AttackTab aTab in charSheetMain.AttackPanel.Controls)
                aTab.Selected.Checked = false;
            this.Selected.Checked = true;
        }
    }
}
