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
    public partial class CharacterSheet : Form
    {
        public PlayerCharacter player;
        List<Stat> MovementTypes;

        public CharacterSheet()
        {
            InitializeComponent();
            player = new PlayerCharacter();
            InitializeCharacter();
        }

        public CharacterSheet(PlayerCharacter pPlayer)
        {
            InitializeComponent();
            player = pPlayer;
            InitializeCharacter();
        }

        private void InitializeCharacter()
        {
            foreach (CoreAttribute stat in player.CharacterStats.CoreAttributes)
            {
                CoreStatTab newStat = new CoreStatTab(stat, this);
                newStat.Tag = stat;
                CoreStatPanel.Controls.Add(newStat);
                newStat.Dock = DockStyle.Bottom;
                newStat.Calculate();
                newStat.Show();
            }
            foreach (Stat save in player.CharacterStats.Saves)
            {
                SaveTab newSave = new SaveTab(save, this);
                newSave.Tag = save;
                foreach (Stat prof in player.CharacterStats.Proficiencies)
                    if (prof.Name.Equals(newSave.cStat.Name))
                        newSave.Proficiency.Checked = true;
                SavesPanel.Controls.Add(newSave);
                newSave.Dock = DockStyle.Bottom;
                newSave.Show();
            }
            foreach (Stat skill in player.CharacterStats.Skills)
            {
                SkillTab newSkill = new SkillTab(skill, this);
                newSkill.Tag = skill;
                foreach(Stat prof in player.CharacterStats.Proficiencies)
                    if(prof.Name.Equals(newSkill.cStat.Name))
                    {
                        if (newSkill.Proficiency.Checked)
                            newSkill.Expertise.Checked = true;
                        else
                            newSkill.Proficiency.Checked = true;
                    }
                SkillPanel.Controls.Add(newSkill);
                newSkill.Dock = DockStyle.Bottom;
                newSkill.Show();
            }

            StreamReader reader = new StreamReader("Movement.json");
            string json = reader.ReadToEnd();
            MovementTypes = JsonConvert.DeserializeObject<List<Stat>>(json);
            foreach (Stat speed in MovementTypes)
            {
                if (speed.Name.Equals("Normal"))
                {
                    player.CharacterStats.Speed.Add(speed);
                    MovementTab newspeed = new MovementTab(speed, this);
                    newspeed.Tag = speed;
                    MovementPanel.Controls.Add(newspeed);
                    newspeed.Dock = DockStyle.Bottom;
                    newspeed.Show();
                }
            }
            foreach (Attack atk in player.AttackList)
            {
                AttackTab newAtk = new AttackTab(atk, this);
                newAtk.Tag = atk;
                AttackPanel.Controls.Add(newAtk);
                newAtk.Dock = DockStyle.Bottom;
                newAtk.Show();
            }

            Refresh_Click(null, null);
        }

        public void Refresh_Click(object sender, EventArgs e)
        {
            CharacterName.Text = player.CharacterName;
            player.CharacterStats.ProficiencyBonus.Reset();
            player.CharacterStats.ProficiencyBonus.Calculate();
            ProficiencyBonus.Text = "+" + player.CharacterStats.ProficiencyBonus.Value.ToString();

            Age.Text = player.CharacterStats.Age;
            cHeight.Text = player.CharacterStats.Height;
            Weight.Text = player.CharacterStats.Weight;
            Alignment.Text = player.Alignment;
            player.CharacterStats.Size.Reset();
            player.CharacterStats.Size.Calculate();
            switch(player.CharacterStats.Size.Value)
            {
                case 0:
                    cSize.Text = "Tiny";
                    break;
                case 1:
                    cSize.Text = "Small";
                    break;
                case 2:
                    cSize.Text = "Medium";
                    break;
                case 3:
                    cSize.Text = "Large";
                    break;
                case 4:
                    cSize.Text = "Huge";
                    break;
                case 5:
                    cSize.Text = "Gargantuan";
                    break;
                default:
                    cSize.Text = "";
                    break;
            }

            PlayerName.Text = player.PlayerName;
            Religion.Text = player.Religion;
            player.CharacterStats.MaxHitPoints.Reset();
            player.CharacterStats.MaxHitPoints.Calculate();
            MaxHP.Text = player.CharacterStats.MaxHitPoints.Value.ToString();

            CurrentHP.Text = player.CharacterStats.CurrentHitPoints.ToString();

            TempHP.Text = player.CharacterStats.TemporaryHitPoints.ToString();

            foreach(CoreStatTab statTab in CoreStatPanel.Controls)
            {
                ((CoreAttribute)statTab.Tag).Reset();
                statTab.Calculate();
            }
            player.CharacterStats.Initiative.Reset();
            player.CharacterStats.Initiative.Calculate();
            int totalInitiative = player.CharacterStats.Initiative.Value + player.CharacterStats.Dexterity.AbilityModifier;
            if(totalInitiative > 0) Initiative.Text = "+" + totalInitiative.ToString();
            else Initiative.Text = totalInitiative.ToString();
            player.CharacterStats.ArmorClass.Reset();
            player.CharacterStats.ArmorClass.Calculate();
            ArmorClass.Text = player.CharacterStats.ArmorClass.Value.ToString();
            foreach(SaveTab saveTab in SavesPanel.Controls)
            {
                ((Stat)saveTab.Tag).Reset();
                saveTab.Calculate();
            }

            foreach (SkillTab skillTab in SkillPanel.Controls)
            {
                ((Stat)skillTab.Tag).Reset();
                skillTab.Calculate();
            }
            List<MovementTab> removeList = new List<MovementTab>();
            bool firstThrough = true;
            foreach (Stat speed in player.CharacterStats.Speed)
            {
                bool hasTab = false;
                foreach (MovementTab MoveTab in MovementPanel.Controls)
                {
                    if (firstThrough && !player.CharacterStats.Speed.Contains(MoveTab.Tag))
                        removeList.Add(MoveTab);
                    if(speed.Equals(MoveTab.Tag))
                    {
                        ((Stat)MoveTab.Tag).Reset();
                        MoveTab.Calculate();
                        hasTab = true;
                        if (!firstThrough) break;
                    }
                }
                if(firstThrough)
                    foreach (MovementTab remove in removeList)
                        MovementPanel.Controls.Remove(remove);
                firstThrough = false;
                if(!hasTab)
                {
                    MovementTab newspeed = new MovementTab(speed, this);
                    newspeed.Tag = speed;
                    MovementPanel.Controls.Add(newspeed);
                    newspeed.Dock = DockStyle.Bottom;
                    newspeed.Calculate();
                    newspeed.Show();
                }
            }
            if(player.CharacterStats.Speed.Count == 0)
            {
                MovementPanel.Controls.Clear();
            }

            string levelString = "";
            foreach (PlayerClass pClass in player.PlayerClassList)
            {
                if (!string.IsNullOrEmpty(levelString))
                    levelString += "\n";
                levelString += "Lvl " + pClass.Level + " " + pClass.Name;
            }
            PlayerClassLabel.Text = levelString;
            TotalHitDice.Text = "";
            //CurrentHitDice.Text = "";
            string hitDiceString = "";
            foreach (KeyValuePair<int,int> HitDie in player.HitDice)
            {
                if (!string.IsNullOrEmpty(hitDiceString))
                    hitDiceString += "\\";
                hitDiceString += HitDie.Value.ToString() + "d" + HitDie.Key.ToString();
            }
            TotalHitDice.Text = hitDiceString;
            FeatDescription.Text = "";
            Feature selectedFeat = (Feature)FeatureListBox.SelectedItem;
            FeatureListBox.Items.Clear();
            foreach (Feature feat in player.FeatsNtraits)
                FeatureListBox.Items.Add(feat);
            if(FeatureListBox.Items.Count > 0)
            {
                if (selectedFeat != null && FeatureListBox.Items.Contains(selectedFeat))
                    FeatureListBox.SelectedItem = selectedFeat;
                else
                    FeatureListBox.SelectedItem = FeatureListBox.Items[0];
                Feature feat = (Feature) FeatureListBox.SelectedItem;
                string featureDesc = "";
                foreach (string featureline in feat.Description)
                    featureDesc += featureline + "\n";
                FeatDescription.Text = featureDesc;
            }

            Copper.Value = player.Copper;
            Silver.Value = player.Silver;
            Elisium.Value = player.Elisium;
            Gold.Value = player.Gold;
            Platinum.Value = player.Platinum;

            EquipmentDescription.Text = "";
            Equipment selectedEquip = (Equipment)EquipmentListBox.SelectedItem;
            EquipmentListBox.Items.Clear();
            foreach (Equipment equip in player.EquipmentList)
                EquipmentListBox.Items.Add(equip);
            if (EquipmentListBox.Items.Count > 0)
            {
                if (selectedEquip != null && EquipmentListBox.Items.Contains(selectedEquip))
                    EquipmentListBox.SelectedItem = selectedEquip;
                else
                    EquipmentListBox.SelectedItem = EquipmentListBox.Items[0];
                Equipment equip = (Equipment)EquipmentListBox.SelectedItem;
                string equipDesc = "";
                foreach (string equipline in equip.Description)
                    equipDesc += equipline + "\n";
                EquipmentDescription.Text = equipDesc;
            }
            firstThrough = true;
            bool noneSelected = true;
            List<AttackTab> remList = new List<AttackTab>();
            foreach (Attack atk in player.AttackList)
            {
                bool hasTab = false;
                foreach (AttackTab AtkTab in AttackPanel.Controls)
                {
                    if (firstThrough && !player.AttackList.Contains(AtkTab.Tag))
                        remList.Add(AtkTab);
                    if (atk.Equals(AtkTab.Tag))
                    {
                        AtkTab.Calculate();
                        hasTab = true;
                        if (AtkTab.Selected.Checked)
                            noneSelected = false;
                        if (!firstThrough) break;
                    }
                }
                if (firstThrough)
                    foreach (AttackTab remove in remList)
                        AttackPanel.Controls.Remove(remove);
                firstThrough = false;
                if (!hasTab)
                {
                    AttackTab atkTab = new AttackTab(atk, this);
                    atkTab.Tag = atk;
                    AttackPanel.Controls.Add(atkTab);
                    atkTab.Dock = DockStyle.Bottom;
                    atkTab.Calculate();
                    atkTab.Show();
                }
            }
            if (noneSelected && AttackPanel.Controls.Count > 0)
                ((AttackTab)AttackPanel.Controls[0]).Selected.Checked = true;

        }

        private void EditCharName_Click(object sender, EventArgs e)
        {
            if (EditCharName.BackColor == SystemColors.Control)
            {
                EditCharName.BackColor = SystemColors.ControlDark;
                CharacterName.ReadOnly = false;
            }
            else
            {
                EditCharName.BackColor = SystemColors.Control;
                CharacterName.ReadOnly = true;
                player.CharacterName = CharacterName.Text;
                Refresh_Click(this, null);
            }
        }

        private void EditCharStrings_Click(object sender, EventArgs e)
        {
            if (EditCharStrings.BackColor == SystemColors.Control)
            {
                EditCharStrings.BackColor = SystemColors.ControlDark;
                PlayerName.ReadOnly = false;
                Religion.ReadOnly = false;
                Alignment.ReadOnly = false;
                Age.ReadOnly = false;
                cHeight.ReadOnly = false;
                Weight.ReadOnly = false;
            }
            else
            {
                EditCharStrings.BackColor = SystemColors.Control;
                PlayerName.ReadOnly = true;
                player.PlayerName = PlayerName.Text;
                Religion.ReadOnly = true;
                player.Religion = Religion.Text;
                Alignment.ReadOnly = true;
                player.Alignment = Alignment.Text;
                Age.ReadOnly = true;
                player.CharacterStats.Age = Age.Text;
                cHeight.ReadOnly = true;
                player.CharacterStats.Height = cHeight.Text;
                Weight.ReadOnly = true;
                player.CharacterStats.Weight = Weight.Text;
                Refresh_Click(this, null);
            }
        }

        private void ProfBonusEdit_Click(object sender, EventArgs e)
        {
            if (ProfBonusEdit.BackColor == SystemColors.Control)
            {
                ProfBonusEdit.BackColor = SystemColors.ControlDark;
                ProficiencyBonus.ReadOnly = false;
            }
            else
            {
                ProfBonusEdit.BackColor = SystemColors.Control;
                ProficiencyBonus.ReadOnly = true;
                int result;
                string pbText = ProficiencyBonus.Text;
                if(pbText.Contains("+")) pbText = pbText.Remove(0, 1);
                if (int.TryParse(pbText, out result))
                {
                    if (result > 10) result = 10;
                    else if (result < 0) result = 0;
                }
                else
                    result = 0;
                player.CharacterStats.ProficiencyBonus.StatBase = result;
                player.CharacterStats.ProficiencyBonus.Reset();
                Refresh_Click(this, null);
            }
        }

        private void IncProfBonus_Click(object sender, EventArgs e)
        {
            int result = player.CharacterStats.ProficiencyBonus.StatBase;
            if (result >= 10) result = 10;
            else if (result < 0) result = 0;
            else
                result++;
            player.CharacterStats.ProficiencyBonus.StatBase = result;
            Refresh_Click(this, null);
        }

        private void DecProfBonus_Click(object sender, EventArgs e)
        {
            int result = player.CharacterStats.ProficiencyBonus.StatBase;
            if (result > 10) result = 10;
            else if (result <= 0) result = 0;
            else
                result--;
            player.CharacterStats.ProficiencyBonus.StatBase = result;
            Refresh_Click(this, null);
        }

        private void IncSize_Click(object sender, EventArgs e)
        {
            int result = player.CharacterStats.Size.StatBase;
            if (result >= 5) result = 5;
            else if (result < 0) result = 0;
            else
                result++;
            player.CharacterStats.Size.StatBase = result;
            Refresh_Click(this, null);
        }

        private void DecSize_Click(object sender, EventArgs e)
        {
            int result = player.CharacterStats.Size.StatBase;
            if (result > 5) result = 5;
            else if (result <= 0) result = 0;
            else
                result--;
            player.CharacterStats.Size.StatBase = result;
            Refresh_Click(this, null);
        }

        private void EditMaxHP_Click(object sender, EventArgs e)
        {
            if (EditMaxHP.BackColor == SystemColors.Control)
            {
                EditMaxHP.BackColor = SystemColors.ControlDark;
                MaxHP.ReadOnly = false;
            }
            else
            {
                EditMaxHP.BackColor = SystemColors.Control;
                MaxHP.ReadOnly = true;
                int result;
                string mhpText = MaxHP.Text;
                if (int.TryParse(mhpText, out result))
                {
                    if (result < 0) result = 0;
                }
                else
                    result = 0;
                player.CharacterStats.MaxHitPoints.StatBase = result;
                Refresh_Click(this, null);
            }
        }

        private void IncMaxHP_Click(object sender, EventArgs e)
        {
            int result = player.CharacterStats.MaxHitPoints.StatBase;
            if (result < 0) result = 0;
            else
                result++;
            player.CharacterStats.MaxHitPoints.StatBase = result;
            Refresh_Click(this, null);
        }

        private void DecMaxHP_Click(object sender, EventArgs e)
        {
            int result = player.CharacterStats.MaxHitPoints.StatBase;
            if (result <= 0) result = 0;
            else
                result--;
            player.CharacterStats.MaxHitPoints.StatBase = result;
            Refresh_Click(this, null);
        }

        private void EditHP_Click(object sender, EventArgs e)
        {
            if (EditHP.BackColor == SystemColors.Control)
            {
                EditHP.BackColor = SystemColors.ControlDark;
                CurrentHP.ReadOnly = false;
            }
            else
            {
                EditHP.BackColor = SystemColors.Control;
                CurrentHP.ReadOnly = true;
                int result;
                string chpText = CurrentHP.Text;
                if (int.TryParse(chpText, out result))
                {
                    if (result > player.CharacterStats.MaxHitPoints.Value) result = player.CharacterStats.MaxHitPoints.Value;
                    else if (result < 0) result = 0;
                }
                else
                    result = 0;
                player.CharacterStats.CurrentHitPoints = result;
                Refresh_Click(this, null);
            }
        }

        private void IncHP_Click(object sender, EventArgs e)
        {
            int result = player.CharacterStats.CurrentHitPoints;
            if (result >= player.CharacterStats.MaxHitPoints.Value) result = player.CharacterStats.MaxHitPoints.Value;
            else if (result < 0) result = 0;
            else
                result++;
            player.CharacterStats.CurrentHitPoints = result;
            Refresh_Click(this, null);
        }

        private void DecHP_Click(object sender, EventArgs e)
        {
            int result = player.CharacterStats.CurrentHitPoints;
            if (result > player.CharacterStats.MaxHitPoints.Value) result = player.CharacterStats.MaxHitPoints.Value;
            else if (result <= 0) result = 0;
            else
                result--;
            player.CharacterStats.CurrentHitPoints = result;
            Refresh_Click(this, null);
        }

        private void EditTempHP_Click(object sender, EventArgs e)
        {
            if (EditTempHP.BackColor == SystemColors.Control)
            {
                EditTempHP.BackColor = SystemColors.ControlDark;
                TempHP.ReadOnly = false;
            }
            else
            {
                EditTempHP.BackColor = SystemColors.Control;
                TempHP.ReadOnly = true;
                int result;
                string thpText = TempHP.Text;
                if (int.TryParse(thpText, out result))
                {
                    if (result < 0) result = 0;
                }
                else
                    result = 0;
                player.CharacterStats.TemporaryHitPoints = result;
                Refresh_Click(this, null);
            }
        }

        private void IncTempHP_Click(object sender, EventArgs e)
        {
            int result = player.CharacterStats.TemporaryHitPoints;
            if (result < 0) result = 0;
            else
                result++;
            player.CharacterStats.TemporaryHitPoints = result;
            Refresh_Click(this, null);
        }

        private void DecTempHP_Click(object sender, EventArgs e)
        {
            int result = player.CharacterStats.TemporaryHitPoints;
            if (result <= 0) result = 0;
            else
                result--;
            player.CharacterStats.TemporaryHitPoints = result;
            Refresh_Click(this, null);
        }

        private void EditInitiative_Click(object sender, EventArgs e)
        {
            if (EditInitiative.BackColor == SystemColors.Control)
            {
                EditInitiative.BackColor = SystemColors.ControlDark;
                Initiative.ReadOnly = false;
            }
            else
            {
                EditInitiative.BackColor = SystemColors.Control;
                Initiative.ReadOnly = true;
                int result;
                string iText = Initiative.Text;
                if (iText.Contains("+")) iText = iText.Remove(0, 1);
                if (int.TryParse(iText, out result))
                {
                    if (result > 30) result = 30;
                    else if (result < -30) result = -30;
                }
                else
                    result = 0;
                player.CharacterStats.Initiative.StatBase = player.CharacterStats.Initiative.StatBase + (result - player.CharacterStats.Initiative.Value);
                Refresh_Click(this, null);
            }
        }

        private void IncInitiative_Click(object sender, EventArgs e)
        {
            int result = player.CharacterStats.Initiative.StatBase;
            if (result >= 30) result = 30;
            else if (result < -30) result = -30;
            else
                result++;
            player.CharacterStats.Initiative.StatBase = result;
            Refresh_Click(this, null);
        }

        private void DecInitiative_Click(object sender, EventArgs e)
        {
            int result = player.CharacterStats.Initiative.StatBase;
            if (result > 30) result = 30;
            else if (result <= -30) result = -30;
            else
                result--;
            player.CharacterStats.Initiative.StatBase = result;
            Refresh_Click(this, null);
        }

        private void EditAC_Click(object sender, EventArgs e)
        {
            if (EditAC.BackColor == SystemColors.Control)
            {
                EditAC.BackColor = SystemColors.ControlDark;
                ArmorClass.ReadOnly = false;
            }
            else
            {
                EditAC.BackColor = SystemColors.Control;
                ArmorClass.ReadOnly = true;
                int result;
                string acText = ArmorClass.Text;
                if (int.TryParse(acText, out result))
                {
                    if (result > 50) result = 50;
                    else if (result < 0) result = 0;
                }
                else
                    result = 0;
                player.CharacterStats.ArmorClass.StatBase = player.CharacterStats.ArmorClass.StatBase + (result - player.CharacterStats.ArmorClass.Value);
                Refresh_Click(this, null);
            }
        }

        private void IncAC_Click(object sender, EventArgs e)
        {
            int result = player.CharacterStats.ArmorClass.StatBase;
            if (result >= 50) result = 50;
            else if (result < 0) result = 0;
            else
                result++;
            player.CharacterStats.ArmorClass.StatBase = result;
            Refresh_Click(this, null);
        }

        private void DecAC_Click(object sender, EventArgs e)
        {
            int result = player.CharacterStats.ArmorClass.StatBase;
            if (result > 50) result = 50;
            else if (result <= 0) result = 0;
            else
                result--;
            player.CharacterStats.ArmorClass.StatBase = result;
            Refresh_Click(this, null);
        }

        private void AddMovement_Click(object sender, EventArgs e)
        {
            MovementSelect ms = new MovementSelect(player);
            ms.ShowDialog();
            Refresh_Click(this, null);
        }

        private void EditHitDice_Click(object sender, EventArgs e)
        {
            if (EditHitDice.BackColor == SystemColors.Control)
            {
                EditHitDice.BackColor = SystemColors.ControlDark;
                TotalHitDice.ReadOnly = false;
                CurrentHitDice.ReadOnly = false;
            }
            else
            {
                List<KeyValuePair<int, int>> newHitDice = new List<KeyValuePair<int, int>>();
                EditHitDice.BackColor = SystemColors.Control;
                string hdString = TotalHitDice.Text;
                string[] hdList = hdString.Split('\\');
                foreach(string hitDie in hdList)
                {
                    int count = 0;
                    int type = 0;
                    string loweredHitDie = hitDie.ToLower();
                    string[] splitDie = loweredHitDie.Split('d');
                    if(splitDie.Length == 2)
                    {
                        int.TryParse(splitDie[0], out count);
                        int.TryParse(splitDie[1], out type);
                        if(count > 0 && type > 0)
                        {
                            newHitDice.Add(new KeyValuePair<int, int>(type, count));
                        }
                    }
                }
                if (newHitDice.Count > 0)
                    player.HitDice = newHitDice;
                TotalHitDice.ReadOnly = true;
                CurrentHitDice.ReadOnly = true;
                Refresh_Click(this, null);
            }
        }

        private void LevelUpButton_Click(object sender, EventArgs e)
        {
            ClassReference levelUp = new ClassReference(player);
            DialogResult result = levelUp.ShowDialog();
            Refresh_Click(null, null);
            
        }

        private void ClassReference_Click(object sender, EventArgs e)
        {
            ClassReference levelUp = new ClassReference(player);
            levelUp.Show();
        }

        private void AddFeatButton_Click(object sender, EventArgs e)
        {
            AddFeatDialog newFeat = new AddFeatDialog(player);
            if (newFeat.ShowDialog() == DialogResult.OK)
                Refresh_Click(null, null);
        }

        private void FeatureListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FeatureListBox.Items.Count > 0)
            {
                Feature feat = (Feature)FeatureListBox.SelectedItem;
                string featureDesc = "";
                foreach (string featureline in feat.Description)
                    featureDesc += featureline + "\n";
                FeatDescription.Text = featureDesc;
            }
        }

        private void RemoveFeatButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Remove " + ((Feature)FeatureListBox.SelectedItem).Name + " from Traits and Features?", "Remove Feat", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                player.FeatsNtraits.Remove((Feature)FeatureListBox.SelectedItem);
                Refresh_Click(null, null);
            }
        }

        private void Copper_ValueChanged(object sender, EventArgs e)
        {
            player.Copper = (int) Copper.Value;
        }

        private void Silver_ValueChanged(object sender, EventArgs e)
        {
            player.Silver = (int)Silver.Value;
        }

        private void Elisium_ValueChanged(object sender, EventArgs e)
        {
            player.Elisium = (int)Elisium.Value;
        }

        private void Gold_ValueChanged(object sender, EventArgs e)
        {
            player.Gold = (int)Gold.Value;
        }

        private void Platinum_ValueChanged(object sender, EventArgs e)
        {
            player.Platinum = (int)Platinum.Value;
        }

        private void EquipmentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EquipmentListBox.Items.Count > 0)
            {
                Equipment euip = (Equipment)EquipmentListBox.SelectedItem;
                string euipDesc = "";
                foreach (string euipline in euip.Description)
                    euipDesc += euipline + "\n";
                EquipmentDescription.Text = euipDesc;
            }
        }

        private void AddEquipButton_Click(object sender, EventArgs e)
        {
            AddEquipDialog newEquip = new AddEquipDialog(player);
            if (newEquip.ShowDialog() == DialogResult.OK)
                Refresh_Click(null, null);
        }

        private void RemoveEquipButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Remove " + ((Equipment)EquipmentListBox.SelectedItem).Name + " from Traits and Features?", "Remove Feat", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                player.EquipmentList.Remove((Equipment)EquipmentListBox.SelectedItem);
                Refresh_Click(null, null);
            }
        }

        private void AddAttackButton_Click(object sender, EventArgs e)
        {
            AddorEditAttack newAtk = new AddorEditAttack(player, null);
            DialogResult result = newAtk.ShowDialog();
            if (result == DialogResult.OK)
                Refresh_Click(null, null);
        }

        private void EditAttackButton_Click(object sender, EventArgs e)
        {
            Attack selectedAttack = null;
            foreach(Control control in AttackPanel.Controls)
                if(((AttackTab)control).Selected.Checked)
                {
                    selectedAttack = ((AttackTab)control).cAttack;
                    break;
                }
            bool doTheThing = true;
            if (selectedAttack == null)
            {
                DialogResult noSelect = MessageBox.Show("Do you wish to create a new Attack?", "Nothing Selected", MessageBoxButtons.YesNoCancel);
                if (noSelect != DialogResult.Yes)
                    doTheThing = false;
            }

            if(doTheThing)
            {
                AddorEditAttack newAtk = new AddorEditAttack(player, selectedAttack);
                DialogResult result = newAtk.ShowDialog();
                if (result == DialogResult.OK)
                    Refresh_Click(null, null);
            }

        }

        private void Save_Click(object sender, EventArgs e)
        {
            player.CharacterStats.Proficiencies = new List<Stat>();
            foreach (SaveTab saveTab in SavesPanel.Controls)
            {
                if (saveTab.Proficiency.Checked)
                    player.CharacterStats.Proficiencies.Add(saveTab.cStat);
            }

            foreach (SkillTab skillTab in SkillPanel.Controls)
            {
                if (skillTab.Proficiency.Checked)
                    player.CharacterStats.Proficiencies.Add(skillTab.cStat);
                if(skillTab.Expertise.Checked)
                    player.CharacterStats.Proficiencies.Add(skillTab.cStat);
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Character Files|*.jsc";
            sfd.Title = "Save Character";
            DialogResult result = sfd.ShowDialog();
            if(result == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(sfd.FileName);
                string json = player.SaveCharacter();
                writer.Write(json);
                writer.Close();
            }
            
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Character Files|*.jsc|All Files|*.*";
            ofd.Title = "Load Character";
            DialogResult result = ofd.ShowDialog();
            if(result == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(ofd.FileName);
                string json = reader.ReadToEnd();
                player.LoadCharacter(json);
                reader.Close();
                Refresh_Click(null, null);
                foreach (SaveTab saveTab in SavesPanel.Controls)
                {
                    saveTab.Proficiency.Checked = false;
                    foreach (Stat prof in player.CharacterStats.Proficiencies)
                        if (prof.Name.Equals(saveTab.cStat.Name))
                            saveTab.Proficiency.Checked = true;
                }

                foreach (SkillTab skillTab in SkillPanel.Controls)
                {
                    skillTab.Proficiency.Checked = false;
                    skillTab.Expertise.Checked = false;
                    foreach (Stat prof in player.CharacterStats.Proficiencies)
                        if (prof.Name.Equals(skillTab.cStat.Name))
                        {
                            if (skillTab.Proficiency.Checked)
                                skillTab.Expertise.Checked = true;
                            else
                                skillTab.Proficiency.Checked = true;
                        }
                }
            } 
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            player.newCharacter();
            player.CharacterStats.Speed.Add(MovementTypes[0]);
            foreach (SaveTab sTab in SavesPanel.Controls)
                sTab.Proficiency.Checked = false;
            foreach(SkillTab sTab in SkillPanel.Controls)
            {
                sTab.Proficiency.Checked = false;
                sTab.Expertise.Checked = false;
            }
            Refresh_Click(null, null);
        }

        private void SpellBookButton_Click(object sender, EventArgs e)
        {
            SpellBook sb = new SpellBook(this);
            sb.Show();
        }
    }
}
