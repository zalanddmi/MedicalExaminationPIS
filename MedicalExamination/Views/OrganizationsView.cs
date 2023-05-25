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
        private int currentPage = 1;
        private int pageSize;

        public OrganizationsView()
        {
            InitializeComponent();
            comboBoxCountItems.DataSource = new List<int> { 1, 3, 5};
            pageSize = int.Parse(comboBoxCountItems.SelectedItem.ToString());
            ShowRegistry();
        }

        private void ShowRegistry()
        {
            dataGridView1.Rows.Clear();
            var organizations = new OrganizationsController().ShowOrganizations(currentPage, pageSize);
            foreach (var organization in organizations)
            {
                dataGridView1.Rows.Add(organization);
            }
            UpdateNavigationButtons();
        }

        private void UpdateNavigationButtons()
        {
            buttonFirstPage.Enabled = currentPage > 1;
            buttonPreviousPage.Enabled = currentPage > 1;
            buttonNextPage.Enabled = !IsLastPage();
            buttonLastPage.Enabled = !IsLastPage();
            textBoxPage.Text = currentPage.ToString();
        }

        private bool IsLastPage()
        {
            int totalItems = new OrganizationsController().ShowOrganizations(1, int.MaxValue).Count;
            int lastItemIndex = (currentPage - 1) * pageSize + pageSize;
            return lastItemIndex >= totalItems;
        }

        private int CalculateLastPage()
        {
            int totalItems = new OrganizationsController().ShowOrganizations(1, int.MaxValue).Count;
            int lastPage = totalItems / pageSize;
            if (totalItems % pageSize != 0)
            {
                lastPage++;
            }
            return lastPage;
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
            ShowRegistry();
        }

        private void buttonShowCardToEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var choosedOrganization = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                OrganizationCardView organizationCardView = new OrganizationCardView("Edit", choosedOrganization);
                organizationCardView.ShowDialog();
                ShowRegistry();
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

        private void buttonFistPage_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            ShowRegistry();
        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ShowRegistry();
            }
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (!IsLastPage())
            {
                currentPage++;
                ShowRegistry();
            }
        }

        private void buttonLastPage_Click(object sender, EventArgs e)
        {
            currentPage = CalculateLastPage();
            ShowRegistry();
        }

        private void comboBoxCountItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = int.Parse(comboBoxCountItems.SelectedItem.ToString());
            currentPage = 1;
            ShowRegistry();
        }
    }
}
