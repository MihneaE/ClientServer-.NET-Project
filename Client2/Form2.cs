using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CommonModule.Services;
using CommonModule.Model;

namespace Client2
{
    public partial class Form2 : Form
    {
        IService service;

        public Form2(IService service)
        {
            this.service = service;
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(idBox.Text);
            int SampleId = Convert.ToInt32(sampleIdBox.Text);
            string Name = nameBox.Text;
            int Age = Convert.ToInt32(ageBox.Text);

            service.registerMan(Id, SampleId, Name, Age);

            MessageBox.Show("Registered succesfully!");

            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
