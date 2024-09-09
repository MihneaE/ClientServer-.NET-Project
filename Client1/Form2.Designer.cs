namespace Client1
{
    partial class Form2
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
            this.idLabel = new System.Windows.Forms.Label();
            this.sampleIdLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.TextBox();
            this.sampleIdBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.ageBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(0, 6);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(32, 25);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "Id:";
            // 
            // sampleIdLabel
            // 
            this.sampleIdLabel.AutoSize = true;
            this.sampleIdLabel.Location = new System.Drawing.Point(0, 48);
            this.sampleIdLabel.Name = "sampleIdLabel";
            this.sampleIdLabel.Size = new System.Drawing.Size(96, 25);
            this.sampleIdLabel.TabIndex = 1;
            this.sampleIdLabel.Text = "Sample Id:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(0, 98);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(63, 25);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name:";
            this.nameLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(0, 145);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(48, 25);
            this.ageLabel.TabIndex = 3;
            this.ageLabel.Text = "Age:";
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(102, 6);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(187, 31);
            this.idBox.TabIndex = 4;
            // 
            // sampleIdBox
            // 
            this.sampleIdBox.Location = new System.Drawing.Point(102, 48);
            this.sampleIdBox.Name = "sampleIdBox";
            this.sampleIdBox.Size = new System.Drawing.Size(187, 31);
            this.sampleIdBox.TabIndex = 5;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(102, 98);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(187, 31);
            this.nameBox.TabIndex = 6;
            // 
            // ageBox
            // 
            this.ageBox.Location = new System.Drawing.Point(102, 142);
            this.ageBox.Name = "ageBox";
            this.ageBox.Size = new System.Drawing.Size(187, 31);
            this.ageBox.TabIndex = 7;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(12, 196);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(112, 34);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(164, 196);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(112, 34);
            this.registerButton.TabIndex = 9;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 242);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.ageBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.sampleIdBox);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.sampleIdLabel);
            this.Controls.Add(this.idLabel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label idLabel;
        private Label sampleIdLabel;
        private Label nameLabel;
        private Label ageLabel;
        private TextBox idBox;
        private TextBox sampleIdBox;
        private TextBox nameBox;
        private TextBox ageBox;
        private Button closeButton;
        private Button registerButton;
    }
}