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
    public partial class AddorEditAttack : Form
    {
        PlayerCharacter player;
        Attack attack;
        bool addNew;
        public AddorEditAttack(PlayerCharacter pPlayer, Attack pAttack)
        {
            InitializeComponent();
            player = pPlayer;
            attack = pAttack;
            if (attack == null)
            {
                addNew = true;
                attack = new Attack();
                attack.Name = "New Attack";
                attack.Description = new string[] { "" };
                attack.BonusAttack = 0;
                attack.BonusDamage = 0;
                attack.Proficient = false;
                attack.baseStat = null;
                attack.DamageTypes = new List<string>();
                attack.DamageDice = new List<KeyValuePair<int, int>>();
            }
            else
                addNew = false;
            NameTextBox.Text = attack.Name;
            string descString = "";
            foreach (string descLine in attack.Description)
                descString += descLine + "\n";
            if (descString.Equals("\n"))
                descString = "";
            DescriptionTextBox.Text = descString;
            AttackBonus.Value = attack.BonusAttack;
            DamageBonus.Value = attack.BonusDamage;
            Proficient.Checked = attack.Proficient;
            if (attack.baseStat == null)
            {
                foreach (object item in BaseStat.Items)
                    if (((string)item).Equals("Strength"))
                        BaseStat.SelectedItem = item;
            }
            else
            {
                foreach (object item in BaseStat.Items)
                    if (((string)item).Equals(attack.baseStat.Name))
                        BaseStat.SelectedItem = item;
            }
            foreach (string damageType in attack.DamageTypes)
                foreach (Control control in this.Controls)
                    if (control is CheckBox)
                        if (control.Name.Equals(damageType))
                            ((CheckBox)control).Checked = true;
            foreach (KeyValuePair<int, int> damageDie in attack.DamageDice)
                foreach (Control control in this.Controls)
                    if (control is NumericUpDown)
                        if (control.Name.Equals("d" + damageDie.Key.ToString()))
                            ((NumericUpDown)control).Value = damageDie.Value;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            attack.Name = NameTextBox.Text;
            attack.Description = DescriptionTextBox.Text.Split('\n');
            attack.BonusAttack = (int)AttackBonus.Value;
            attack.BonusDamage = (int)DamageBonus.Value;
            attack.Proficient = Proficient.Checked;
            foreach(CoreAttribute baseStat in player.CharacterStats.CoreAttributes)
                if(baseStat.Name.Equals(BaseStat.SelectedItem.ToString()))
                {
                    attack.baseStat = baseStat;
                    break;
                }
            List<string> damageTypes = new List<string>();
            foreach (Control control in this.Controls)
                if (control is CheckBox)
                    if (((CheckBox)control).Checked)
                        damageTypes.Add(control.Name);
            attack.DamageTypes = damageTypes;
            List<KeyValuePair<int, int>> damageDice = new List<KeyValuePair<int, int>>();
            foreach (Control control in this.Controls)
                if (control is NumericUpDown)
                    if(control.Name.StartsWith("d"))
                        if (((NumericUpDown)control).Value > 0)
                            damageDice.Add(new KeyValuePair<int, int>(int.Parse(((NumericUpDown)control).Name.TrimStart('d')),(int)((NumericUpDown)control).Value));
            attack.DamageDice = damageDice;
            if (addNew)
                player.AttackList.Add(attack);
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
