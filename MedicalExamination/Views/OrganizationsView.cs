using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalExamination.Controllers;

namespace MedicalExamination.Views
{
    public partial class OrganizationsView : Form
    {
        public OrganizationsView()
        {
            InitializeComponent();
            ShowRegistry();
        }

        private void ShowRegistry()
        {
            dataGridView1.Rows.Clear();
            var organizations = new OrganizationsController().ShowOrganizations();
            foreach (var organization in organizations)
            {
                dataGridView1.Rows.Add(organization);
            }
        }

        private void buttonShowCardToView_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var choosedOrganization = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                OrganizationCardView organizationCardView = new OrganizationCardView("View", choosedOrganization);
                organizationCardView.ShowDialog();
            }
        }

        private void buttonShowCardToAdd_Click(object sender, EventArgs e)
        {
            OrganizationCardView organizationCardView = new OrganizationCardView("Add");
            organizationCardView.ShowDialog();
        }

        private void buttonShowCardToEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var choosedOrganization = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                OrganizationCardView organizationCardView = new OrganizationCardView("Edit", choosedOrganization);
                organizationCardView.ShowDialog();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var choosedOrganization = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                new OrganizationsController().DeleteOrganization(choosedOrganization);
                ShowRegistry();
            }
        }
    }
}
