namespace Character_Sheet
{
    partial class MovementTab
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
            this.Speed = new System.Windows.Forms.TextBox();
            this.EditSpeed = new System.Windows.Forms.Button();
            this.DecSpeed = new System.Windows.Forms.Button();
            this.IncSpeed = new System.Windows.Forms.Button();
            this.MovementName = new System.Windows.Forms.Label();
            this.ftLabel = new System.Windows.Forms.Label();
            this.RemoveMovement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Speed
            // 
            this.Speed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Speed.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Speed.Location = new System.Drawing.Point(122, 0);
            this.Speed.Name = "Speed";
            this.Speed.ReadOnly = true;
            this.Speed.Size = new System.Drawing.Size(40, 32);
            this.Speed.TabIndex = 3;
            this.Speed.Text = "0";
            this.Speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EditSpeed
            // 
            this.EditSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSpeed.Location = new System.Drawing.Point(72, 2);
            this.EditSpeed.Name = "EditSpeed";
            this.EditSpeed.Size = new System.Drawing.Size(21, 29);
            this.EditSpeed.TabIndex = 36;
            this.EditSpeed.Text = "E";
            this.EditSpeed.UseVisualStyleBackColor = true;
            this.EditSpeed.Click += new System.EventHandler(this.EditSpeed_Click);
            // 
            // DecSpeed
            // 
            this.DecSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecSpeed.Location = new System.Drawing.Point(99, 17);
            this.DecSpeed.Name = "DecSpeed";
            this.DecSpeed.Size = new System.Drawing.Size(18, 15);
            this.DecSpeed.TabIndex = 35;
            this.DecSpeed.Text = "▼";
            this.DecSpeed.Click += new System.EventHandler(this.DecSpeed_Click);
            // 
            // IncSpeed
            // 
            this.IncSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncSpeed.Location = new System.Drawing.Point(99, 2);
            this.IncSpeed.Name = "IncSpeed";
            this.IncSpeed.Size = new System.Drawing.Size(18, 15);
            this.IncSpeed.TabIndex = 37;
            this.IncSpeed.Text = "▲";
            this.IncSpeed.Click += new System.EventHandler(this.IncSpeed_Click);
            // 
            // MovementName
            // 
            this.MovementName.AutoSize = true;
            this.MovementName.Location = new System.Drawing.Point(31, 11);
            this.MovementName.Name = "MovementName";
            this.MovementName.Size = new System.Drawing.Size(35, 13);
            this.MovementName.TabIndex = 38;
            this.MovementName.Text = "label1";
            // 
            // ftLabel
            // 
            this.ftLabel.AutoSize = true;
            this.ftLabel.Location = new System.Drawing.Point(168, 11);
            this.ftLabel.Name = "ftLabel";
            this.ftLabel.Size = new System.Drawing.Size(13, 13);
            this.ftLabel.TabIndex = 39;
            this.ftLabel.Text = "ft";
            // 
            // RemoveMovement
            // 
            this.RemoveMovement.Location = new System.Drawing.Point(5, 7);
            this.RemoveMovement.Name = "RemoveMovement";
            this.RemoveMovement.Size = new System.Drawing.Size(20, 20);
            this.RemoveMovement.TabIndex = 40;
            this.RemoveMovement.Text = "-";
            this.RemoveMovement.UseVisualStyleBackColor = true;
            this.RemoveMovement.Click += new System.EventHandler(this.RemoveMovement_Click);
            // 
            // MovementTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RemoveMovement);
            this.Controls.Add(this.ftLabel);
            this.Controls.Add(this.MovementName);
            this.Controls.Add(this.EditSpeed);
            this.Controls.Add(this.DecSpeed);
            this.Controls.Add(this.IncSpeed);
            this.Controls.Add(this.Speed);
            this.Name = "MovementTab";
            this.Size = new System.Drawing.Size(184, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Speed;
        private System.Windows.Forms.Button EditSpeed;
        private System.Windows.Forms.Button DecSpeed;
        private System.Windows.Forms.Button IncSpeed;
        private System.Windows.Forms.Label MovementName;
        private System.Windows.Forms.Label ftLabel;
        private System.Windows.Forms.Button RemoveMovement;
    }
}
