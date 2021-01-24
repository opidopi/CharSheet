using Newtonsoft.Json;
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

namespace Character_Sheet
{
    public partial class AddFeatDialog : Form
    {
        PlayerCharacter player;
        public AddFeatDialog(PlayerCharacter pPlayer)
        {
            InitializeComponent();

            List<Feature> featList;
            StreamReader reader = new StreamReader("FeatList.json");
            string json = reader.ReadToEnd();
            featList = JsonConvert.DeserializeObject<List<Feature>>(json);

            foreach (Feature feat in featList)
                FeatCombo.Items.Add(feat);

            Feature customFeat = new Feature();
            customFeat.Name = "Custom";
            customFeat.Description = new string[]{""};
            FeatCombo.Items.Add(customFeat);
            FeatCombo.SelectedItem = FeatCombo.Items[0];
            player = pPlayer;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            Feature selectedFeat = (Feature)FeatCombo.SelectedItem;
            selectedFeat.Name = NameTextBox.Text;
            selectedFeat.Description = DescriptionTextBox.Text.Split('\n');
            player.FeatsNtraits.Add(selectedFeat);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void FeatCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Feature feat = (Feature)FeatCombo.SelectedItem;
            NameTextBox.Text = feat.Name;
            string featureDesc = "";
            foreach (string featureline in feat.Description)
                featureDesc += featureline + "\n";
            if (featureDesc.Equals("\n"))
                featureDesc = "";
            DescriptionTextBox.Text = featureDesc;
            if(feat.Name.Equals("Custom"))
            {
                NameTextBox.ReadOnly = false;
                DescriptionTextBox.ReadOnly = false;
            }
            else
            {
                NameTextBox.ReadOnly = true;
                DescriptionTextBox.ReadOnly = true;
            }
        }
    }
}
