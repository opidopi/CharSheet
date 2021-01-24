namespace Character_Sheet
{
    partial class SaveTab
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
            this.Proficiency = new System.Windows.Forms.CheckBox();
            this.PlayerMod = new System.Windows.Forms.TextBox();
            this.SaveLabel = new System.Windows.Forms.Label();
            this.EditPlayermod = new System.Windows.Forms.Button();
            this.DecPlayerMod = new System.Windows.Forms.Button();
            this.IncPlayerMod = new System.Windows.Forms.Button();
            this.SaveTotal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Proficiency
            // 
            this.Proficiency.AutoSize = true;
            this.Proficiency.Location = new System.Drawing.Point(3, 8);
            this.Proficiency.Name = "Proficiency";
            this.Proficiency.Size = new System.Drawing.Size(15, 14);
            this.Proficiency.TabIndex = 0;
            this.Proficiency.UseVisualStyleBackColor = true;
            this.Proficiency.CheckedChanged += new System.EventHandler(this.Proficiency_CheckedChanged);
            // 
            // PlayerMod
            // 
            this.PlayerMod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlayerMod.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.PlayerMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerMod.Location = new System.Drawing.Point(152, 0);
            this.PlayerMod.Name = "PlayerMod";
            this.PlayerMod.ReadOnly = true;
            this.PlayerMod.Size = new System.Drawing.Size(35, 22);
            this.PlayerMod.TabIndex = 12;
            this.PlayerMod.Text = "+0";
            this.PlayerMod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SaveLabel
            // 
            this.SaveLabel.AutoSize = true;
            this.SaveLabel.Location = new System.Drawing.Point(65, 8);
            this.SaveLabel.Name = "SaveLabel";
            this.SaveLabel.Size = new System.Drawing.Size(35, 13);
            this.SaveLabel.TabIndex = 13;
            this.SaveLabel.Text = "label1";
            // 
            // EditPlayermod
            // 
            this.EditPlayermod.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditPlayermod.Location = new System.Drawing.Point(202, 0);
            this.EditPlayermod.Name = "EditPlayermod";
            this.EditPlayermod.Size = new System.Drawing.Size(21, 29);
            this.EditPlayermod.TabIndex = 26;
            this.EditPlayermod.Text = "E";
            this.EditPlayermod.UseVisualStyleBackColor = true;
            this.EditPlayermod.Click += new System.EventHandler(this.EditPlayermod_Click);
            // 
            // DecPlayerMod
            // 
            this.DecPlayerMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecPlayerMod.Location = new System.Drawing.Point(182, 14);
            this.DecPlayerMod.Name = "DecPlayerMod";
            this.DecPlayerMod.Size = new System.Drawing.Size(18, 15);
            this.DecPlayerMod.TabIndex = 25;
            this.DecPlayerMod.Text = "▼";
            this.DecPlayerMod.Click += new System.EventHandler(this.DecPlayerMod_Click);
            // 
            // IncPlayerMod
            // 
            this.IncPlayerMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncPlayerMod.Location = new System.Drawing.Point(182, 0);
            this.IncPlayerMod.Name = "IncPlayerMod";
            this.IncPlayerMod.Size = new System.Drawing.Size(18, 15);
            this.IncPlayerMod.TabIndex = 27;
            this.IncPlayerMod.Text = "▲";
            this.IncPlayerMod.Click += new System.EventHandler(this.IncPlayerMod_Click);
            // 
            // SaveTotal
            // 
            this.SaveTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SaveTotal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.SaveTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveTotal.Location = new System.Drawing.Point(24, 0);
            this.SaveTotal.Name = "SaveTotal";
            this.SaveTotal.ReadOnly = true;
            this.SaveTotal.Size = new System.Drawing.Size(35, 29);
            this.SaveTotal.TabIndex = 28;
            this.SaveTotal.Text = "+0";
            this.SaveTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SaveTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SaveTotal);
            this.Controls.Add(this.EditPlayermod);
            this.Controls.Add(this.DecPlayerMod);
            this.Controls.Add(this.IncPlayerMod);
            this.Controls.Add(this.SaveLabel);
            this.Controls.Add(this.PlayerMod);
            this.Controls.Add(this.Proficiency);
            this.Name = "SaveTab";
            this.Size = new System.Drawing.Size(226, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox PlayerMod;
        private System.Windows.Forms.Label SaveLabel;
        private System.Windows.Forms.Button EditPlayermod;
        private System.Windows.Forms.Button DecPlayerMod;
        private System.Windows.Forms.Button IncPlayerMod;
        private System.Windows.Forms.TextBox SaveTotal;
        public System.Windows.Forms.CheckBox Proficiency;
    }
}
