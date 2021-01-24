namespace Character_Sheet
{
    partial class MovementSelect
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
            System.Windows.Forms.Label SpeedLabel;
            this.MoveCombo = new System.Windows.Forms.ComboBox();
            this.SpeedTextBox = new System.Windows.Forms.TextBox();
            this.NewNameTextbox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.MovementTypeLabel = new System.Windows.Forms.Label();
            this.NewNameLabel = new System.Windows.Forms.Label();
            SpeedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SpeedLabel
            // 
            SpeedLabel.AutoSize = true;
            SpeedLabel.Location = new System.Drawing.Point(265, 33);
            SpeedLabel.Name = "SpeedLabel";
            SpeedLabel.Size = new System.Drawing.Size(41, 13);
            SpeedLabel.TabIndex = 7;
            SpeedLabel.Text = "Speed:";
            // 
            // MoveCombo
            // 
            this.MoveCombo.DisplayMember = "Name";
            this.MoveCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MoveCombo.FormattingEnabled = true;
            this.MoveCombo.Location = new System.Drawing.Point(13, 30);
            this.MoveCombo.Name = "MoveCombo";
            this.MoveCombo.Size = new System.Drawing.Size(190, 21);
            this.MoveCombo.TabIndex = 0;
            this.MoveCombo.ValueMember = "Name";
            this.MoveCombo.SelectedIndexChanged += new System.EventHandler(this.MoveCombo_SelectedIndexChanged);
            // 
            // SpeedTextBox
            // 
            this.SpeedTextBox.Location = new System.Drawing.Point(310, 30);
            this.SpeedTextBox.Name = "SpeedTextBox";
            this.SpeedTextBox.Size = new System.Drawing.Size(71, 20);
            this.SpeedTextBox.TabIndex = 1;
            // 
            // NewNameTextbox
            // 
            this.NewNameTextbox.Location = new System.Drawing.Point(95, 62);
            this.NewNameTextbox.Name = "NewNameTextbox";
            this.NewNameTextbox.Size = new System.Drawing.Size(108, 20);
            this.NewNameTextbox.TabIndex = 2;
            this.NewNameTextbox.Visible = false;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(306, 62);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(225, 62);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MovementTypeLabel
            // 
            this.MovementTypeLabel.AutoSize = true;
            this.MovementTypeLabel.Location = new System.Drawing.Point(13, 11);
            this.MovementTypeLabel.Name = "MovementTypeLabel";
            this.MovementTypeLabel.Size = new System.Drawing.Size(84, 13);
            this.MovementTypeLabel.TabIndex = 5;
            this.MovementTypeLabel.Text = "Movement Type";
            // 
            // NewNameLabel
            // 
            this.NewNameLabel.AutoSize = true;
            this.NewNameLabel.Location = new System.Drawing.Point(13, 65);
            this.NewNameLabel.Name = "NewNameLabel";
            this.NewNameLabel.Size = new System.Drawing.Size(76, 13);
            this.NewNameLabel.TabIndex = 6;
            this.NewNameLabel.Text = "Custom Name:";
            this.NewNameLabel.Visible = false;
            // 
            // MovementSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 94);
            this.Controls.Add(SpeedLabel);
            this.Controls.Add(this.NewNameLabel);
            this.Controls.Add(this.MovementTypeLabel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.NewNameTextbox);
            this.Controls.Add(this.SpeedTextBox);
            this.Controls.Add(this.MoveCombo);
            this.Name = "MovementSelect";
            this.Text = "MovementSelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox MoveCombo;
        private System.Windows.Forms.TextBox SpeedTextBox;
        private System.Windows.Forms.TextBox NewNameTextbox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label MovementTypeLabel;
        private System.Windows.Forms.Label NewNameLabel;
    }
}