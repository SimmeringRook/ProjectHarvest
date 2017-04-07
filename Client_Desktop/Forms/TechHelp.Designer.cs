namespace Client_Desktop
{
    partial class TechHelp
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.williamEmailLabel = new System.Windows.Forms.Label();
            this.thomasEmailLabel = new System.Windows.Forms.Label();
            this.copyThomasButton = new System.Windows.Forms.Button();
            this.copyWilliamEmail = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thomas Knudson";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "William Buckwell";
            // 
            // williamEmailLabel
            // 
            this.williamEmailLabel.AutoSize = true;
            this.williamEmailLabel.Location = new System.Drawing.Point(54, 160);
            this.williamEmailLabel.Name = "williamEmailLabel";
            this.williamEmailLabel.Size = new System.Drawing.Size(196, 13);
            this.williamEmailLabel.TabIndex = 2;
            this.williamEmailLabel.Text = "buckwelw5455@student.faytechcc.edu";
            // 
            // thomasEmailLabel
            // 
            this.thomasEmailLabel.AutoSize = true;
            this.thomasEmailLabel.Location = new System.Drawing.Point(58, 63);
            this.thomasEmailLabel.Name = "thomasEmailLabel";
            this.thomasEmailLabel.Size = new System.Drawing.Size(192, 13);
            this.thomasEmailLabel.TabIndex = 3;
            this.thomasEmailLabel.Text = "knudsont6467@student.faytechcc.edu";
            // 
            // copyThomasButton
            // 
            this.copyThomasButton.Location = new System.Drawing.Point(64, 79);
            this.copyThomasButton.Name = "copyThomasButton";
            this.copyThomasButton.Size = new System.Drawing.Size(164, 23);
            this.copyThomasButton.TabIndex = 4;
            this.copyThomasButton.Text = "Copy Thomas\'s e-mail";
            this.copyThomasButton.UseVisualStyleBackColor = true;
            this.copyThomasButton.Click += new System.EventHandler(this.copyThomasButton_Click);
            // 
            // copyWilliamEmail
            // 
            this.copyWilliamEmail.Location = new System.Drawing.Point(64, 176);
            this.copyWilliamEmail.Name = "copyWilliamEmail";
            this.copyWilliamEmail.Size = new System.Drawing.Size(164, 23);
            this.copyWilliamEmail.TabIndex = 5;
            this.copyWilliamEmail.Text = "Copy William\'s e-mail";
            this.copyWilliamEmail.UseVisualStyleBackColor = true;
            this.copyWilliamEmail.Click += new System.EventHandler(this.copyWilliamEmail_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "For any questions please contact one of the below Techs.";
            // 
            // TechHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 224);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.copyWilliamEmail);
            this.Controls.Add(this.copyThomasButton);
            this.Controls.Add(this.thomasEmailLabel);
            this.Controls.Add(this.williamEmailLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TechHelp";
            this.Text = "Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label williamEmailLabel;
        private System.Windows.Forms.Label thomasEmailLabel;
        private System.Windows.Forms.Button copyThomasButton;
        private System.Windows.Forms.Button copyWilliamEmail;
        private System.Windows.Forms.Label label3;
    }
}