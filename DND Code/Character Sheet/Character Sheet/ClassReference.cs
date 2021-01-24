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
    public partial class ClassReference : Form
    {
        public PlayerCharacter player;
        ClassImport classList;
        public ClassReference(PlayerCharacter pPlayer)
        {
            InitializeComponent();
            player = pPlayer;
            Import();
            string classLabelText = "";
            foreach(PlayerClass cClass in player.PlayerClassList)
            {
                if (!string.IsNullOrEmpty(classLabelText))
                    classLabelText += "\n";
                classLabelText += "Lvl " + cClass.Level.ToString() + " " + cClass.Name +
                    " - " + cClass.SubClass;
            }
            ClassLabel.Text = classLabelText;
        }

        public void Show()
        {
            SetLevelButton.Enabled = false;
            RemoveClassButton.Enabled = false;
            ResetFeaturesButton.Enabled = false;
            CancelButton.Enabled = false;
            LevelSetter.Enabled = false;
            LevelUpButton.Enabled = false;
            base.Show();
        }

        private void Import()
        {
            //StreamReader reader = new StreamReader("C:\\Osmose\\DND Code\\DND Code\\CharTest2.json");
            StreamReader reader = new StreamReader("PlayerClasses.json");
            string json = reader.ReadToEnd();
            classList = JsonConvert.DeserializeObject<ClassImport>(json);
            for (int i = 0; i < 12; i++)
            {
                TabPage newPage = new TabPage();
                ClassTabs.TabPages.Add(newPage);
                ClassPage newClassPage = new ClassPage();
                newPage.Controls.Add(newClassPage);
                newClassPage.Dock = DockStyle.Fill;
                string classname = null;
                switch(i)
                {
                    case 0:
                        newPage.Text = classList.Barbarian.Table.Title;
                        DataTable BarbTable = new DataTable();
                        foreach (string header in classList.Barbarian.Table.Headers)
                            BarbTable.Columns.Add(header);
                        foreach (ClassImport.BarbTable.BarbRow row in classList.Barbarian.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            BarbTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.Rages, row.RageDamage });
                        }
                        newClassPage.ClassTable.DataSource = BarbTable;
                        foreach (ClassImport.Feature feature in classList.Barbarian.ClassFeatures)
                        {
                            FeatureBox newFeature = new FeatureBox();
                            newFeature.label1.Text = feature.Name;
                            string featureDesc = "";
                            foreach (string featureline in feature.Description)
                                featureDesc += featureline + "\n";
                            newFeature.richTextBox1.Text = featureDesc;
                            newClassPage.panel1.Controls.Add(newFeature);
                            newFeature.Dock = DockStyle.Bottom;
                        }
                        foreach(ClassImport.SubClass subClass in classList.Barbarian.PrimalPaths)
                        {
                            SubClassTab newSubClassTab = new SubClassTab();
                            DataTable featureTable = new DataTable();
                            string subClassDesc = "";
                            foreach (string descLine in subClass.Description)
                                subClassDesc += descLine + "\n";
                            newSubClassTab.label1.Text = subClassDesc;
                            foreach (string header in subClass.FeaturesTable.Headers)
                                featureTable.Columns.Add(header);
                            foreach (ClassImport.FeatureTable.FeatureRow row in subClass.FeaturesTable.Rows)
                            {
                                string featureList = "";
                                if (row.Features.Length > 0)
                                    featureList = row.Features[0];
                                for (int j = 1; j < row.Features.Length; j++)
                                    featureList += ", " + row.Features[j];
                                featureTable.Rows.Add(new object[] { row.Level, featureList });
                            }
                            newSubClassTab.SubClassTable.DataSource = featureTable;
                            foreach(ClassImport.Feature feature in subClass.SubClassFeatures)
                            {
                                FeatureBox newFeature = new FeatureBox();
                                newFeature.label1.Text = feature.Name;
                                string featureDesc = "";
                                foreach (string featureline in feature.Description)
                                    featureDesc += featureline + "\n";
                                newFeature.richTextBox1.Text = featureDesc;
                                newSubClassTab.panel1.Controls.Add(newFeature);
                                newFeature.Dock = DockStyle.Bottom;
                            }
                            TabPage newSubPage = new TabPage();
                            newSubPage.Text = subClass.Name;
                            newSubPage.Controls.Add(newSubClassTab);
                            newSubClassTab.Dock = DockStyle.Fill;
                            newClassPage.SubClassTabs.Controls.Add(newSubPage);
                        }
                        break;
                    case 1:
                        newPage.Text = classList.Bard.Table.Title;
                        DataTable BardTable = new DataTable();
                        foreach (string header in classList.Bard.Table.Headers)
                            BardTable.Columns.Add(header);
                        foreach (ClassImport.BardTable.BardRow row in classList.Bard.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            BardTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.CantripsKnown, row.SpellsKnown, row.First, row.Second, row.Third, row.Fourth, row.Fifth, row.Sixth, row.Seventh, row.Eighth, row.Ninth});
                        }
                        newClassPage.ClassTable.DataSource = BardTable;
                        foreach (ClassImport.Feature feature in classList.Bard.ClassFeatures)
                        {
                            FeatureBox newFeature = new FeatureBox();
                            newFeature.label1.Text = feature.Name;
                            string featureDesc = "";
                            foreach (string featureline in feature.Description)
                                featureDesc += featureline + "\n";
                            newFeature.richTextBox1.Text = featureDesc;
                            newClassPage.panel1.Controls.Add(newFeature);
                            newFeature.Dock = DockStyle.Bottom;
                        }
                        foreach (ClassImport.SubClass subClass in classList.Bard.BardColleges)
                        {
                            SubClassTab newSubClassTab = new SubClassTab();
                            DataTable featureTable = new DataTable();
                            string subClassDesc = "";
                            foreach (string descLine in subClass.Description)
                                subClassDesc += descLine + "\n";
                            newSubClassTab.label1.Text = subClassDesc;
                            foreach (string header in subClass.FeaturesTable.Headers)
                                featureTable.Columns.Add(header);
                            foreach (ClassImport.FeatureTable.FeatureRow row in subClass.FeaturesTable.Rows)
                            {
                                string featureList = "";
                                if (row.Features.Length > 0)
                                    featureList = row.Features[0];
                                for (int j = 1; j < row.Features.Length; j++)
                                    featureList += ", " + row.Features[j];
                                featureTable.Rows.Add(new object[] { row.Level, featureList });
                            }
                            newSubClassTab.SubClassTable.DataSource = featureTable;
                            foreach (ClassImport.Feature feature in subClass.SubClassFeatures)
                            {
                                FeatureBox newFeature = new FeatureBox();
                                newFeature.label1.Text = feature.Name;
                                string featureDesc = "";
                                foreach (string featureline in feature.Description)
                                    featureDesc += featureline + "\n";
                                newFeature.richTextBox1.Text = featureDesc;
                                newSubClassTab.panel1.Controls.Add(newFeature);
                                newFeature.Dock = DockStyle.Bottom;
                            }
                            TabPage newSubPage = new TabPage();
                            newSubPage.Text = subClass.Name;
                            newSubPage.Controls.Add(newSubClassTab);
                            newSubClassTab.Dock = DockStyle.Fill;
                            newClassPage.SubClassTabs.Controls.Add(newSubPage);
                        }
                        break;
                    case 2:
                        newPage.Text = classList.Cleric.Table.Title;
                        DataTable ClericTable = new DataTable();
                        foreach (string header in classList.Cleric.Table.Headers)
                            ClericTable.Columns.Add(header);
                        foreach (ClassImport.ClericTable.ClericRow row in classList.Cleric.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            ClericTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.CantripsKnown, row.First, row.Second, row.Third, row.Fourth, row.Fifth, row.Sixth, row.Seventh, row.Eighth, row.Ninth });
                        }
                        newClassPage.ClassTable.DataSource = ClericTable;
                        foreach (ClassImport.Feature feature in classList.Cleric.ClassFeatures)
                        {
                            FeatureBox newFeature = new FeatureBox();
                            newFeature.label1.Text = feature.Name;
                            string featureDesc = "";
                            foreach (string featureline in feature.Description)
                                featureDesc += featureline + "\n";
                            newFeature.richTextBox1.Text = featureDesc;
                            newClassPage.panel1.Controls.Add(newFeature);
                            newFeature.Dock = DockStyle.Bottom;
                        }
                        foreach (ClassImport.SubClass subClass in classList.Cleric.DivineDomains)
                        {
                            SubClassTab newSubClassTab = new SubClassTab();
                            DataTable featureTable = new DataTable();
                            string subClassDesc = "";
                            foreach (string descLine in subClass.Description)
                                subClassDesc += descLine + "\n";
                            newSubClassTab.label1.Text = subClassDesc;
                            foreach (string header in subClass.FeaturesTable.Headers)
                                featureTable.Columns.Add(header);
                            foreach (ClassImport.FeatureTable.FeatureRow row in subClass.FeaturesTable.Rows)
                            {
                                string featureList = "";
                                if (row.Features.Length > 0)
                                    featureList = row.Features[0];
                                for (int j = 1; j < row.Features.Length; j++)
                                    featureList += ", " + row.Features[j];
                                featureTable.Rows.Add(new object[] { row.Level, featureList });
                            }
                            newSubClassTab.SubClassTable.DataSource = featureTable;
                            foreach (ClassImport.Feature feature in subClass.SubClassFeatures)
                            {
                                FeatureBox newFeature = new FeatureBox();
                                newFeature.label1.Text = feature.Name;
                                string featureDesc = "";
                                foreach (string featureline in feature.Description)
                                    featureDesc += featureline + "\n";
                                newFeature.richTextBox1.Text = featureDesc;
                                newSubClassTab.panel1.Controls.Add(newFeature);
                                newFeature.Dock = DockStyle.Bottom;
                            }
                            TabPage newSubPage = new TabPage();
                            newSubPage.Text = subClass.Name;
                            newSubPage.Controls.Add(newSubClassTab);
                            newSubClassTab.Dock = DockStyle.Fill;
                            newClassPage.SubClassTabs.Controls.Add(newSubPage);
                        }
                        break;
                    case 3:
                        newPage.Text = classList.Druid.Table.Title;
                        DataTable DruidTable = new DataTable();
                        foreach (string header in classList.Druid.Table.Headers)
                            DruidTable.Columns.Add(header);
                        foreach (ClassImport.DruidTable.DruidRow row in classList.Druid.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            DruidTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.CantripsKnown, row.First, row.Second, row.Third, row.Fourth, row.Fifth, row.Sixth, row.Seventh, row.Eighth, row.Ninth });
                        }
                        newClassPage.ClassTable.DataSource = DruidTable;
                        foreach (ClassImport.Feature feature in classList.Druid.ClassFeatures)
                        {
                            FeatureBox newFeature = new FeatureBox();
                            newFeature.label1.Text = feature.Name;
                            string featureDesc = "";
                            foreach (string featureline in feature.Description)
                                featureDesc += featureline + "\n";
                            newFeature.richTextBox1.Text = featureDesc;
                            newClassPage.panel1.Controls.Add(newFeature);
                            newFeature.Dock = DockStyle.Bottom;
                        }
                        foreach (ClassImport.SubClass subClass in classList.Druid.DruidCircles)
                        {
                            SubClassTab newSubClassTab = new SubClassTab();
                            DataTable featureTable = new DataTable();
                            string subClassDesc = "";
                            foreach (string descLine in subClass.Description)
                                subClassDesc += descLine + "\n";
                            newSubClassTab.label1.Text = subClassDesc;
                            foreach (string header in subClass.FeaturesTable.Headers)
                                featureTable.Columns.Add(header);
                            foreach (ClassImport.FeatureTable.FeatureRow row in subClass.FeaturesTable.Rows)
                            {
                                string featureList = "";
                                if (row.Features.Length > 0)
                                    featureList = row.Features[0];
                                for (int j = 1; j < row.Features.Length; j++)
                                    featureList += ", " + row.Features[j];
                                featureTable.Rows.Add(new object[] { row.Level, featureList });
                            }
                            newSubClassTab.SubClassTable.DataSource = featureTable;
                            foreach (ClassImport.Feature feature in subClass.SubClassFeatures)
                            {
                                FeatureBox newFeature = new FeatureBox();
                                newFeature.label1.Text = feature.Name;
                                string featureDesc = "";
                                foreach (string featureline in feature.Description)
                                    featureDesc += featureline + "\n";
                                newFeature.richTextBox1.Text = featureDesc;
                                newSubClassTab.panel1.Controls.Add(newFeature);
                                newFeature.Dock = DockStyle.Bottom;
                            }
                            TabPage newSubPage = new TabPage();
                            newSubPage.Text = subClass.Name;
                            newSubPage.Controls.Add(newSubClassTab);
                            newSubClassTab.Dock = DockStyle.Fill;
                            newClassPage.SubClassTabs.Controls.Add(newSubPage);
                        }
                        break;
                    case 4:
                        newPage.Text = classList.Fighter.Table.Title;
                        DataTable FighterTable = new DataTable();
                        foreach (string header in classList.Fighter.Table.Headers)
                            FighterTable.Columns.Add(header);
                        foreach (ClassImport.FightTable.FightRow row in classList.Fighter.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            FighterTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features });
                        }
                        newClassPage.ClassTable.DataSource = FighterTable;
                        foreach (ClassImport.Feature feature in classList.Fighter.ClassFeatures)
                        {
                            FeatureBox newFeature = new FeatureBox();
                            newFeature.label1.Text = feature.Name;
                            string featureDesc = "";
                            foreach (string featureline in feature.Description)
                                featureDesc += featureline + "\n";
                            newFeature.richTextBox1.Text = featureDesc;
                            newClassPage.panel1.Controls.Add(newFeature);
                            newFeature.Dock = DockStyle.Bottom;
                        }
                        foreach (ClassImport.SubClass subClass in classList.Fighter.MartialArchetypes)
                        {
                            SubClassTab newSubClassTab = new SubClassTab();
                            DataTable featureTable = new DataTable();
                            string subClassDesc = "";
                            foreach (string descLine in subClass.Description)
                                subClassDesc += descLine + "\n";
                            newSubClassTab.label1.Text = subClassDesc;
                            foreach (string header in subClass.FeaturesTable.Headers)
                                featureTable.Columns.Add(header);
                            foreach (ClassImport.FeatureTable.FeatureRow row in subClass.FeaturesTable.Rows)
                            {
                                string featureList = "";
                                if (row.Features.Length > 0)
                                    featureList = row.Features[0];
                                for (int j = 1; j < row.Features.Length; j++)
                                    featureList += ", " + row.Features[j];
                                featureTable.Rows.Add(new object[] { row.Level, featureList });
                            }
                            newSubClassTab.SubClassTable.DataSource = featureTable;
                            foreach (ClassImport.Feature feature in subClass.SubClassFeatures)
                            {
                                FeatureBox newFeature = new FeatureBox();
                                newFeature.label1.Text = feature.Name;
                                string featureDesc = "";
                                foreach (string featureline in feature.Description)
                                    featureDesc += featureline + "\n";
                                newFeature.richTextBox1.Text = featureDesc;
                                newSubClassTab.panel1.Controls.Add(newFeature);
                                newFeature.Dock = DockStyle.Bottom;
                            }
                            TabPage newSubPage = new TabPage();
                            newSubPage.Text = subClass.Name;
                            newSubPage.Controls.Add(newSubClassTab);
                            newSubClassTab.Dock = DockStyle.Fill;
                            newClassPage.SubClassTabs.Controls.Add(newSubPage);
                        }
                        break;
                    case 5:
                        newPage.Text = classList.Monk.Table.Title;
                        DataTable MonkTable = new DataTable();
                        foreach (string header in classList.Monk.Table.Headers)
                            MonkTable.Columns.Add(header);
                        foreach (ClassImport.MonkTable.MonkRow row in classList.Monk.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            MonkTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, row.MartialArts, row.KiPoints, row.UnarmoredMovement, features });
                        }
                        newClassPage.ClassTable.DataSource = MonkTable;
                        foreach (ClassImport.Feature feature in classList.Monk.ClassFeatures)
                        {
                            FeatureBox newFeature = new FeatureBox();
                            newFeature.label1.Text = feature.Name;
                            string featureDesc = "";
                            foreach (string featureline in feature.Description)
                                featureDesc += featureline + "\n";
                            newFeature.richTextBox1.Text = featureDesc;
                            newClassPage.panel1.Controls.Add(newFeature);
                            newFeature.Dock = DockStyle.Bottom;
                        }
                        foreach (ClassImport.SubClass subClass in classList.Monk.MonasticTraditions)
                        {
                            SubClassTab newSubClassTab = new SubClassTab();
                            DataTable featureTable = new DataTable();
                            string subClassDesc = "";
                            foreach (string descLine in subClass.Description)
                                subClassDesc += descLine + "\n";
                            newSubClassTab.label1.Text = subClassDesc;
                            foreach (string header in subClass.FeaturesTable.Headers)
                                featureTable.Columns.Add(header);
                            foreach (ClassImport.FeatureTable.FeatureRow row in subClass.FeaturesTable.Rows)
                            {
                                string featureList = "";
                                if (row.Features.Length > 0)
                                    featureList = row.Features[0];
                                for (int j = 1; j < row.Features.Length; j++)
                                    featureList += ", " + row.Features[j];
                                featureTable.Rows.Add(new object[] { row.Level, featureList });
                            }
                            newSubClassTab.SubClassTable.DataSource = featureTable;
                            foreach (ClassImport.Feature feature in subClass.SubClassFeatures)
                            {
                                FeatureBox newFeature = new FeatureBox();
                                newFeature.label1.Text = feature.Name;
                                string featureDesc = "";
                                foreach (string featureline in feature.Description)
                                    featureDesc += featureline + "\n";
                                newFeature.richTextBox1.Text = featureDesc;
                                newSubClassTab.panel1.Controls.Add(newFeature);
                                newFeature.Dock = DockStyle.Bottom;
                            }
                            TabPage newSubPage = new TabPage();
                            newSubPage.Text = subClass.Name;
                            newSubPage.Controls.Add(newSubClassTab);
                            newSubClassTab.Dock = DockStyle.Fill;
                            newClassPage.SubClassTabs.Controls.Add(newSubPage);
                        }
                        break;
                    case 6:
                        newPage.Text = classList.Paladin.Table.Title;
                        DataTable PaladinTable = new DataTable();
                        foreach (string header in classList.Paladin.Table.Headers)
                            PaladinTable.Columns.Add(header);
                        foreach (ClassImport.PaladinTable.PaladinRow row in classList.Paladin.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            PaladinTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.First, row.Second, row.Third, row.Fourth, row.Fifth });
                        }
                        newClassPage.ClassTable.DataSource = PaladinTable;
                        foreach (ClassImport.Feature feature in classList.Paladin.ClassFeatures)
                        {
                            FeatureBox newFeature = new FeatureBox();
                            newFeature.label1.Text = feature.Name;
                            string featureDesc = "";
                            foreach (string featureline in feature.Description)
                                featureDesc += featureline + "\n";
                            newFeature.richTextBox1.Text = featureDesc;
                            newClassPage.panel1.Controls.Add(newFeature);
                            newFeature.Dock = DockStyle.Bottom;
                        }
                        foreach (ClassImport.SubClass subClass in classList.Paladin.SacredOaths)
                        {
                            SubClassTab newSubClassTab = new SubClassTab();
                            DataTable featureTable = new DataTable();
                            string subClassDesc = "";
                            foreach (string descLine in subClass.Description)
                                subClassDesc += descLine + "\n";
                            newSubClassTab.label1.Text = subClassDesc;
                            foreach (string header in subClass.FeaturesTable.Headers)
                                featureTable.Columns.Add(header);
                            foreach (ClassImport.FeatureTable.FeatureRow row in subClass.FeaturesTable.Rows)
                            {
                                string featureList = "";
                                if (row.Features.Length > 0)
                                    featureList = row.Features[0];
                                for (int j = 1; j < row.Features.Length; j++)
                                    featureList += ", " + row.Features[j];
                                featureTable.Rows.Add(new object[] { row.Level, featureList });
                            }
                            newSubClassTab.SubClassTable.DataSource = featureTable;
                            foreach (ClassImport.Feature feature in subClass.SubClassFeatures)
                            {
                                FeatureBox newFeature = new FeatureBox();
                                newFeature.label1.Text = feature.Name;
                                string featureDesc = "";
                                foreach (string featureline in feature.Description)
                                    featureDesc += featureline + "\n";
                                newFeature.richTextBox1.Text = featureDesc;
                                newSubClassTab.panel1.Controls.Add(newFeature);
                                newFeature.Dock = DockStyle.Bottom;
                            }
                            TabPage newSubPage = new TabPage();
                            newSubPage.Text = subClass.Name;
                            newSubPage.Controls.Add(newSubClassTab);
                            newSubClassTab.Dock = DockStyle.Fill;
                            newClassPage.SubClassTabs.Controls.Add(newSubPage);
                        }
                        break; 
                    case 7:
                        newPage.Text = classList.Ranger.Table.Title;
                        DataTable RangerTable = new DataTable();
                        foreach (string header in classList.Ranger.Table.Headers)
                            RangerTable.Columns.Add(header);
                        foreach (ClassImport.RangerTable.RangerRow row in classList.Ranger.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            RangerTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.SpellsKnown, row.First, row.Second, row.Third, row.Fourth, row.Fifth });
                        }
                        newClassPage.ClassTable.DataSource = RangerTable;
                        foreach (ClassImport.Feature feature in classList.Ranger.ClassFeatures)
                        {
                            FeatureBox newFeature = new FeatureBox();
                            newFeature.label1.Text = feature.Name;
                            string featureDesc = "";
                            foreach (string featureline in feature.Description)
                                featureDesc += featureline + "\n";
                            newFeature.richTextBox1.Text = featureDesc;
                            newClassPage.panel1.Controls.Add(newFeature);
                            newFeature.Dock = DockStyle.Bottom;
                        }
                        foreach (ClassImport.SubClass subClass in classList.Ranger.RangerArchetypes)
                        {
                            SubClassTab newSubClassTab = new SubClassTab();
                            DataTable featureTable = new DataTable();
                            string subClassDesc = "";
                            foreach (string descLine in subClass.Description)
                                subClassDesc += descLine + "\n";
                            newSubClassTab.label1.Text = subClassDesc;
                            foreach (string header in subClass.FeaturesTable.Headers)
                                featureTable.Columns.Add(header);
                            foreach (ClassImport.FeatureTable.FeatureRow row in subClass.FeaturesTable.Rows)
                            {
                                string featureList = "";
                                if (row.Features.Length > 0)
                                    featureList = row.Features[0];
                                for (int j = 1; j < row.Features.Length; j++)
                                    featureList += ", " + row.Features[j];
                                featureTable.Rows.Add(new object[] { row.Level, featureList });
                            }
                            newSubClassTab.SubClassTable.DataSource = featureTable;
                            foreach (ClassImport.Feature feature in subClass.SubClassFeatures)
                            {
                                FeatureBox newFeature = new FeatureBox();
                                newFeature.label1.Text = feature.Name;
                                string featureDesc = "";
                                foreach (string featureline in feature.Description)
                                    featureDesc += featureline + "\n";
                                newFeature.richTextBox1.Text = featureDesc;
                                newSubClassTab.panel1.Controls.Add(newFeature);
                                newFeature.Dock = DockStyle.Bottom;
                            }
                            TabPage newSubPage = new TabPage();
                            newSubPage.Text = subClass.Name;
                            newSubPage.Controls.Add(newSubClassTab);
                            newSubClassTab.Dock = DockStyle.Fill;
                            newClassPage.SubClassTabs.Controls.Add(newSubPage);
                        }
                        break;
                    case 8:
                        newPage.Text = classList.Rogue.Table.Title;
                        DataTable RogueTable = new DataTable();
                        foreach (string header in classList.Rogue.Table.Headers)
                            RogueTable.Columns.Add(header);
                        foreach (ClassImport.RogueTable.RogueRow row in classList.Rogue.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            RogueTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, row.SneakAttack, features });
                        }
                        newClassPage.ClassTable.DataSource = RogueTable;
                        foreach (ClassImport.Feature feature in classList.Rogue.ClassFeatures)
                        {
                            FeatureBox newFeature = new FeatureBox();
                            newFeature.label1.Text = feature.Name;
                            string featureDesc = "";
                            foreach (string featureline in feature.Description)
                                featureDesc += featureline + "\n";
                            newFeature.richTextBox1.Text = featureDesc;
                            newClassPage.panel1.Controls.Add(newFeature);
                            newFeature.Dock = DockStyle.Bottom;
                        }
                        foreach (ClassImport.SubClass subClass in classList.Rogue.RoguishArchetypes)
                        {
                            SubClassTab newSubClassTab = new SubClassTab();
                            DataTable featureTable = new DataTable();
                            string subClassDesc = "";
                            foreach (string descLine in subClass.Description)
                                subClassDesc += descLine + "\n";
                            newSubClassTab.label1.Text = subClassDesc;
                            foreach (string header in subClass.FeaturesTable.Headers)
                                featureTable.Columns.Add(header);
                            foreach (ClassImport.FeatureTable.FeatureRow row in subClass.FeaturesTable.Rows)
                            {
                                string featureList = "";
                                if (row.Features.Length > 0)
                                    featureList = row.Features[0];
                                for (int j = 1; j < row.Features.Length; j++)
                                    featureList += ", " + row.Features[j];
                                featureTable.Rows.Add(new object[] { row.Level, featureList });
                            }
                            newSubClassTab.SubClassTable.DataSource = featureTable;
                            foreach (ClassImport.Feature feature in subClass.SubClassFeatures)
                            {
                                FeatureBox newFeature = new FeatureBox();
                                newFeature.label1.Text = feature.Name;
                                string featureDesc = "";
                                foreach (string featureline in feature.Description)
                                    featureDesc += featureline + "\n";
                                newFeature.richTextBox1.Text = featureDesc;
                                newSubClassTab.panel1.Controls.Add(newFeature);
                                newFeature.Dock = DockStyle.Bottom;
                            }
                            TabPage newSubPage = new TabPage();
                            newSubPage.Text = subClass.Name;
                            newSubPage.Controls.Add(newSubClassTab);
                            newSubClassTab.Dock = DockStyle.Fill;
                            newClassPage.SubClassTabs.Controls.Add(newSubPage);
                        }
                        break;
                    case 9:
                        newPage.Text = classList.Sorcerer.Table.Title;
                        DataTable SorcererTable = new DataTable();
                        foreach (string header in classList.Sorcerer.Table.Headers)
                            SorcererTable.Columns.Add(header);
                        foreach (ClassImport.SorcTable.SorcRow row in classList.Sorcerer.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            SorcererTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, row.SorceryPoints, features, row.CantripsKnown, row.SpellsKnown, row.First, row.Second, row.Third, row.Fourth, row.Fifth, row.Sixth, row.Seventh, row.Eighth, row.Ninth });
                        }
                        newClassPage.ClassTable.DataSource = SorcererTable;
                        foreach (ClassImport.Feature feature in classList.Sorcerer.ClassFeatures)
                        {
                            FeatureBox newFeature = new FeatureBox();
                            newFeature.label1.Text = feature.Name;
                            string featureDesc = "";
                            foreach (string featureline in feature.Description)
                                featureDesc += featureline + "\n";
                            newFeature.richTextBox1.Text = featureDesc;
                            newClassPage.panel1.Controls.Add(newFeature);
                            newFeature.Dock = DockStyle.Bottom;
                        }
                        foreach (ClassImport.SubClass subClass in classList.Sorcerer.SorcerousOrigins)
                        {
                            SubClassTab newSubClassTab = new SubClassTab();
                            DataTable featureTable = new DataTable();
                            string subClassDesc = "";
                            foreach (string descLine in subClass.Description)
                                subClassDesc += descLine + "\n";
                            newSubClassTab.label1.Text = subClassDesc;
                            foreach (string header in subClass.FeaturesTable.Headers)
                                featureTable.Columns.Add(header);
                            foreach (ClassImport.FeatureTable.FeatureRow row in subClass.FeaturesTable.Rows)
                            {
                                string featureList = "";
                                if (row.Features.Length > 0)
                                    featureList = row.Features[0];
                                for (int j = 1; j < row.Features.Length; j++)
                                    featureList += ", " + row.Features[j];
                                featureTable.Rows.Add(new object[] { row.Level, featureList });
                            }
                            newSubClassTab.SubClassTable.DataSource = featureTable;
                            foreach (ClassImport.Feature feature in subClass.SubClassFeatures)
                            {
                                FeatureBox newFeature = new FeatureBox();
                                newFeature.label1.Text = feature.Name;
                                string featureDesc = "";
                                foreach (string featureline in feature.Description)
                                    featureDesc += featureline + "\n";
                                newFeature.richTextBox1.Text = featureDesc;
                                newSubClassTab.panel1.Controls.Add(newFeature);
                                newFeature.Dock = DockStyle.Bottom;
                            }
                            TabPage newSubPage = new TabPage();
                            newSubPage.Text = subClass.Name;
                            newSubPage.Controls.Add(newSubClassTab);
                            newSubClassTab.Dock = DockStyle.Fill;
                            newClassPage.SubClassTabs.Controls.Add(newSubPage);
                        }
                        break;
                    case 10:
                        newPage.Text = classList.Warlock.Table.Title;
                        DataTable WarlockTable = new DataTable();
                        foreach (string header in classList.Warlock.Table.Headers)
                            WarlockTable.Columns.Add(header);
                        foreach (ClassImport.WarlockTable.WarlockRow row in classList.Warlock.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            WarlockTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.CantripsKnown, row.SpellsKnown, row.SpellSlots, row.SlotLevel, row.InvocationsKnown });
                        }
                        newClassPage.ClassTable.DataSource = WarlockTable;
                        foreach (ClassImport.Feature feature in classList.Warlock.ClassFeatures)
                        {
                            FeatureBox newFeature = new FeatureBox();
                            newFeature.label1.Text = feature.Name;
                            string featureDesc = "";
                            foreach (string featureline in feature.Description)
                                featureDesc += featureline + "\n";
                            newFeature.richTextBox1.Text = featureDesc;
                            newClassPage.panel1.Controls.Add(newFeature);
                            newFeature.Dock = DockStyle.Bottom;
                        }
                        foreach (ClassImport.SubClass subClass in classList.Warlock.OtherworldlyPatrons)
                        {
                            SubClassTab newSubClassTab = new SubClassTab();
                            DataTable featureTable = new DataTable();
                            string subClassDesc = "";
                            foreach (string descLine in subClass.Description)
                                subClassDesc += descLine + "\n";
                            newSubClassTab.label1.Text = subClassDesc;
                            foreach (string header in subClass.FeaturesTable.Headers)
                                featureTable.Columns.Add(header);
                            foreach (ClassImport.FeatureTable.FeatureRow row in subClass.FeaturesTable.Rows)
                            {
                                string featureList = "";
                                if (row.Features.Length > 0)
                                    featureList = row.Features[0];
                                for (int j = 1; j < row.Features.Length; j++)
                                    featureList += ", " + row.Features[j];
                                featureTable.Rows.Add(new object[] { row.Level, featureList });
                            }
                            newSubClassTab.SubClassTable.DataSource = featureTable;
                            foreach (ClassImport.Feature feature in subClass.SubClassFeatures)
                            {
                                FeatureBox newFeature = new FeatureBox();
                                newFeature.label1.Text = feature.Name;
                                string featureDesc = "";
                                foreach (string featureline in feature.Description)
                                    featureDesc += featureline + "\n";
                                newFeature.richTextBox1.Text = featureDesc;
                                newSubClassTab.panel1.Controls.Add(newFeature);
                                newFeature.Dock = DockStyle.Bottom;
                            }
                            TabPage newSubPage = new TabPage();
                            newSubPage.Text = subClass.Name;
                            newSubPage.Controls.Add(newSubClassTab);
                            newSubClassTab.Dock = DockStyle.Fill;
                            newClassPage.SubClassTabs.Controls.Add(newSubPage);
                        }
                        break;
                    case 11:
                        newPage.Text = classList.Wizard.Table.Title;
                        DataTable WizardTable = new DataTable();
                        foreach (string header in classList.Wizard.Table.Headers)
                            WizardTable.Columns.Add(header);
                        foreach (ClassImport.WizardTable.WizardRow row in classList.Wizard.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            WizardTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.CantripsKnown, row.First, row.Second, row.Third, row.Fourth, row.Fifth, row.Sixth, row.Seventh, row.Eighth, row.Ninth });
                        }
                        newClassPage.ClassTable.DataSource = WizardTable;
                        foreach (ClassImport.Feature feature in classList.Wizard.ClassFeatures)
                        {
                            FeatureBox newFeature = new FeatureBox();
                            newFeature.label1.Text = feature.Name;
                            string featureDesc = "";
                            foreach (string featureline in feature.Description)
                                featureDesc += featureline + "\n";
                            newFeature.richTextBox1.Text = featureDesc;
                            newClassPage.panel1.Controls.Add(newFeature);
                            newFeature.Dock = DockStyle.Bottom;
                        }
                        foreach (ClassImport.SubClass subClass in classList.Wizard.ArcaneTraditions)
                        {
                            SubClassTab newSubClassTab = new SubClassTab();
                            DataTable featureTable = new DataTable();
                            string subClassDesc = "";
                            foreach (string descLine in subClass.Description)
                                subClassDesc += descLine + "\n";
                            newSubClassTab.label1.Text = subClassDesc;
                            foreach (string header in subClass.FeaturesTable.Headers)
                                featureTable.Columns.Add(header);
                            foreach (ClassImport.FeatureTable.FeatureRow row in subClass.FeaturesTable.Rows)
                            {
                                string featureList = "";
                                if (row.Features.Length > 0)
                                    featureList = row.Features[0];
                                for (int j = 1; j < row.Features.Length; j++)
                                    featureList += ", " + row.Features[j];
                                featureTable.Rows.Add(new object[] { row.Level, featureList });
                            }
                            newSubClassTab.SubClassTable.DataSource = featureTable;
                            foreach (ClassImport.Feature feature in subClass.SubClassFeatures)
                            {
                                FeatureBox newFeature = new FeatureBox();
                                newFeature.label1.Text = feature.Name;
                                string featureDesc = "";
                                foreach (string featureline in feature.Description)
                                    featureDesc += featureline + "\n";
                                newFeature.richTextBox1.Text = featureDesc;
                                newSubClassTab.panel1.Controls.Add(newFeature);
                                newFeature.Dock = DockStyle.Bottom;
                            }
                            TabPage newSubPage = new TabPage();
                            newSubPage.Text = subClass.Name;
                            newSubPage.Controls.Add(newSubClassTab);
                            newSubClassTab.Dock = DockStyle.Fill;
                            newClassPage.SubClassTabs.Controls.Add(newSubPage);
                        }
                        break;
                    default:
                        classname = "Error Test";
                        break;
                }
            }

        }

        private void SetLevelButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Set Level of " + ClassTabs.SelectedTab.Text.TrimStart(new char[] { 'T', 'h', 'e', ' ' })
                + " - " + ((ClassPage)ClassTabs.SelectedTab.Controls[0]).SubClassTabs.SelectedTab.Text + 
                " to " + LevelSetter.Value.ToString() + "?",
                "Level Up", MessageBoxButtons.YesNoCancel);
            if(result == DialogResult.Yes)
            {
                PlayerClass newClass = new PlayerClass();
                newClass.Name = ClassTabs.SelectedTab.Text.TrimStart(new char[] { 'T', 'h', 'e', ' ' });
                newClass.SubClass = ((ClassPage)ClassTabs.SelectedTab.Controls[0]).SubClassTabs.SelectedTab.Text;
                newClass.Level = (int) LevelSetter.Value;

                bool exists = false;
                foreach (PlayerClass pClass in player.PlayerClassList)
                {
                    if(pClass.Name.Equals(newClass.Name))
                    {
                        exists = true;
                        if (!pClass.SubClass.Equals(newClass.SubClass))
                        {
                            MessageBox.Show("You already have levels in " + pClass.Name
                                + " - " + pClass.SubClass + ".\n" + "You must first remove your" +
                                " levels in " + pClass.Name + " to change your subclass to " +
                                newClass.SubClass + ".");
                            return;
                        }
                        else
                        {
                            if (pClass.Level > newClass.Level)
                            {
                                MessageBox.Show("Unable to lower level." +
                                    "\nYou must first remove your levels in " + pClass.Name +
                                    " to set that class to a lower level");
                                return;
                            }
                            else
                            {
                                pClass.Level = newClass.Level;
                                break;
                            }
                        }
                    }
                }

                List<Feature> newFeatures = new List<Feature>();
                List<string> newClassFeatNames = new List<string>();
                List<string> newSubClassFeatNames = new List<string>();

                foreach (DataGridViewRow row in ((ClassPage)ClassTabs.SelectedTab.Controls[0]).ClassTable.Rows)
                    if (row.Cells["Level"].Value != null && int.Parse(row.Cells["Level"].Value.ToString()) <= newClass.Level)
                        newClassFeatNames.AddRange(row.Cells["Features"].Value.ToString().Split(','));
                foreach (DataGridViewRow row in ((SubClassTab)((ClassPage)ClassTabs.SelectedTab.Controls[0]).SubClassTabs.SelectedTab.Controls[0]).SubClassTable.Rows)
                    if (row.Cells["Level"].Value != null && int.Parse(row.Cells["Level"].Value.ToString()) <= newClass.Level)
                        newSubClassFeatNames.AddRange(row.Cells["Features"].Value.ToString().Split(','));
                
                switch(newClass.Name)
                {
                    case "Barbarian":
                        foreach(string untrimmedFeatName in newClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach(ClassImport.Feature feat in classList.Barbarian.ClassFeatures)
                                if(feat.Name.Equals(featName))
                                {
                                    Feature newFeat = new Feature();
                                    newFeat.Name = feat.Name;
                                    newFeat.Description = feat.Description;
                                    newFeatures.Add(newFeat);
                                    break;
                                }
                        }
                        foreach (string untrimmedFeatName in newSubClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach(ClassImport.SubClass cSubClass in classList.Barbarian.PrimalPaths)
                                if(cSubClass.Name.Equals(newClass.SubClass))
                                {
                                    foreach (ClassImport.Feature feat in cSubClass.SubClassFeatures)
                                        if (feat.Name.Equals(featName))
                                        {
                                            Feature newFeat = new Feature();
                                            newFeat.Name = feat.Name;
                                            newFeat.Description = feat.Description;
                                            newFeatures.Add(newFeat);
                                            break;
                                        }
                                    break;
                                }

                        }
                        break;
                    case "Bard":
                        foreach (string untrimmedFeatName in newClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.Feature feat in classList.Bard.ClassFeatures)
                                if (feat.Name.Equals(featName))
                                {
                                    Feature newFeat = new Feature();
                                    newFeat.Name = feat.Name;
                                    newFeat.Description = feat.Description;
                                    newFeatures.Add(newFeat);
                                    break;
                                }
                        }
                        foreach (string untrimmedFeatName in newSubClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.SubClass cSubClass in classList.Bard.BardColleges)
                                if (cSubClass.Name.Equals(newClass.SubClass))
                                {
                                    foreach (ClassImport.Feature feat in cSubClass.SubClassFeatures)
                                        if (feat.Name.Equals(featName))
                                        {
                                            Feature newFeat = new Feature();
                                            newFeat.Name = feat.Name;
                                            newFeat.Description = feat.Description;
                                            newFeatures.Add(newFeat);
                                            break;
                                        }
                                    break;
                                }

                        }
                        break;
                    case "Cleric":
                        foreach (string untrimmedFeatName in newClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.Feature feat in classList.Cleric.ClassFeatures)
                                if (feat.Name.Equals(featName))
                                {
                                    Feature newFeat = new Feature();
                                    newFeat.Name = feat.Name;
                                    newFeat.Description = feat.Description;
                                    newFeatures.Add(newFeat);
                                    break;
                                }
                        }
                        foreach (string untrimmedFeatName in newSubClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.SubClass cSubClass in classList.Cleric.DivineDomains)
                                if (cSubClass.Name.Equals(newClass.SubClass))
                                {
                                    foreach (ClassImport.Feature feat in cSubClass.SubClassFeatures)
                                        if (feat.Name.Equals(featName))
                                        {
                                            Feature newFeat = new Feature();
                                            newFeat.Name = feat.Name;
                                            newFeat.Description = feat.Description;
                                            newFeatures.Add(newFeat);
                                            break;
                                        }
                                    break;
                                }

                        }
                        break;
                    case "Druid":
                        foreach (string untrimmedFeatName in newClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.Feature feat in classList.Druid.ClassFeatures)
                                if (feat.Name.Equals(featName))
                                {
                                    Feature newFeat = new Feature();
                                    newFeat.Name = feat.Name;
                                    newFeat.Description = feat.Description;
                                    newFeatures.Add(newFeat);
                                    break;
                                }
                        }
                        foreach (string untrimmedFeatName in newSubClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.SubClass cSubClass in classList.Druid.DruidCircles)
                                if (cSubClass.Name.Equals(newClass.SubClass))
                                {
                                    foreach (ClassImport.Feature feat in cSubClass.SubClassFeatures)
                                        if (feat.Name.Equals(featName))
                                        {
                                            Feature newFeat = new Feature();
                                            newFeat.Name = feat.Name;
                                            newFeat.Description = feat.Description;
                                            newFeatures.Add(newFeat);
                                            break;
                                        }
                                    break;
                                }

                        }
                        break;
                    case "Fighter":
                        foreach (string untrimmedFeatName in newClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.Feature feat in classList.Fighter.ClassFeatures)
                                if (feat.Name.Equals(featName))
                                {
                                    Feature newFeat = new Feature();
                                    newFeat.Name = feat.Name;
                                    newFeat.Description = feat.Description;
                                    newFeatures.Add(newFeat);
                                    break;
                                }
                        }
                        foreach (string untrimmedFeatName in newSubClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.SubClass cSubClass in classList.Fighter.MartialArchetypes)
                                if (cSubClass.Name.Equals(newClass.SubClass))
                                {
                                    foreach (ClassImport.Feature feat in cSubClass.SubClassFeatures)
                                        if (feat.Name.Equals(featName))
                                        {
                                            Feature newFeat = new Feature();
                                            newFeat.Name = feat.Name;
                                            newFeat.Description = feat.Description;
                                            newFeatures.Add(newFeat);
                                            break;
                                        }
                                    break;
                                }

                        }
                        break;
                    case "Monk":
                        foreach (string untrimmedFeatName in newClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.Feature feat in classList.Monk.ClassFeatures)
                                if (feat.Name.Equals(featName))
                                {
                                    Feature newFeat = new Feature();
                                    newFeat.Name = feat.Name;
                                    newFeat.Description = feat.Description;
                                    newFeatures.Add(newFeat);
                                    break;
                                }
                        }
                        foreach (string untrimmedFeatName in newSubClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.SubClass cSubClass in classList.Monk.MonasticTraditions)
                                if (cSubClass.Name.Equals(newClass.SubClass))
                                {
                                    foreach (ClassImport.Feature feat in cSubClass.SubClassFeatures)
                                        if (feat.Name.Equals(featName))
                                        {
                                            Feature newFeat = new Feature();
                                            newFeat.Name = feat.Name;
                                            newFeat.Description = feat.Description;
                                            newFeatures.Add(newFeat);
                                            break;
                                        }
                                    break;
                                }

                        }
                        break;
                    case "Paladin":
                        foreach (string untrimmedFeatName in newClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.Feature feat in classList.Paladin.ClassFeatures)
                                if (feat.Name.Equals(featName))
                                {
                                    Feature newFeat = new Feature();
                                    newFeat.Name = feat.Name;
                                    newFeat.Description = feat.Description;
                                    newFeatures.Add(newFeat);
                                    break;
                                }
                        }
                        foreach (string untrimmedFeatName in newSubClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.SubClass cSubClass in classList.Paladin.SacredOaths)
                                if (cSubClass.Name.Equals(newClass.SubClass))
                                {
                                    foreach (ClassImport.Feature feat in cSubClass.SubClassFeatures)
                                        if (feat.Name.Equals(featName))
                                        {
                                            Feature newFeat = new Feature();
                                            newFeat.Name = feat.Name;
                                            newFeat.Description = feat.Description;
                                            newFeatures.Add(newFeat);
                                            break;
                                        }
                                    break;
                                }

                        }
                        break;
                    case "Ranger":
                        foreach (string untrimmedFeatName in newClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.Feature feat in classList.Ranger.ClassFeatures)
                                if (feat.Name.Equals(featName))
                                {
                                    Feature newFeat = new Feature();
                                    newFeat.Name = feat.Name;
                                    newFeat.Description = feat.Description;
                                    newFeatures.Add(newFeat);
                                    break;
                                }
                        }
                        foreach (string untrimmedFeatName in newSubClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.SubClass cSubClass in classList.Ranger.RangerArchetypes)
                                if (cSubClass.Name.Equals(newClass.SubClass))
                                {
                                    foreach (ClassImport.Feature feat in cSubClass.SubClassFeatures)
                                        if (feat.Name.Equals(featName))
                                        {
                                            Feature newFeat = new Feature();
                                            newFeat.Name = feat.Name;
                                            newFeat.Description = feat.Description;
                                            newFeatures.Add(newFeat);
                                            break;
                                        }
                                    break;
                                }

                        }
                        break;
                    case "Rogue":
                        foreach (string untrimmedFeatName in newClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.Feature feat in classList.Rogue.ClassFeatures)
                                if (feat.Name.Equals(featName))
                                {
                                    Feature newFeat = new Feature();
                                    newFeat.Name = feat.Name;
                                    newFeat.Description = feat.Description;
                                    newFeatures.Add(newFeat);
                                    break;
                                }
                        }
                        foreach (string untrimmedFeatName in newSubClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.SubClass cSubClass in classList.Rogue.RoguishArchetypes)
                                if (cSubClass.Name.Equals(newClass.SubClass))
                                {
                                    foreach (ClassImport.Feature feat in cSubClass.SubClassFeatures)
                                        if (feat.Name.Equals(featName))
                                        {
                                            Feature newFeat = new Feature();
                                            newFeat.Name = feat.Name;
                                            newFeat.Description = feat.Description;
                                            newFeatures.Add(newFeat);
                                            break;
                                        }
                                    break;
                                }

                        }
                        break;
                    case "Sorcerer":
                        foreach (string untrimmedFeatName in newClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.Feature feat in classList.Sorcerer.ClassFeatures)
                                if (feat.Name.Equals(featName))
                                {
                                    Feature newFeat = new Feature();
                                    newFeat.Name = feat.Name;
                                    newFeat.Description = feat.Description;
                                    newFeatures.Add(newFeat);
                                    break;
                                }
                        }
                        foreach (string untrimmedFeatName in newSubClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.SubClass cSubClass in classList.Sorcerer.SorcerousOrigins)
                                if (cSubClass.Name.Equals(newClass.SubClass))
                                {
                                    foreach (ClassImport.Feature feat in cSubClass.SubClassFeatures)
                                        if (feat.Name.Equals(featName))
                                        {
                                            Feature newFeat = new Feature();
                                            newFeat.Name = feat.Name;
                                            newFeat.Description = feat.Description;
                                            newFeatures.Add(newFeat);
                                            break;
                                        }
                                    break;
                                }

                        }
                        break;
                    case "Warlock":
                        foreach (string untrimmedFeatName in newClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.Feature feat in classList.Warlock.ClassFeatures)
                                if (feat.Name.Equals(featName))
                                {
                                    Feature newFeat = new Feature();
                                    newFeat.Name = feat.Name;
                                    newFeat.Description = feat.Description;
                                    newFeatures.Add(newFeat);
                                    break;
                                }
                        }
                        foreach (string untrimmedFeatName in newSubClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.SubClass cSubClass in classList.Warlock.OtherworldlyPatrons)
                                if (cSubClass.Name.Equals(newClass.SubClass))
                                {
                                    foreach (ClassImport.Feature feat in cSubClass.SubClassFeatures)
                                        if (feat.Name.Equals(featName))
                                        {
                                            Feature newFeat = new Feature();
                                            newFeat.Name = feat.Name;
                                            newFeat.Description = feat.Description;
                                            newFeatures.Add(newFeat);
                                            break;
                                        }
                                    break;
                                }

                        }
                        break;
                    case "Wizard":
                        foreach (string untrimmedFeatName in newClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.Feature feat in classList.Wizard.ClassFeatures)
                                if (feat.Name.Equals(featName))
                                {
                                    Feature newFeat = new Feature();
                                    newFeat.Name = feat.Name;
                                    newFeat.Description = feat.Description;
                                    newFeatures.Add(newFeat);
                                    break;
                                }
                        }
                        foreach (string untrimmedFeatName in newSubClassFeatNames)
                        {
                            string featName = untrimmedFeatName.Trim(' ');
                            foreach (ClassImport.SubClass cSubClass in classList.Wizard.ArcaneTraditions)
                                if (cSubClass.Name.Equals(newClass.SubClass))
                                {
                                    foreach (ClassImport.Feature feat in cSubClass.SubClassFeatures)
                                        if (feat.Name.Equals(featName))
                                        {
                                            Feature newFeat = new Feature();
                                            newFeat.Name = feat.Name;
                                            newFeat.Description = feat.Description;
                                            newFeatures.Add(newFeat);
                                            break;
                                        }
                                    break;
                                }

                        }
                        break;
                    default:
                        MessageBox.Show("Invalid Class Name Found.");
                        return;
                }

                if(exists)
                {
                    bool duplicate = false;
                    foreach (Feature newFeat in newFeatures)
                    {
                        foreach(Feature existFeat in player.FeatsNtraits)
                            if(existFeat.Name.Equals(newFeat.Name))
                            {
                                duplicate = true;
                                break;
                            }
                        if (!duplicate)
                            player.FeatsNtraits.Add(newFeat);
                    }
                }
                else
                {
                    foreach (Feature newFeat in newFeatures)
                        player.FeatsNtraits.Add(newFeat);
                    player.PlayerClassList.Add(newClass);
                }
            }
            string classLabelText = "";
            foreach (PlayerClass cClass in player.PlayerClassList)
            {
                if (!string.IsNullOrEmpty(classLabelText))
                    classLabelText += "\n";
                classLabelText += "Lvl " + cClass.Level.ToString() + " " + cClass.Name +
                    " - " + cClass.SubClass;
            }
            ClassLabel.Text = classLabelText;
        }

        private void ResetFeaturesButton_Click(object sender, EventArgs e)
        {
            foreach(PlayerClass pClass in player.PlayerClassList)
            {
                foreach(TabPage cPage in ClassTabs.TabPages)
                    if(cPage.Text.TrimStart(new char[] { 'T', 'h', 'e', ' ' }).Equals(pClass.Name))
                    {
                        ClassTabs.SelectedTab = cPage;
                        foreach(TabPage scPage in ((ClassPage)cPage.Controls[0]).SubClassTabs.TabPages)
                            if(scPage.Text.Equals(pClass.SubClass))
                            {
                                ((ClassPage)cPage.Controls[0]).SubClassTabs.SelectedTab = scPage;
                                break;
                            }
                        break;
                    }
                LevelSetter.Value = pClass.Level;
                SetLevelButton_Click(null, null);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RemoveClassButton_Click(object sender, EventArgs e)
        {
            ClassSelector removeSelect = new ClassSelector(player);
            DialogResult result = removeSelect.ShowDialog();
            if(result == DialogResult.OK)
            {
                PlayerClass chosenClass = removeSelect.chosenClass;
                foreach (TabPage cPage in ClassTabs.TabPages)
                    if (cPage.Text.TrimStart(new char[] { 'T', 'h', 'e', ' ' }).Equals(chosenClass.Name))
                    {
                        ClassTabs.SelectedTab = cPage;
                        foreach (TabPage scPage in ((ClassPage)cPage.Controls[0]).SubClassTabs.TabPages)
                            if (scPage.Text.Equals(chosenClass.SubClass))
                            {
                                ((ClassPage)cPage.Controls[0]).SubClassTabs.SelectedTab = scPage;
                                break;
                            }
                        break;
                    }
                List<Feature> removelist = new List<Feature>();
                switch (chosenClass.Name)
                {
                    case "Barbarian":                       
                        foreach(ClassImport.Feature importFeat in classList.Barbarian.ClassFeatures)
                        {
                            Feature feat = new Feature();
                            feat.Name = importFeat.Name;
                            feat.Description = importFeat.Description;
                            foreach(Feature pFeat in player.FeatsNtraits)
                            {
                                if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                    removelist.Add(pFeat);
                            }
                        }
                        foreach(ClassImport.SubClass sClass in classList.Barbarian.PrimalPaths)
                            if(sClass.Name.Equals(chosenClass.SubClass))
                            {
                                foreach(ClassImport.Feature importFeat in sClass.SubClassFeatures)
                                {
                                    Feature feat = new Feature();
                                    feat.Name = importFeat.Name;
                                    feat.Description = importFeat.Description;
                                    foreach (Feature pFeat in player.FeatsNtraits)
                                    {
                                        if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                            removelist.Add(pFeat);
                                    }
                                }
                                break;
                            }
                        break;
                    case "Bard":
                        foreach (ClassImport.Feature importFeat in classList.Bard.ClassFeatures)
                        {
                            Feature feat = new Feature();
                            feat.Name = importFeat.Name;
                            feat.Description = importFeat.Description;
                            foreach (Feature pFeat in player.FeatsNtraits)
                            {
                                if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                    removelist.Add(pFeat);
                            }
                        }
                        foreach (ClassImport.SubClass sClass in classList.Bard.BardColleges)
                            if (sClass.Name.Equals(chosenClass.SubClass))
                            {
                                foreach (ClassImport.Feature importFeat in sClass.SubClassFeatures)
                                {
                                    Feature feat = new Feature();
                                    feat.Name = importFeat.Name;
                                    feat.Description = importFeat.Description;
                                    foreach (Feature pFeat in player.FeatsNtraits)
                                    {
                                        if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                            removelist.Add(pFeat);
                                    }
                                }
                                break;
                            }
                        break;
                    case "Cleric":
                        foreach (ClassImport.Feature importFeat in classList.Cleric.ClassFeatures)
                        {
                            Feature feat = new Feature();
                            feat.Name = importFeat.Name;
                            feat.Description = importFeat.Description;
                            foreach (Feature pFeat in player.FeatsNtraits)
                            {
                                if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                    removelist.Add(pFeat);
                            }
                        }
                        foreach (ClassImport.SubClass sClass in classList.Cleric.DivineDomains)
                            if (sClass.Name.Equals(chosenClass.SubClass))
                            {
                                foreach (ClassImport.Feature importFeat in sClass.SubClassFeatures)
                                {
                                    Feature feat = new Feature();
                                    feat.Name = importFeat.Name;
                                    feat.Description = importFeat.Description;
                                    foreach (Feature pFeat in player.FeatsNtraits)
                                    {
                                        if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                            removelist.Add(pFeat);
                                    }
                                }
                                break;
                            }
                        break;
                    case "Druid":
                        foreach (ClassImport.Feature importFeat in classList.Druid.ClassFeatures)
                        {
                            Feature feat = new Feature();
                            feat.Name = importFeat.Name;
                            feat.Description = importFeat.Description;
                            foreach (Feature pFeat in player.FeatsNtraits)
                            {
                                if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                    removelist.Add(pFeat);
                            }
                        }
                        foreach (ClassImport.SubClass sClass in classList.Druid.DruidCircles)
                            if (sClass.Name.Equals(chosenClass.SubClass))
                            {
                                foreach (ClassImport.Feature importFeat in sClass.SubClassFeatures)
                                {
                                    Feature feat = new Feature();
                                    feat.Name = importFeat.Name;
                                    feat.Description = importFeat.Description;
                                    foreach (Feature pFeat in player.FeatsNtraits)
                                    {
                                        if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                            removelist.Add(pFeat);
                                    }
                                }
                                break;
                            }
                        break;
                    case "Fighter":
                        foreach (ClassImport.Feature importFeat in classList.Fighter.ClassFeatures)
                        {
                            Feature feat = new Feature();
                            feat.Name = importFeat.Name;
                            feat.Description = importFeat.Description;
                            foreach (Feature pFeat in player.FeatsNtraits)
                            {
                                if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                    removelist.Add(pFeat);
                            }
                        }
                        foreach (ClassImport.SubClass sClass in classList.Fighter.MartialArchetypes)
                            if (sClass.Name.Equals(chosenClass.SubClass))
                            {
                                foreach (ClassImport.Feature importFeat in sClass.SubClassFeatures)
                                {
                                    Feature feat = new Feature();
                                    feat.Name = importFeat.Name;
                                    feat.Description = importFeat.Description;
                                    foreach (Feature pFeat in player.FeatsNtraits)
                                    {
                                        if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                            removelist.Add(pFeat);
                                    }
                                }
                                break;
                            }
                        break;
                    case "Monk":
                        foreach (ClassImport.Feature importFeat in classList.Monk.ClassFeatures)
                        {
                            Feature feat = new Feature();
                            feat.Name = importFeat.Name;
                            feat.Description = importFeat.Description;
                            foreach (Feature pFeat in player.FeatsNtraits)
                            {
                                if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                    removelist.Add(pFeat);
                            }
                        }
                        foreach (ClassImport.SubClass sClass in classList.Monk.MonasticTraditions)
                            if (sClass.Name.Equals(chosenClass.SubClass))
                            {
                                foreach (ClassImport.Feature importFeat in sClass.SubClassFeatures)
                                {
                                    Feature feat = new Feature();
                                    feat.Name = importFeat.Name;
                                    feat.Description = importFeat.Description;
                                    foreach (Feature pFeat in player.FeatsNtraits)
                                    {
                                        if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                            removelist.Add(pFeat);
                                    }
                                }
                                break;
                            }
                        break;
                    case "Paladin":
                        foreach (ClassImport.Feature importFeat in classList.Paladin.ClassFeatures)
                        {
                            Feature feat = new Feature();
                            feat.Name = importFeat.Name;
                            feat.Description = importFeat.Description;
                            foreach (Feature pFeat in player.FeatsNtraits)
                            {
                                if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                    removelist.Add(pFeat);
                            }
                        }
                        foreach (ClassImport.SubClass sClass in classList.Paladin.SacredOaths)
                            if (sClass.Name.Equals(chosenClass.SubClass))
                            {
                                foreach (ClassImport.Feature importFeat in sClass.SubClassFeatures)
                                {
                                    Feature feat = new Feature();
                                    feat.Name = importFeat.Name;
                                    feat.Description = importFeat.Description;
                                    foreach (Feature pFeat in player.FeatsNtraits)
                                    {
                                        if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                            removelist.Add(pFeat);
                                    }
                                }
                                break;
                            }
                        break;
                    case "Ranger":
                        foreach (ClassImport.Feature importFeat in classList.Ranger.ClassFeatures)
                        {
                            Feature feat = new Feature();
                            feat.Name = importFeat.Name;
                            feat.Description = importFeat.Description;
                            foreach (Feature pFeat in player.FeatsNtraits)
                            {
                                if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                    removelist.Add(pFeat);
                            }
                        }
                        foreach (ClassImport.SubClass sClass in classList.Ranger.RangerArchetypes)
                            if (sClass.Name.Equals(chosenClass.SubClass))
                            {
                                foreach (ClassImport.Feature importFeat in sClass.SubClassFeatures)
                                {
                                    Feature feat = new Feature();
                                    feat.Name = importFeat.Name;
                                    feat.Description = importFeat.Description;
                                    foreach (Feature pFeat in player.FeatsNtraits)
                                    {
                                        if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                            removelist.Add(pFeat);
                                    }
                                }
                                break;
                            }
                        break;
                    case "Rogue":
                        foreach (ClassImport.Feature importFeat in classList.Rogue.ClassFeatures)
                        {
                            Feature feat = new Feature();
                            feat.Name = importFeat.Name;
                            feat.Description = importFeat.Description;
                            foreach (Feature pFeat in player.FeatsNtraits)
                            {
                                if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                    removelist.Add(pFeat);
                            }
                        }
                        foreach (ClassImport.SubClass sClass in classList.Rogue.RoguishArchetypes)
                            if (sClass.Name.Equals(chosenClass.SubClass))
                            {
                                foreach (ClassImport.Feature importFeat in sClass.SubClassFeatures)
                                {
                                    Feature feat = new Feature();
                                    feat.Name = importFeat.Name;
                                    feat.Description = importFeat.Description;
                                    foreach (Feature pFeat in player.FeatsNtraits)
                                    {
                                        if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                            removelist.Add(pFeat);
                                    }
                                }
                                break;
                            }
                        break;
                    case "Sorcerer":
                        foreach (ClassImport.Feature importFeat in classList.Sorcerer.ClassFeatures)
                        {
                            Feature feat = new Feature();
                            feat.Name = importFeat.Name;
                            feat.Description = importFeat.Description;
                            foreach (Feature pFeat in player.FeatsNtraits)
                            {
                                if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                    removelist.Add(pFeat);
                            }
                        }
                        foreach (ClassImport.SubClass sClass in classList.Sorcerer.SorcerousOrigins)
                            if (sClass.Name.Equals(chosenClass.SubClass))
                            {
                                foreach (ClassImport.Feature importFeat in sClass.SubClassFeatures)
                                {
                                    Feature feat = new Feature();
                                    feat.Name = importFeat.Name;
                                    feat.Description = importFeat.Description;
                                    foreach (Feature pFeat in player.FeatsNtraits)
                                    {
                                        if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                            removelist.Add(pFeat);
                                    }
                                }
                                break;
                            }
                        break;
                    case "Warlock":
                        foreach (ClassImport.Feature importFeat in classList.Warlock.ClassFeatures)
                        {
                            Feature feat = new Feature();
                            feat.Name = importFeat.Name;
                            feat.Description = importFeat.Description;
                            foreach (Feature pFeat in player.FeatsNtraits)
                            {
                                if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                    removelist.Add(pFeat);
                            }
                        }
                        foreach (ClassImport.SubClass sClass in classList.Warlock.OtherworldlyPatrons)
                            if (sClass.Name.Equals(chosenClass.SubClass))
                            {
                                foreach (ClassImport.Feature importFeat in sClass.SubClassFeatures)
                                {
                                    Feature feat = new Feature();
                                    feat.Name = importFeat.Name;
                                    feat.Description = importFeat.Description;
                                    foreach (Feature pFeat in player.FeatsNtraits)
                                    {
                                        if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                            removelist.Add(pFeat);
                                    }
                                }
                                break;
                            }
                        break;
                    case "Wizard":
                        foreach (ClassImport.Feature importFeat in classList.Wizard.ClassFeatures)
                        {
                            Feature feat = new Feature();
                            feat.Name = importFeat.Name;
                            feat.Description = importFeat.Description;
                            foreach (Feature pFeat in player.FeatsNtraits)
                            {
                                if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                    removelist.Add(pFeat);
                            }
                        }
                        foreach (ClassImport.SubClass sClass in classList.Wizard.ArcaneTraditions)
                            if (sClass.Name.Equals(chosenClass.SubClass))
                            {
                                foreach (ClassImport.Feature importFeat in sClass.SubClassFeatures)
                                {
                                    Feature feat = new Feature();
                                    feat.Name = importFeat.Name;
                                    feat.Description = importFeat.Description;
                                    foreach (Feature pFeat in player.FeatsNtraits)
                                    {
                                        if (pFeat.Name.Equals(feat.Name) && !removelist.Contains(pFeat))
                                            removelist.Add(pFeat);
                                    }
                                }
                                break;
                            }
                        break;
                    default:
                        MessageBox.Show("Invalid Class Name!");
                        return;
                }
                foreach(Feature feat in removelist)
                {
                    if (player.FeatsNtraits.Contains(feat))
                        player.FeatsNtraits.Remove(feat);
                }
                player.PlayerClassList.Remove(chosenClass);
                string classLabelText = "";
                foreach (PlayerClass cClass in player.PlayerClassList)
                {
                    if (!string.IsNullOrEmpty(classLabelText))
                        classLabelText += "\n";
                    classLabelText += "Lvl " + cClass.Level.ToString() + " " + cClass.Name +
                        " - " + cClass.SubClass;
                }
                ClassLabel.Text = classLabelText;
            }
        }

        private void LevelUpButton_Click(object sender, EventArgs e)
        {
            ClassSelector LevelUpSelect = new ClassSelector(player);
            DialogResult result = LevelUpSelect.ShowDialog();
            if (result == DialogResult.OK)
            {
                PlayerClass chosenClass = LevelUpSelect.chosenClass;
                foreach (TabPage cPage in ClassTabs.TabPages)
                    if (cPage.Text.TrimStart(new char[] { 'T', 'h', 'e', ' ' }).Equals(chosenClass.Name))
                    {
                        ClassTabs.SelectedTab = cPage;
                        foreach (TabPage scPage in ((ClassPage)cPage.Controls[0]).SubClassTabs.TabPages)
                            if (scPage.Text.Equals(chosenClass.SubClass))
                            {
                                ((ClassPage)cPage.Controls[0]).SubClassTabs.SelectedTab = scPage;
                                break;
                            }
                        break;
                    }
                chosenClass.Level++;
                LevelSetter.Value = chosenClass.Level;
                SetLevelButton_Click(null, null);
            }
        }
    }
}
