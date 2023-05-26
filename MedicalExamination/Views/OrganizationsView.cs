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
using MedicalExamination.Models;

namespace MedicalExamination.Views
{
    public partial class OrganizationsView : Form
    {
        private List<string[]> organizations;
        private int currentPage;
        private int pageSize;
        private string filter;
        private string sorting;

        public OrganizationsView()
        {
            InitializeComponent();
            currentPage = 1;
            sorting = "IdOrganization;Ascending";
            filter = "";
            comboBoxCountItems.DataSource = new List<int> { 1, 3, 5};
            pageSize = int.Parse(comboBoxCountItems.SelectedItem.ToString());
            ShowRegistry();
        }

        private void ShowRegistry()
        {
            dataGridView1.Rows.Clear();
            organizations = new OrganizationsController().ShowOrganizations(filter, sorting, currentPage, pageSize);
            foreach (var organization in organizations)
            {
                dataGridView1.Rows.Add(organization);
            }
            UpdateNavigationButtons();
            FillCheckedBoxes();
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
            int totalItems = new OrganizationsController().ShowOrganizations(filter, sorting, 1, int.MaxValue).Count;
            int lastItemIndex = (currentPage - 1) * pageSize + pageSize;
            return lastItemIndex >= totalItems;
        }

        private int CalculateLastPage()
        {
            int totalItems = new OrganizationsController().ShowOrganizations(filter, sorting, 1, int.MaxValue).Count;
            int lastPage = totalItems / pageSize;
            if (totalItems % pageSize != 0)
            {
                lastPage++;
            }
            return lastPage;
        }

        private void FillCheckedBoxes()
        {
            checkedListBoxTypeOrganization.Items.Clear();
            checkedListBoxLocality.Items.Clear();
            checkedListBoxTypeOrganization.Items.AddRange(new OrganizationsController().ShowOrganizations(filter, sorting, 1, int.MaxValue).
                Select(org => org[5]).Distinct().ToArray());
            checkedListBoxLocality.Items.AddRange(new OrganizationsController().ShowOrganizations(filter, sorting, 1, int.MaxValue)
                .Select(org => org[7]).Distinct().ToArray());
            SetItemsChecked();
        }

        private SortDirection GetSortDirection(string columnName)
        {
            if (sorting != null)
            {
                string[] sortParams = sorting.Split(';');
                if (sortParams.Length == 2 && sortParams[0] == columnName)
                {
                    return sortParams[1] == "asc" ? SortDirection.Ascending : SortDirection.Descending;
                }
            }
            return SortDirection.Ascending;
        }

        private SortDirection GetNextSortDirection(SortDirection currentDirection)
        {
            return currentDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending;
        }

        private void SetItemsChecked()
        {
            for (int i = 0; i < checkedListBoxTypeOrganization.Items.Count; i++)
            {
                if (filter.Contains(checkedListBoxTypeOrganization.Items[i].ToString()))
                {
                    checkedListBoxTypeOrganization.SetItemChecked(i, true);
                }
                else
                {
                    checkedListBoxTypeOrganization.SetItemChecked(i, false);
                }
            }
            for (int i = 0; i < checkedListBoxLocality.Items.Count; i++)
            {
                if (filter.Contains(checkedListBoxLocality.Items[i].ToString()))
                {
                    checkedListBoxLocality.SetItemChecked(i, true);
                }
                else
                {
                    checkedListBoxLocality.SetItemChecked(i, false);
                }
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

        private void buttonUseFilter_Click(object sender, EventArgs e)
        {
            var checkedTypeOrganization = checkedListBoxTypeOrganization.CheckedItems;
            var checkedLocality = checkedListBoxLocality.CheckedItems;
            foreach (var typeOrganization in checkedTypeOrganization)
            {
                filter += typeOrganization.ToString() + ",";
            }
            foreach (var locality in checkedLocality)
            {
                filter += locality.ToString() + ",";
            }
            currentPage = 1;
            ShowRegistry();
        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxTypeOrganization.Items.Count; i++)
            {
                checkedListBoxTypeOrganization.SetItemChecked(i, false);
            }

            for (int i = 0; i < checkedListBoxLocality.Items.Count; i++)
            {
                checkedListBoxLocality.SetItemChecked(i, false);
            }
            filter = "";
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            SortDirection currentDirection = GetSortDirection(columnName);
            SortDirection nextDirection = GetNextSortDirection(currentDirection);
            sorting = $"{columnName};{nextDirection}";
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            new OrganizationsController().ExportOrganizationsToExcel(filter, sorting);
        }

        private enum SortDirection
        {
            Ascending,
            Descending
        }
    }
}
