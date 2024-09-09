using CommonModule.Services;
using CommonModule.Model;

namespace Client2
{
    public partial class Form1 : Form, CommonModules.Services.Observer
    {
        private IService service;
        private User currentUser;

        public Form1(IService service)
        {
            this.service = service; 
            InitializeComponent();
        }

        private bool IsValidLogin()
        {
            string username = usernameBox?.Text.Trim() ?? "";
            string password = passwordBox?.Text.Trim() ?? "";

            try
            {
                User user = service.loginUser(username, password, this);
                currentUser = user;

                if (user != null)
                {
                    Console.WriteLine("Login successful for user: " + username);
                    return true;
                }
                else
                {
                    Console.WriteLine("No user found with provided credentials.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Login failed: " + ex.Message);
                return false;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string sample = sampleBox.Text.Trim();
            string ageCategory = ageCategoryBox.Text.Trim();

            menView.DataSource = service.findManFromSpecificCompetitionFS(sample, ageCategory);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (IsValidLogin())
            {
                competitionsView.Visible = true;
                sampleLabel.Visible = true;
                ageCategoryLabel.Visible = true;
                sampleBox.Visible = true;
                ageCategoryBox.Visible = true;
                searchButton.Visible = true;
                menView.Visible = true;
                registrationButton.Visible = true;
                logoutButton.Visible = true;
                getAllButton.Visible = true;


                usernameLabel.Visible = false;
                usernameBox.Visible = false;
                passwordLabel.Visible = false;
                passwordBox.Visible = false;
                loginButton.Visible = false;
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            service.logoutUser(currentUser, this);

            competitionsView.Visible = false;
            sampleLabel.Visible = false;
            ageCategoryLabel.Visible = false;
            sampleBox.Visible = false;
            ageCategoryBox.Visible = false;
            searchButton.Visible = false;
            menView.Visible = false;
            registrationButton.Visible = false;
            logoutButton.Visible = false;
            getAllButton.Visible = false;


            usernameLabel.Visible = true;
            usernameBox.Visible = true;
            passwordLabel.Visible = true;
            passwordBox.Visible = true;
            loginButton.Visible = true;
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(service);
            form2.ShowDialog();
        }

        private void competitionView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            competitionsView.Columns[0].Width = 190;
            competitionsView.Columns[1].Width = 190;
            competitionsView.Columns[2].Width = 190;
            competitionsView.Columns[3].Width = 190;
        }

        private void menView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            menView.Columns[0].Width = 190;
            menView.Columns[1].Width = 190;
            menView.Columns[2].Width = 190;
            menView.Columns[3].Width = 190;
        }

        public void UpdateCompetitions()
        {
            competitionsView.DataSource = service.GetAllCompetitionsFS(); 
            competitionsView.Refresh(); 
        }

        private void getAllButton_Click(object sender, EventArgs e)
        {
            competitionsView.DataSource = service.GetAllCompetitionsFS();
        }
    }
}