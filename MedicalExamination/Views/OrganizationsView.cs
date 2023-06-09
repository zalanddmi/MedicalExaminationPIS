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
using MedicalExamination.Services;
using MedicalExamination.Data;

namespace MedicalExamination.Views
{
    public partial class OrganizationsView : Form
    {
        private List<string[]> organizations;
        private int currentPage;
        private int pageSize;
        private Dictionary<string, string> filterDic;
        private string filter;
        private string sorting;
        private static string[] privilege;
        private string[] columnNames;

        public OrganizationsView()
        {
            InitializeComponent();
            privilege = new PrivilegeService().SetPrivilegeForUser()["Organization"].Split(';');
            if (privilege[1] == "None")
            {
                buttonShowCardToAdd.Enabled = false;
                buttonShowCardToAdd.Visible = false;
            }
            labelNameFilter.Visible = false;
            currentPage = 1;
            sorting = "IdOrganization=Ascending;";
            AddFilterDic();
            buttonUseFilter.Enabled = false;
            filter = "";
            SetFilter();
            comboBoxCountItems.DataSource = new List<int> { 3, 4, 5 };
            pageSize = int.Parse(comboBoxCountItems.SelectedItem.ToString());
            ShowRegistry();
            columnNames = dataGridView1.Columns.Cast<DataGridViewColumn>()
                         .Where(x => x.Visible)
                         .Select(x => x.HeaderText)
                         .ToArray();
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

        private SortDirection GetSortDirection(string columnName)
        {
            if (sorting != null)
            {
                var sortPar = sorting.Split(';');
                var sortParams = sortPar[sortPar.Length - 2].Split('=');
                if (sortParams.Length == 2 && sortParams[0] == columnName)
                {
                    return sortParams[1] == "Ascending" ? SortDirection.Ascending : SortDirection.Descending;
                }
            }
            return SortDirection.Ascending;
        }

        private SortDirection GetNextSortDirection(SortDirection currentDirection)
        {
            return currentDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending;
        }

        private void SetFilter()
        {
            filter = "";
            foreach (var fil in filterDic)
            {
                filter += $"{fil.Key}={fil.Value};";
            }
        }

        private void AddFilterDic()
        {
            filterDic = new Dictionary<string, string>
            {
                { "Name", " " },
                { "TaxIdNumber", " " },
                { "CodeReason", " " },
                { "Address", " " },
                { "TypeOrganization", " " },
                { "Locality", " " }
            };
        }

        private void buttonShowCardToAdd_Click(object sender, EventArgs e)
        {
            groupBoxFilter.Visible = false;
            OrganizationCardView organizationCardView = new OrganizationCardView("Add");
            organizationCardView.ShowDialog();
            ShowRegistry();
        }

        private void buttonFistPage_Click(object sender, EventArgs e)
        {
            groupBoxFilter.Visible = false;
            currentPage = 1;
            ShowRegistry();
        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            groupBoxFilter.Visible = false;
            if (currentPage > 1)
            {
                currentPage--;
                ShowRegistry();
            }
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            groupBoxFilter.Visible = false;
            if (!IsLastPage())
            {
                currentPage++;
                ShowRegistry();
            }
        }

        private void buttonLastPage_Click(object sender, EventArgs e)
        {
            groupBoxFilter.Visible = false;
            currentPage = CalculateLastPage();
            ShowRegistry();
        }

        private void comboBoxCountItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBoxFilter.Visible = false;
            pageSize = int.Parse(comboBoxCountItems.SelectedItem.ToString());
            currentPage = 1;
            ShowRegistry();
        }

        private void buttonUseFilter_Click(object sender, EventArgs e)
        {
            if (labelNameFilter.Text != "NameOrg")
            {
                filterDic[labelNameFilter.Text] = textBoxFilter.Text;
            }
            else
            {
                filterDic["Name"] = textBoxFilter.Text;
            }
            textBoxFilter.Text = "";
            currentPage = 1;
            SetFilter();
            ShowRegistry();
            groupBoxFilter.Visible = false;
        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            if (labelNameFilter.Text != "NameOrg")
            {
                filterDic[labelNameFilter.Text] = " ";
            }
            else
            {
                filterDic["Name"] = " ";
            }
            textBoxFilter.Text = "";
            currentPage = 1;
            SetFilter();
            ShowRegistry();
            groupBoxFilter.Visible = false;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            groupBoxFilter.Visible = false;
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex == -1 && e.ColumnIndex >= 0 
                    && dataGridView1.Columns[e.ColumnIndex].Name != "IsJuridicalPerson")
                {
                    Rectangle headerRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    int groupBoxY = headerRect.Y + groupBoxFilter.Height / 2; ;
                    int groupBoxX;
                    if (e.ColumnIndex == dataGridView1.Columns.Count - 1)
                    {
                        groupBoxX = headerRect.X - headerRect.Width + 10;

                    }
                    else
                    {
                        groupBoxX = headerRect.X + headerRect.Width - 10;
                    }
                    groupBoxFilter.Location = new Point(groupBoxX, groupBoxY);
                    groupBoxFilter.Visible = true;
                    labelNameFilter.Text = dataGridView1.Columns[e.ColumnIndex].Name;
                    if (labelNameFilter.Text == "NameOrg")
                    {
                        textBoxFilter.Text = filterDic["Name"] == " " ? "" : textBoxFilter.Text = filterDic["Name"];
                    }
                    else
                    {
                        textBoxFilter.Text = filterDic[labelNameFilter.Text] == " " ? "" : textBoxFilter.Text = filterDic[labelNameFilter.Text];
                    }
                }
            }
            else
            {
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
                SortDirection currentDirection = GetSortDirection(columnName);
                SortDirection nextDirection = GetNextSortDirection(currentDirection);
                sorting += $"{columnName}={nextDirection};";
                currentPage = 1;
                ShowRegistry();
            }
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            groupBoxFilter.Visible = false;
            new OrganizationsController().ExportOrganizationsToExcel(filter, sorting, columnNames);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            groupBoxFilter.Visible = false;
            var choosedOrganization = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            OrganizationCardView organizationCardView = new OrganizationCardView("View", choosedOrganization);
            organizationCardView.ShowDialog();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            groupBoxFilter.Visible = false;
            
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 
                && e.ColumnIndex >= 0)
            {
                var typesOrg = new List<string>();
                var check = false;
                var nametp = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                var idtp = TestData.TypeOrganizations.Where(tp => tp.Name == nametp).Select(tp => tp.IdTypeOrganization).First();
                if (privilege[1] != "None")
                {
                    typesOrg = privilege[1].Split(',').ToList();
                    foreach (var item in typesOrg)
                    {
                        var tpid = int.Parse(item);
                        if (tpid == idtp)
                        {
                            check = true;
                        }
                    }
                }
                if (check)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    contextMenuStripUpdateOrDelete.Show(Cursor.Position);
                }
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var choosedOrganization = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            OrganizationCardView organizationCardView = new OrganizationCardView("Edit", choosedOrganization);
            organizationCardView.ShowDialog();
            ShowRegistry();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var choosedOrganization = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            new OrganizationsController().DeleteOrganization(choosedOrganization);
            ShowRegistry();
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFilter.Text.Length > 0)
            {
                buttonUseFilter.Enabled = true;
            }
            else
            {
                buttonUseFilter.Enabled = false;
            }
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            filterDic.Clear();
            AddFilterDic();
            SetFilter();
            sorting = "IdOrganization=Ascending;";
            currentPage = 1;
            groupBoxFilter.Visible = false;
            ShowRegistry();
        }

        private enum SortDirection
        {
            Ascending,
            Descending
        }

        private void OrganizationsView_MouseClick(object sender, MouseEventArgs e)
        {
            groupBoxFilter.Visible = false;
        }
    }
}
