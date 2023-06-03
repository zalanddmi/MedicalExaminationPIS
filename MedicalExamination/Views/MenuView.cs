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
using MedicalExamination.Services;

namespace MedicalExamination
{
    public partial class MenuView : Form
    {
        public MenuView()
        {
            InitializeComponent();
            var privilege = new PrivilegeService().SetPrivilegeForUser();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrganizationsView organizationsView = new OrganizationsView();
            organizationsView.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnimalsView animalsView = new AnimalsView();
            animalsView.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StatisticsView statisticsView = new StatisticsView();
            statisticsView.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
