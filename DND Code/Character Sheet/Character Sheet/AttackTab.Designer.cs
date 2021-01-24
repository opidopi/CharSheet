namespace Character_Sheet
{
    partial class AttackTab
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AttackTotal = new System.Windows.Forms.TextBox();
            this.DamageTotal = new System.Windows.Forms.TextBox();
            this.DamageLabel = new System.Windows.Forms.Label();
            this.Selected = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(26, 24);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(49, 17);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Damage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ATK Bonus";
            // 
            // AttackTotal
            // 
            this.AttackTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AttackTotal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AttackTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttackTotal.Location = new System.Drawing.Point(152, 16);
            this.AttackTotal.Name = "AttackTotal";
            this.AttackTotal.ReadOnly = true;
            this.AttackTotal.Size = new System.Drawing.Size(35, 29);
            this.AttackTotal.TabIndex = 36;
            this.AttackTotal.Text = "+0";
            this.AttackTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DamageTotal
            // 
            this.DamageTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DamageTotal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DamageTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DamageTotal.Location = new System.Drawing.Point(193, 16);
            this.DamageTotal.Name = "DamageTotal";
            this.DamageTotal.ReadOnly = true;
            this.DamageTotal.Size = new System.Drawing.Size(156, 29);
            this.DamageTotal.TabIndex = 37;
            this.DamageTotal.Text = "+0";
            this.DamageTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DamageLabel
            // 
            this.DamageLabel.AutoSize = true;
            this.DamageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DamageLabel.Location = new System.Drawing.Point(26, 50);
            this.DamageLabel.Name = "DamageLabel";
            this.DamageLabel.Size = new System.Drawing.Size(85, 13);
            this.DamageLabel.TabIndex = 38;
            this.DamageLabel.Text = "Damage Type";
            // 
            // Selected
            // 
            this.Selected.AutoSize = true;
            this.Selected.Location = new System.Drawing.Point(3, 26);
            this.Selected.Name = "Selected";
            this.Selected.Size = new System.Drawing.Size(14, 13);
            this.Selected.TabIndex = 39;
            this.Selected.TabStop = true;
            this.Selected.UseVisualStyleBackColor = true;
            this.Selected.Click += new System.EventHandler(this.Selected_CheckedChanged);
            // 
            // AttackTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Selected);
            this.Controls.Add(this.DamageLabel);
            this.Controls.Add(this.DamageTotal);
            this.Controls.Add(this.AttackTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameLabel);
            this.Name = "AttackTab";
            this.Size = new System.Drawing.Size(352, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AttackTotal;
        private System.Windows.Forms.TextBox DamageTotal;
        private System.Windows.Forms.Label DamageLabel;
        public System.Windows.Forms.RadioButton Selected;
    }
}
