using MedicalExamination.Controllers;
using MedicalExamination.Enums;
using MedicalExamination.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalExamination.Views
{
    public partial class ReportsView : Form
    {
        private List<string[]> reports;
        private int currentPage;
        private int pageSize;
        private Dictionary<string, string> filterDic;
        private string filter;
        private string sorting;
        private static string[] privilege;
        private string[] columnNames;
        private ReportsController controller;
        public ReportsView()
        {
            InitializeComponent();
            controller = new ReportsController();
            privilege = UserSession.Privileges["Reports"].Split(';');

            if (privilege[1] == "None")
            {
                buttonShowCardToAdd.Enabled = false;
                buttonShowCardToAdd.Visible = false;
            }

            labelNameFilter.Visible = false;
            currentPage = 1;
            sorting = "Id=Ascending;";
            AddFilterDic();
            buttonUseFilter.Enabled = false;
            filter = "";
            SetFilter();
            comboBoxCountItems.DataSource = new List<int> { 10, 20, 30 };
            pageSize = int.Parse(comboBoxCountItems.SelectedItem.ToString());

            columnNames = dataGridView1.Columns.Cast<DataGridViewColumn>()
                         .Where(x => x.Visible)
                         .Select(x => x.HeaderText)
                         .ToArray();
            ShowRegistry();
        }

        private void ShowRegistry()
        {
            dataGridView1.Rows.Clear();
            reports = controller.ShowReports(filter, sorting, currentPage, pageSize);

            foreach (var report in reports)
            {
                dataGridView1.Rows.Add(report);
            }
            UpdateNavigationButtons();

        }

        private void UpdateNavigationButtons()
        {
            buttonFirst.Enabled = currentPage > 1;
            buttonPrevious.Enabled = currentPage > 1;
            buttonNext.Enabled = !IsLastPage();
            buttonLast.Enabled = !IsLastPage();
            textBoxPage.Text = currentPage.ToString();
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
                { "StartDate", " " },
                { "EndDate", " " },
                { "Creator", " " },
                { "Status", " " },
                { "StatusDate", " " },
            };
        }



        private void buttonFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            ShowRegistry();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ShowRegistry();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (!IsLastPage())
            {
                currentPage++;
                ShowRegistry();
            }
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            currentPage = CalculateLastPage();
            ShowRegistry();
        }

        private int CalculateLastPage()
        {
            int totalItems = controller.ShowReports(filter, sorting, 1, int.MaxValue).Count;
            int lastPage = totalItems / pageSize;
            if (totalItems % pageSize != 0)
            {
                lastPage++;
            }
            return lastPage;
        }
        private bool IsLastPage()
        {
            int totalItems = controller.ShowReports(filter, sorting, 1, int.MaxValue).Count;
            int lastItemIndex = (currentPage - 1) * pageSize + pageSize;
            return lastItemIndex >= totalItems;
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
            if (labelNameFilter.Text != "NameReport")
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
            if (labelNameFilter.Text != "NameReport")
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
                if (e.RowIndex == -1 && e.ColumnIndex >= 0)
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
                    if (labelNameFilter.Text == "NameAnimal")
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
            sorting = "Id=Ascending;";
            currentPage = 1;
            groupBoxFilter.Visible = false;
            ShowRegistry();
        }

        private void ReportsView_MouseClick(object sender, MouseEventArgs e)
        {
            groupBoxFilter.Visible = false;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            groupBoxFilter.Visible = false;
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0
                && e.ColumnIndex >= 0 && privilege[1] != "None")
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStripUpdateOrDelete.Show(Cursor.Position);
            }

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var animalId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                Hide();
                ReportCardView reportCardView = new ReportCardView("View", animalId);
                reportCardView.ShowDialog();
                Show();
                ShowRegistry();
            }
            groupBoxFilter.Visible = false;

        }

        private void buttonShowCardToAdd_Click(object sender, EventArgs e)
        {
            groupBoxFilter.Visible = false;
            Hide();
            ReportCardView reportCardView = new ReportCardView("Add");
            reportCardView.ShowDialog();
            Show();
            ShowRegistry();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ReportCardView reportCardView = new ReportCardView("Edit", id);
            reportCardView.ShowDialog();
            Show();
            ShowRegistry();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                controller.DeleteReport(id);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowRegistry();
        }
    }
}
