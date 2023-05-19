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
    }
}
