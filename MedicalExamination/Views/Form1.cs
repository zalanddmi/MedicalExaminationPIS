using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalExamination.Views;
using MedicalExamination.Models;
using MedicalExamination.Data;

namespace MedicalExamination
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UserSession.User = TestData.Users[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrganizationsView organizationsView = new OrganizationsView();
            organizationsView.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnimalsView animalsView = new AnimalsView();
            animalsView.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StatisticsView statisticsView = new StatisticsView();
            statisticsView.Show();
        }
    }
}
