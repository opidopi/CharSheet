using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Character_Sheet
{
    public partial class SpellBook : Form
    {
        CharacterSheet charSheetMain;
        int spellSaveBonus;
        int spellAttackBonus;
        public SpellBook(CharacterSheet pCharSheet)
        {
            charSheetMain = pCharSheet;
            InitializeComponent();
            StreamReader reader = new StreamReader("AllSpells.json");
            string json = reader.ReadToEnd();
            List<Spell> allSpells = JsonConvert.DeserializeObject<List<Spell>>(json);
            foreach (Spell spell in allSpells)
                allSpellList.Items.Add(spell);
            ClassCombo.Items.Add("Bard");
            ClassCombo.Items.Add("Cleric");
            ClassCombo.Items.Add("Druid");
            ClassCombo.Items.Add("Paladin");
            ClassCombo.Items.Add("Ranger");
            ClassCombo.Items.Add("Sorcerer");
            ClassCombo.Items.Add("Warlock");
            ClassCombo.Items.Add("Wizard");
            ClassCombo.SelectedItem = ClassCombo.Items[ClassCombo.Items.Count - 1];
            foreach (Stat cStat in charSheetMain.player.CharacterStats.CoreAttributes)
                if(cStat.Name.Equals("Intelligence")|| cStat.Name.Equals("Wisdom")||
                    cStat.Name.Equals("Charisma")) AbilityCombo.Items.Add(cStat);
            AbilityCombo.SelectedItem = AbilityCombo.Items[0];
            spellSaveBonus = 0;
            spellAttackBonus = 0;

            refreshCalcs();
        }

        private void refreshCalcs()
        {
            int totalAB = 0;
            totalAB += ((CoreAttribute)AbilityCombo.SelectedItem).AbilityModifier;
            totalAB += charSheetMain.player.CharacterStats.ProficiencyBonus.Value;
            totalAB += spellAttackBonus;
            string totalABstring = "";
            if (totalAB >= 0)
                totalABstring += "+";
            totalABstring += totalAB.ToString();
            AttackBonus.Text = totalABstring;
            int spellSaveDC = 8;
            spellSaveDC += ((CoreAttribute)AbilityCombo.SelectedItem).AbilityModifier;
            spellSaveDC += charSheetMain.player.CharacterStats.ProficiencyBonus.Value;
            spellSaveDC += spellSaveBonus;
            if (spellSaveDC < 0)
                spellSaveDC = 0;
            SaveDC.Value = spellSaveDC;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("Allspells.json");
            string json = reader.ReadToEnd();
            string[] firstPass = json.Split(',');
            List<string> alteredLines = new List<string>();
            bool descTrigger = false;
            bool hlTrigger = false;
            bool uolTrigger = false;
            bool dcTrigger = false;
            foreach (string line in firstPass)
            {
                string newLine = line;
                if (newLine.Contains("\"School\":"))
                {
                    if (!newLine.StartsWith("{"))
                        newLine = newLine.Insert(3, "{");
                    newLine = newLine.Insert(4, "\"Name\":");
                    for (int i = 0; i < newLine.Length; i++)
                    {
                        char cAtIndex = newLine[i];
                        if (cAtIndex == ':' && i < newLine.Length - 5)
                        {
                            char cAtIplus2 = newLine[i + 5];
                            if (cAtIplus2 == '{')
                            {
                                newLine = newLine.Remove(i, 6);
                                newLine = newLine.Insert(i, ",");
                                break;
                            }
                        }
                    }
                }
                else if (descTrigger || newLine.Contains("\"Description\":"))
                {
                    if (newLine.EndsWith("]"))
                    {
                        newLine = newLine.TrimEnd(']');
                        descTrigger = false;
                    }
                    else
                        descTrigger = true;
                }                    
                else if (newLine.Contains("\"Book\":"))
                    newLine = newLine.Insert(3, "],");
                else if (hlTrigger || newLine.Contains("\"Higher Levels\":"))
                {
                    if(!hlTrigger)
                    {
                        newLine = newLine.TrimStart(new char[] { '\"', '\n', '\r', 'H', 'i', 'g', 'h', 'e', 'r', ' ', 'L', 'v', 'l', 's' });
                        newLine = newLine.TrimStart(new char[] { '\n', '\r', ':', ' ', '[' });
                    }

                    if (newLine.EndsWith("]"))
                    {
                        newLine = newLine.TrimEnd(']');
                        hlTrigger = false;
                    }
                    else
                        hlTrigger = true;
                }
                else if (uolTrigger || newLine.Contains("\"Unordered List\":") || newLine.Contains("\"Ordered List\":"))
                {
                    if (!uolTrigger)
                    {
                        newLine = newLine.TrimStart(new char[] { '\"', '\n', '\r', 'O', 'U', 'n', 'o', 'r', 'd', 'e', 'L', ' ', 'i', 't', 's' });
                        newLine = newLine.TrimStart(new char[] { '\n', '\r', ':', ' ', '[' });
                    }

                    if (newLine.EndsWith("]"))
                    {
                        newLine = newLine.TrimEnd(']');
                        uolTrigger = false;
                    }
                    else
                        uolTrigger = true;
                }
                else if (dcTrigger || newLine.Contains("\"Description-cont\":"))
                {
                    if (!dcTrigger)
                    {
                        newLine = newLine.TrimStart(new char[] { '\"', '\n', '\r', 'D', 'e', 's', 'c', 'r', 'i', ' ', 'p', 't', 'o', 'n', '-' });
                        newLine = newLine.TrimStart(new char[] { '\n', '\r', ':', ' ', '[' });
                    }

                    if (newLine.EndsWith("]"))
                    {
                        newLine = newLine.TrimEnd(']');
                        dcTrigger = false;
                    }
                    else
                        dcTrigger = true;
                }
                alteredLines.Add(newLine);
            }
            string output = "";
            foreach(string line in alteredLines)
            {
                if (!string.IsNullOrEmpty(output) && !line.Contains("\"Book\":"))
                    output += ",";
                output += line;
            }
            StreamWriter writer = new StreamWriter("AllSpells_Altered.json");
            writer.Write(output);
            writer.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("AllSpells_Manual_Edit.json");
            string json = reader.ReadToEnd();
            List<Spell> allSpells = JsonConvert.DeserializeObject<List<Spell>>(json);

        }

        private void SaveDC_ValueChanged(object sender, EventArgs e)
        {
            spellSaveBonus = (int)SaveDC.Value - (8 + ((CoreAttribute)AbilityCombo.SelectedItem).AbilityModifier
                    + charSheetMain.player.CharacterStats.ProficiencyBonus.Value);

        }

        private void ABup_Click(object sender, EventArgs e)
        {
            spellAttackBonus++;
            refreshCalcs();
        }

        private void ABdown_Click(object sender, EventArgs e)
        {
            spellAttackBonus--;
            refreshCalcs();
        }
    }
}
