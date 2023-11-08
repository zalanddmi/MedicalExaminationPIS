using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MedicalExamination.Views;
using MedicalExamination.Models;
using MedicalExamination.Data;
using MedicalExamination.Services;

namespace MedicalExamination
{
    public partial class MenuView : Form
    {
        public MenuView()
        {
            InitializeComponent();
            var privilege = UserSession.Privileges;
            SetVisible(privilege);
        }

        private void SetVisible(Dictionary<string, string> privilege)
        {
            if (privilege.ContainsKey("Organization"))
            {
                button1.Visible = true;
            }
            if (privilege.ContainsKey("Animal"))
            {
                button2.Visible = true;
            }
            if (privilege.ContainsKey("MunicipalContract"))
            {
                button4.Visible = true;
            }
            if (privilege.ContainsKey("Statistics"))
            {
                button3.Visible = true;
            }
            ExitButton.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            OrganizationsView organizationsView = new OrganizationsView();
            organizationsView.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            AnimalsView animalsView = new AnimalsView();
            animalsView.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            StatisticsView statisticsView = new StatisticsView();
            statisticsView.ShowDialog();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            MunicipalContractsView municipalcontractsView = new MunicipalContractsView();
            municipalcontractsView.ShowDialog();
            Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
