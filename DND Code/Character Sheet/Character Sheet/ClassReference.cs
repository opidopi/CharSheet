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
        public ClassReference()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //StreamReader reader = new StreamReader("C:\\Users\\Sean\\Desktop\\CharTest2.json");
            StreamReader reader = new StreamReader("C:\\Osmose\\DND Code\\DND Code\\CharTest2.json");
            string json = reader.ReadToEnd();
            ClassImport testImport = JsonConvert.DeserializeObject<ClassImport>(json);
            for (int i = 0; i < 12; i++)
            {
                TabPage newPage = new TabPage();
                tabControl1.TabPages.Add(newPage);
                ClassPage newClassPage = new ClassPage();
                newPage.Controls.Add(newClassPage);
                newClassPage.Dock = DockStyle.Fill;
                string classname = null;
                switch(i)
                {
                    case 0:
                        newPage.Text = testImport.Barbarian.Table.Title;
                        DataTable BarbTable = new DataTable();
                        foreach (string header in testImport.Barbarian.Table.Headers)
                            BarbTable.Columns.Add(header);
                        foreach (ClassImport.BarbTable.BarbRow row in testImport.Barbarian.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            BarbTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.Rages, row.RageDamage });
                        }
                        newClassPage.dataGridView1.DataSource = BarbTable;
                        foreach (ClassImport.Feature feature in testImport.Barbarian.ClassFeatures)
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
                        foreach(ClassImport.SubClass subClass in testImport.Barbarian.PrimalPaths)
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
                            newSubClassTab.dataGridView1.DataSource = featureTable;
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
                            newClassPage.tabControl1.Controls.Add(newSubPage);
                        }
                        break;
                    case 1:
                        newPage.Text = testImport.Bard.Table.Title;
                        DataTable BardTable = new DataTable();
                        foreach (string header in testImport.Bard.Table.Headers)
                            BardTable.Columns.Add(header);
                        foreach (ClassImport.BardTable.BardRow row in testImport.Bard.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            BardTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.CantripsKnown, row.SpellsKnown, row.First, row.Second, row.Third, row.Fourth, row.Fifth, row.Sixth, row.Seventh, row.Eighth, row.Ninth});
                        }
                        newClassPage.dataGridView1.DataSource = BardTable;
                        foreach (ClassImport.Feature feature in testImport.Bard.ClassFeatures)
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
                        foreach (ClassImport.SubClass subClass in testImport.Bard.BardColleges)
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
                            newSubClassTab.dataGridView1.DataSource = featureTable;
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
                            newClassPage.tabControl1.Controls.Add(newSubPage);
                        }
                        break;
                    case 2:
                        newPage.Text = testImport.Cleric.Table.Title;
                        DataTable ClericTable = new DataTable();
                        foreach (string header in testImport.Cleric.Table.Headers)
                            ClericTable.Columns.Add(header);
                        foreach (ClassImport.ClericTable.ClericRow row in testImport.Cleric.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            ClericTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.CantripsKnown, row.First, row.Second, row.Third, row.Fourth, row.Fifth, row.Sixth, row.Seventh, row.Eighth, row.Ninth });
                        }
                        newClassPage.dataGridView1.DataSource = ClericTable;
                        foreach (ClassImport.Feature feature in testImport.Cleric.ClassFeatures)
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
                        foreach (ClassImport.SubClass subClass in testImport.Cleric.DivineDomains)
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
                            newSubClassTab.dataGridView1.DataSource = featureTable;
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
                            newClassPage.tabControl1.Controls.Add(newSubPage);
                        }
                        break;
                    case 3:
                        newPage.Text = testImport.Druid.Table.Title;
                        DataTable DruidTable = new DataTable();
                        foreach (string header in testImport.Druid.Table.Headers)
                            DruidTable.Columns.Add(header);
                        foreach (ClassImport.DruidTable.DruidRow row in testImport.Druid.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            DruidTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.CantripsKnown, row.First, row.Second, row.Third, row.Fourth, row.Fifth, row.Sixth, row.Seventh, row.Eighth, row.Ninth });
                        }
                        newClassPage.dataGridView1.DataSource = DruidTable;
                        foreach (ClassImport.Feature feature in testImport.Druid.ClassFeatures)
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
                        foreach (ClassImport.SubClass subClass in testImport.Druid.DruidCircles)
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
                            newSubClassTab.dataGridView1.DataSource = featureTable;
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
                            newClassPage.tabControl1.Controls.Add(newSubPage);
                        }
                        break;
                    case 4:
                        newPage.Text = testImport.Fighter.Table.Title;
                        DataTable FighterTable = new DataTable();
                        foreach (string header in testImport.Fighter.Table.Headers)
                            FighterTable.Columns.Add(header);
                        foreach (ClassImport.FightTable.FightRow row in testImport.Fighter.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            FighterTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features });
                        }
                        newClassPage.dataGridView1.DataSource = FighterTable;
                        foreach (ClassImport.Feature feature in testImport.Fighter.ClassFeatures)
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
                        foreach (ClassImport.SubClass subClass in testImport.Fighter.MartialArchetypes)
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
                            newSubClassTab.dataGridView1.DataSource = featureTable;
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
                            newClassPage.tabControl1.Controls.Add(newSubPage);
                        }
                        break;
                    case 5:
                        newPage.Text = testImport.Monk.Table.Title;
                        DataTable MonkTable = new DataTable();
                        foreach (string header in testImport.Monk.Table.Headers)
                            MonkTable.Columns.Add(header);
                        foreach (ClassImport.MonkTable.MonkRow row in testImport.Monk.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            MonkTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, row.MartialArts, row.KiPoints, row.UnarmoredMovement, features });
                        }
                        newClassPage.dataGridView1.DataSource = MonkTable;
                        foreach (ClassImport.Feature feature in testImport.Monk.ClassFeatures)
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
                        foreach (ClassImport.SubClass subClass in testImport.Monk.MonasticTraditions)
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
                            newSubClassTab.dataGridView1.DataSource = featureTable;
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
                            newClassPage.tabControl1.Controls.Add(newSubPage);
                        }
                        break;
                    case 6:
                        newPage.Text = testImport.Paladin.Table.Title;
                        DataTable PaladinTable = new DataTable();
                        foreach (string header in testImport.Paladin.Table.Headers)
                            PaladinTable.Columns.Add(header);
                        foreach (ClassImport.PaladinTable.PaladinRow row in testImport.Paladin.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            PaladinTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.First, row.Second, row.Third, row.Fourth, row.Fifth });
                        }
                        newClassPage.dataGridView1.DataSource = PaladinTable;
                        foreach (ClassImport.Feature feature in testImport.Paladin.ClassFeatures)
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
                        foreach (ClassImport.SubClass subClass in testImport.Paladin.SacredOaths)
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
                            newSubClassTab.dataGridView1.DataSource = featureTable;
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
                            newClassPage.tabControl1.Controls.Add(newSubPage);
                        }
                        break; 
                    case 7:
                        newPage.Text = testImport.Ranger.Table.Title;
                        DataTable RangerTable = new DataTable();
                        foreach (string header in testImport.Ranger.Table.Headers)
                            RangerTable.Columns.Add(header);
                        foreach (ClassImport.RangerTable.RangerRow row in testImport.Ranger.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            RangerTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.SpellsKnown, row.First, row.Second, row.Third, row.Fourth, row.Fifth });
                        }
                        newClassPage.dataGridView1.DataSource = RangerTable;
                        foreach (ClassImport.Feature feature in testImport.Ranger.ClassFeatures)
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
                        foreach (ClassImport.SubClass subClass in testImport.Ranger.RangerArchetypes)
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
                            newSubClassTab.dataGridView1.DataSource = featureTable;
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
                            newClassPage.tabControl1.Controls.Add(newSubPage);
                        }
                        break;
                    case 8:
                        newPage.Text = testImport.Rogue.Table.Title;
                        DataTable RogueTable = new DataTable();
                        foreach (string header in testImport.Rogue.Table.Headers)
                            RogueTable.Columns.Add(header);
                        foreach (ClassImport.RogueTable.RogueRow row in testImport.Rogue.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            RogueTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, row.SneakAttack, features });
                        }
                        newClassPage.dataGridView1.DataSource = RogueTable;
                        foreach (ClassImport.Feature feature in testImport.Rogue.ClassFeatures)
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
                        foreach (ClassImport.SubClass subClass in testImport.Rogue.RoguishArchetypes)
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
                            newSubClassTab.dataGridView1.DataSource = featureTable;
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
                            newClassPage.tabControl1.Controls.Add(newSubPage);
                        }
                        break;
                    case 9:
                        newPage.Text = testImport.Sorcerer.Table.Title;
                        DataTable SorcererTable = new DataTable();
                        foreach (string header in testImport.Sorcerer.Table.Headers)
                            SorcererTable.Columns.Add(header);
                        foreach (ClassImport.SorcTable.SorcRow row in testImport.Sorcerer.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            SorcererTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, row.SorceryPoints, features, row.CantripsKnown, row.SpellsKnown, row.First, row.Second, row.Third, row.Fourth, row.Fifth, row.Sixth, row.Seventh, row.Eighth, row.Ninth });
                        }
                        newClassPage.dataGridView1.DataSource = SorcererTable;
                        foreach (ClassImport.Feature feature in testImport.Sorcerer.ClassFeatures)
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
                        foreach (ClassImport.SubClass subClass in testImport.Sorcerer.SorcerousOrigins)
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
                            newSubClassTab.dataGridView1.DataSource = featureTable;
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
                            newClassPage.tabControl1.Controls.Add(newSubPage);
                        }
                        break;
                    case 10:
                        newPage.Text = testImport.Warlock.Table.Title;
                        DataTable WarlockTable = new DataTable();
                        foreach (string header in testImport.Warlock.Table.Headers)
                            WarlockTable.Columns.Add(header);
                        foreach (ClassImport.WarlockTable.WarlockRow row in testImport.Warlock.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            WarlockTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.CantripsKnown, row.SpellsKnown, row.SpellSlots, row.SlotLevel, row.InvocationsKnown });
                        }
                        newClassPage.dataGridView1.DataSource = WarlockTable;
                        foreach (ClassImport.Feature feature in testImport.Warlock.ClassFeatures)
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
                        foreach (ClassImport.SubClass subClass in testImport.Warlock.OtherworldlyPatrons)
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
                            newSubClassTab.dataGridView1.DataSource = featureTable;
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
                            newClassPage.tabControl1.Controls.Add(newSubPage);
                        }
                        break;
                    case 11:
                        newPage.Text = testImport.Wizard.Table.Title;
                        DataTable WizardTable = new DataTable();
                        foreach (string header in testImport.Wizard.Table.Headers)
                            WizardTable.Columns.Add(header);
                        foreach (ClassImport.WizardTable.WizardRow row in testImport.Wizard.Table.Rows)
                        {
                            string features = "";
                            if (row.Features.Length > 0)
                                features = row.Features[0];
                            for (int j = 1; j < row.Features.Length; j++)
                                features += ", " + row.Features[j];
                            WizardTable.Rows.Add(new object[] { row.Level, row.ProficiencyBonus, features, row.CantripsKnown, row.First, row.Second, row.Third, row.Fourth, row.Fifth, row.Sixth, row.Seventh, row.Eighth, row.Ninth });
                        }
                        newClassPage.dataGridView1.DataSource = WizardTable;
                        foreach (ClassImport.Feature feature in testImport.Wizard.ClassFeatures)
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
                        foreach (ClassImport.SubClass subClass in testImport.Wizard.ArcaneTraditions)
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
                            newSubClassTab.dataGridView1.DataSource = featureTable;
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
                            newClassPage.tabControl1.Controls.Add(newSubPage);
                        }
                        break;
                    default:
                        classname = "Error Test";
                        break;
                }
            }

        }
    }
}
