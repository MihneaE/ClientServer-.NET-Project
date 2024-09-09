namespace Client2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.competitionsView = new System.Windows.Forms.DataGridView();
            this.sampleLabel = new System.Windows.Forms.Label();
            this.ageCategoryLabel = new System.Windows.Forms.Label();
            this.sampleBox = new System.Windows.Forms.TextBox();
            this.ageCategoryBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.menView = new System.Windows.Forms.DataGridView();
            this.registrationButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.getAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.competitionsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menView)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(305, 151);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(95, 25);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(305, 207);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(91, 25);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(429, 148);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(191, 31);
            this.usernameBox.TabIndex = 2;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(429, 201);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(191, 31);
            this.passwordBox.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(492, 258);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(128, 40);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // competitionsView
            // 
            this.competitionsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.competitionsView.Location = new System.Drawing.Point(23, 12);
            this.competitionsView.Name = "competitionsView";
            this.competitionsView.RowHeadersWidth = 62;
            this.competitionsView.RowTemplate.Height = 33;
            this.competitionsView.Size = new System.Drawing.Size(920, 150);
            this.competitionsView.TabIndex = 5;
            this.competitionsView.Visible = false;
            this.competitionsView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.competitionView_CellContentClick);
            // 
            // sampleLabel
            // 
            this.sampleLabel.AutoSize = true;
            this.sampleLabel.Location = new System.Drawing.Point(23, 191);
            this.sampleLabel.Name = "sampleLabel";
            this.sampleLabel.Size = new System.Drawing.Size(75, 25);
            this.sampleLabel.TabIndex = 6;
            this.sampleLabel.Text = "Sample:";
            this.sampleLabel.Visible = false;
            // 
            // ageCategoryLabel
            // 
            this.ageCategoryLabel.AutoSize = true;
            this.ageCategoryLabel.Location = new System.Drawing.Point(23, 246);
            this.ageCategoryLabel.Name = "ageCategoryLabel";
            this.ageCategoryLabel.Size = new System.Drawing.Size(125, 25);
            this.ageCategoryLabel.TabIndex = 7;
            this.ageCategoryLabel.Text = "Age Category:";
            this.ageCategoryLabel.Visible = false;
            // 
            // sampleBox
            // 
            this.sampleBox.Location = new System.Drawing.Point(164, 188);
            this.sampleBox.Name = "sampleBox";
            this.sampleBox.Size = new System.Drawing.Size(183, 31);
            this.sampleBox.TabIndex = 8;
            this.sampleBox.Visible = false;
            // 
            // ageCategoryBox
            // 
            this.ageCategoryBox.Location = new System.Drawing.Point(164, 246);
            this.ageCategoryBox.Name = "ageCategoryBox";
            this.ageCategoryBox.Size = new System.Drawing.Size(183, 31);
            this.ageCategoryBox.TabIndex = 9;
            this.ageCategoryBox.Visible = false;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(378, 246);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(130, 34);
            this.searchButton.TabIndex = 10;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Visible = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // menView
            // 
            this.menView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.menView.Location = new System.Drawing.Point(23, 306);
            this.menView.Name = "menView";
            this.menView.RowHeadersWidth = 62;
            this.menView.RowTemplate.Height = 33;
            this.menView.Size = new System.Drawing.Size(920, 84);
            this.menView.TabIndex = 11;
            this.menView.Visible = false;
            this.menView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.menView_CellContentClick);
            // 
            // registrationButton
            // 
            this.registrationButton.Location = new System.Drawing.Point(23, 417);
            this.registrationButton.Name = "registrationButton";
            this.registrationButton.Size = new System.Drawing.Size(214, 75);
            this.registrationButton.TabIndex = 12;
            this.registrationButton.Text = "Registration";
            this.registrationButton.UseVisualStyleBackColor = true;
            this.registrationButton.Visible = false;
            this.registrationButton.Click += new System.EventHandler(this.registrationButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(268, 417);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(203, 75);
            this.logoutButton.TabIndex = 13;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Visible = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // getAllButton
            // 
            this.getAllButton.Location = new System.Drawing.Point(831, 241);
            this.getAllButton.Name = "getAllButton";
            this.getAllButton.Size = new System.Drawing.Size(112, 34);
            this.getAllButton.TabIndex = 14;
            this.getAllButton.Text = "GetAll";
            this.getAllButton.UseVisualStyleBackColor = true;
            this.getAllButton.Visible = false;
            this.getAllButton.Click += new System.EventHandler(this.getAllButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 521);
            this.Controls.Add(this.getAllButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.registrationButton);
            this.Controls.Add(this.menView);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.ageCategoryBox);
            this.Controls.Add(this.sampleBox);
            this.Controls.Add(this.ageCategoryLabel);
            this.Controls.Add(this.sampleLabel);
            this.Controls.Add(this.competitionsView);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.competitionsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label usernameLabel;
        private Label passwordLabel;
        private TextBox usernameBox;
        private TextBox passwordBox;
        private Button loginButton;
        private DataGridView competitionsView;
        private Label sampleLabel;
        private Label ageCategoryLabel;
        private TextBox sampleBox;
        private TextBox ageCategoryBox;
        private Button searchButton;
        private DataGridView menView;
        private Button registrationButton;
        private Button logoutButton;
        private Button getAllButton;
    }
}