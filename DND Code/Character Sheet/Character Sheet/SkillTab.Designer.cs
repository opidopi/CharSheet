namespace Character_Sheet
{
    partial class SkillTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SkillTotal = new System.Windows.Forms.TextBox();
            this.EditPlayermod = new System.Windows.Forms.Button();
            this.DecPlayerMod = new System.Windows.Forms.Button();
            this.IncPlayerMod = new System.Windows.Forms.Button();
            this.SkillLabel = new System.Windows.Forms.Label();
            this.PlayerMod = new System.Windows.Forms.TextBox();
            this.Proficiency = new System.Windows.Forms.CheckBox();
            this.ModLabel = new System.Windows.Forms.Label();
            this.ProfLabel = new System.Windows.Forms.Label();
            this.Expertise = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // SkillTotal
            // 
            this.SkillTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SkillTotal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.SkillTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SkillTotal.Location = new System.Drawing.Point(92, 18);
            this.SkillTotal.Name = "SkillTotal";
            this.SkillTotal.ReadOnly = true;
            this.SkillTotal.Size = new System.Drawing.Size(35, 29);
            this.SkillTotal.TabIndex = 35;
            this.SkillTotal.Text = "+0";
            this.SkillTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EditPlayermod
            // 
            this.EditPlayermod.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditPlayermod.Location = new System.Drawing.Point(301, 20);
            this.EditPlayermod.Name = "EditPlayermod";
            this.EditPlayermod.Size = new System.Drawing.Size(21, 29);
            this.EditPlayermod.TabIndex = 33;
            this.EditPlayermod.Text = "E";
            this.EditPlayermod.UseVisualStyleBackColor = true;
            this.EditPlayermod.Click += new System.EventHandler(this.EditPlayermod_Click);
            // 
            // DecPlayerMod
            // 
            this.DecPlayerMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecPlayerMod.Location = new System.Drawing.Point(281, 34);
            this.DecPlayerMod.Name = "DecPlayerMod";
            this.DecPlayerMod.Size = new System.Drawing.Size(18, 15);
            this.DecPlayerMod.TabIndex = 32;
            this.DecPlayerMod.Text = "▼";
            this.DecPlayerMod.Click += new System.EventHandler(this.DecPlayerMod_Click);
            // 
            // IncPlayerMod
            // 
            this.IncPlayerMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncPlayerMod.Location = new System.Drawing.Point(281, 20);
            this.IncPlayerMod.Name = "IncPlayerMod";
            this.IncPlayerMod.Size = new System.Drawing.Size(18, 15);
            this.IncPlayerMod.TabIndex = 34;
            this.IncPlayerMod.Text = "▲";
            this.IncPlayerMod.Click += new System.EventHandler(this.IncPlayerMod_Click);
            // 
            // SkillLabel
            // 
            this.SkillLabel.AutoSize = true;
            this.SkillLabel.Location = new System.Drawing.Point(133, 26);
            this.SkillLabel.Name = "SkillLabel";
            this.SkillLabel.Size = new System.Drawing.Size(35, 13);
            this.SkillLabel.TabIndex = 31;
            this.SkillLabel.Text = "label1";
            // 
            // PlayerMod
            // 
            this.PlayerMod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlayerMod.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.PlayerMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerMod.Location = new System.Drawing.Point(251, 20);
            this.PlayerMod.Name = "PlayerMod";
            this.PlayerMod.ReadOnly = true;
            this.PlayerMod.Size = new System.Drawing.Size(35, 22);
            this.PlayerMod.TabIndex = 30;
            this.PlayerMod.Text = "+0";
            this.PlayerMod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Proficiency
            // 
            this.Proficiency.AutoSize = true;
            this.Proficiency.Location = new System.Drawing.Point(52, 21);
            this.Proficiency.Name = "Proficiency";
            this.Proficiency.Size = new System.Drawing.Size(15, 14);
            this.Proficiency.TabIndex = 29;
            this.Proficiency.UseVisualStyleBackColor = true;
            this.Proficiency.CheckedChanged += new System.EventHandler(this.Proficiency_CheckedChanged);
            // 
            // ModLabel
            // 
            this.ModLabel.AutoSize = true;
            this.ModLabel.Location = new System.Drawing.Point(245, 0);
            this.ModLabel.Name = "ModLabel";
            this.ModLabel.Size = new System.Drawing.Size(80, 13);
            this.ModLabel.TabIndex = 36;
            this.ModLabel.Text = "Additional Mod.";
            // 
            // ProfLabel
            // 
            this.ProfLabel.AutoSize = true;
            this.ProfLabel.Location = new System.Drawing.Point(3, 2);
            this.ProfLabel.Name = "ProfLabel";
            this.ProfLabel.Size = new System.Drawing.Size(84, 13);
            this.ProfLabel.TabIndex = 37;
            this.ProfLabel.Text = "Expert Proficient";
            // 
            // Expertise
            // 
            this.Expertise.AutoSize = true;
            this.Expertise.Location = new System.Drawing.Point(16, 21);
            this.Expertise.Name = "Expertise";
            this.Expertise.Size = new System.Drawing.Size(15, 14);
            this.Expertise.TabIndex = 38;
            this.Expertise.UseVisualStyleBackColor = true;
            this.Expertise.CheckedChanged += new System.EventHandler(this.Expertise_CheckedChanged);
            // 
            // SkillTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Expertise);
            this.Controls.Add(this.ProfLabel);
            this.Controls.Add(this.ModLabel);
            this.Controls.Add(this.SkillTotal);
            this.Controls.Add(this.EditPlayermod);
            this.Controls.Add(this.DecPlayerMod);
            this.Controls.Add(this.IncPlayerMod);
            this.Controls.Add(this.SkillLabel);
            this.Controls.Add(this.PlayerMod);
            this.Controls.Add(this.Proficiency);
            this.Name = "SkillTab";
            this.Size = new System.Drawing.Size(325, 52);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SkillTotal;
        private System.Windows.Forms.Button EditPlayermod;
        private System.Windows.Forms.Button DecPlayerMod;
        private System.Windows.Forms.Button IncPlayerMod;
        private System.Windows.Forms.Label SkillLabel;
        private System.Windows.Forms.TextBox PlayerMod;
        private System.Windows.Forms.Label ModLabel;
        private System.Windows.Forms.Label ProfLabel;
        public System.Windows.Forms.CheckBox Proficiency;
        public System.Windows.Forms.CheckBox Expertise;
    }
}
