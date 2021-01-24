namespace Character_Sheet
{
    partial class ClassReference
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ClassTabs = new System.Windows.Forms.TabControl();
            this.SetLevelButton = new System.Windows.Forms.Button();
            this.ClassLabel = new System.Windows.Forms.Label();
            this.ResetFeaturesButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RemoveClassButton = new System.Windows.Forms.Button();
            this.LevelSetter = new System.Windows.Forms.NumericUpDown();
            this.LevelUpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LevelSetter)).BeginInit();
            this.SuspendLayout();
            // 
            // ClassTabs
            // 
            this.ClassTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClassTabs.Location = new System.Drawing.Point(12, 12);
            this.ClassTabs.Name = "ClassTabs";
            this.ClassTabs.SelectedIndex = 0;
            this.ClassTabs.Size = new System.Drawing.Size(776, 488);
            this.ClassTabs.TabIndex = 1;
            // 
            // SetLevelButton
            // 
            this.SetLevelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SetLevelButton.Location = new System.Drawing.Point(440, 535);
            this.SetLevelButton.Name = "SetLevelButton";
            this.SetLevelButton.Size = new System.Drawing.Size(86, 53);
            this.SetLevelButton.TabIndex = 2;
            this.SetLevelButton.Text = "Set Level for Selected Class";
            this.SetLevelButton.UseVisualStyleBackColor = true;
            this.SetLevelButton.Click += new System.EventHandler(this.SetLevelButton_Click);
            // 
            // ClassLabel
            // 
            this.ClassLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClassLabel.AutoSize = true;
            this.ClassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassLabel.Location = new System.Drawing.Point(12, 523);
            this.ClassLabel.Name = "ClassLabel";
            this.ClassLabel.Size = new System.Drawing.Size(52, 17);
            this.ClassLabel.TabIndex = 3;
            this.ClassLabel.Text = "label1";
            // 
            // ResetFeaturesButton
            // 
            this.ResetFeaturesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetFeaturesButton.Location = new System.Drawing.Point(532, 535);
            this.ResetFeaturesButton.Name = "ResetFeaturesButton";
            this.ResetFeaturesButton.Size = new System.Drawing.Size(83, 53);
            this.ResetFeaturesButton.TabIndex = 4;
            this.ResetFeaturesButton.Text = "Reset Class Features";
            this.ResetFeaturesButton.UseVisualStyleBackColor = true;
            this.ResetFeaturesButton.Click += new System.EventHandler(this.ResetFeaturesButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(713, 535);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 53);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Close";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 504);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Current Classes/Levels";
            // 
            // RemoveClassButton
            // 
            this.RemoveClassButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveClassButton.Location = new System.Drawing.Point(621, 535);
            this.RemoveClassButton.Name = "RemoveClassButton";
            this.RemoveClassButton.Size = new System.Drawing.Size(86, 53);
            this.RemoveClassButton.TabIndex = 7;
            this.RemoveClassButton.Text = "Remove Class";
            this.RemoveClassButton.UseVisualStyleBackColor = true;
            this.RemoveClassButton.Click += new System.EventHandler(this.RemoveClassButton_Click);
            // 
            // LevelSetter
            // 
            this.LevelSetter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LevelSetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelSetter.Location = new System.Drawing.Point(361, 541);
            this.LevelSetter.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.LevelSetter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LevelSetter.Name = "LevelSetter";
            this.LevelSetter.ReadOnly = true;
            this.LevelSetter.Size = new System.Drawing.Size(73, 47);
            this.LevelSetter.TabIndex = 8;
            this.LevelSetter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LevelSetter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LevelUpButton
            // 
            this.LevelUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelUpButton.Location = new System.Drawing.Point(361, 506);
            this.LevelUpButton.Name = "LevelUpButton";
            this.LevelUpButton.Size = new System.Drawing.Size(427, 23);
            this.LevelUpButton.TabIndex = 9;
            this.LevelUpButton.Text = "Level Up";
            this.LevelUpButton.UseVisualStyleBackColor = true;
            this.LevelUpButton.Click += new System.EventHandler(this.LevelUpButton_Click);
            // 
            // ClassReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.LevelUpButton);
            this.Controls.Add(this.LevelSetter);
            this.Controls.Add(this.RemoveClassButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ResetFeaturesButton);
            this.Controls.Add(this.ClassLabel);
            this.Controls.Add(this.SetLevelButton);
            this.Controls.Add(this.ClassTabs);
            this.Name = "ClassReference";
            this.Text = "Character Classes";
            ((System.ComponentModel.ISupportInitialize)(this.LevelSetter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl ClassTabs;
        private System.Windows.Forms.Button SetLevelButton;
        private System.Windows.Forms.Label ClassLabel;
        private System.Windows.Forms.Button ResetFeaturesButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RemoveClassButton;
        private System.Windows.Forms.NumericUpDown LevelSetter;
        private System.Windows.Forms.Button LevelUpButton;
    }
}

