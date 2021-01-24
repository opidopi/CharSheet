namespace Character_Sheet
{
    partial class CoreStatTab
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
            this.StatBase = new System.Windows.Forms.TextBox();
            this.Modifier = new System.Windows.Forms.Label();
            this.Increase = new System.Windows.Forms.Button();
            this.Decrease = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.StatName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StatBase
            // 
            this.StatBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatBase.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.StatBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatBase.Location = new System.Drawing.Point(3, 29);
            this.StatBase.Name = "StatBase";
            this.StatBase.ReadOnly = true;
            this.StatBase.Size = new System.Drawing.Size(45, 34);
            this.StatBase.TabIndex = 0;
            this.StatBase.Text = "0";
            this.StatBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Modifier
            // 
            this.Modifier.AutoSize = true;
            this.Modifier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Modifier.Location = new System.Drawing.Point(15, 66);
            this.Modifier.Name = "Modifier";
            this.Modifier.Size = new System.Drawing.Size(21, 15);
            this.Modifier.TabIndex = 1;
            this.Modifier.Text = "+0";
            // 
            // Increase
            // 
            this.Increase.Location = new System.Drawing.Point(54, 26);
            this.Increase.Name = "Increase";
            this.Increase.Size = new System.Drawing.Size(26, 19);
            this.Increase.TabIndex = 5;
            this.Increase.Text = "▲";
            this.Increase.Click += new System.EventHandler(this.Increase_Click);
            // 
            // Decrease
            // 
            this.Decrease.Location = new System.Drawing.Point(54, 47);
            this.Decrease.Name = "Decrease";
            this.Decrease.Size = new System.Drawing.Size(26, 19);
            this.Decrease.TabIndex = 3;
            this.Decrease.Text = "▼";
            this.Decrease.Click += new System.EventHandler(this.Decrease_Click);
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(54, 67);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(26, 23);
            this.Edit.TabIndex = 4;
            this.Edit.Text = "E";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // StatName
            // 
            this.StatName.AutoSize = true;
            this.StatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatName.Location = new System.Drawing.Point(3, 8);
            this.StatName.Name = "StatName";
            this.StatName.Size = new System.Drawing.Size(70, 15);
            this.StatName.TabIndex = 6;
            this.StatName.Text = "StatName";
            // 
            // CoreStatTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StatName);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Decrease);
            this.Controls.Add(this.Increase);
            this.Controls.Add(this.Modifier);
            this.Controls.Add(this.StatBase);
            this.Name = "CoreStatTab";
            this.Size = new System.Drawing.Size(83, 91);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox StatBase;
        private System.Windows.Forms.Label Modifier;
        private System.Windows.Forms.Button Increase;
        private System.Windows.Forms.Button Decrease;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Label StatName;
    }
}
