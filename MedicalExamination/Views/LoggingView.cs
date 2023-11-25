using MedicalExamination.Controllers;
using MedicalExamination.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalExamination.Views
{
    public partial class LoggingView : Form
    {
        private LoggingController controller;
        private List<string[]> logs;
        private int currentPage;
        private int pageSize;
        private Dictionary<string, string> filterDic;
        private string filter;
        private string sorting;
        private List<string> logIds;

        public LoggingView()
        {
            InitializeComponent();
            controller = new LoggingController();
            labelNameFilter.Visible = false;
            currentPage = 1;
            sorting = "IdLog=Ascending;";
            AddFilterDic();
            buttonUseFilter.Enabled = false;
            filter = "";
            SetFilter();
            comboBoxCountItems.DataSource = new List<int> { 10, 25, 50 };
            pageSize = int.Parse(comboBoxCountItems.SelectedItem.ToString());
            logIds = new List<string>();
            dataGridViewLogging.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewLogging.Size = new System.Drawing.Size(Size.Width - 40, Size.Height - 136);
            comboBoxCountItems.Location = new System.Drawing.Point(192, Size.Height - 75);
            buttonFirst.Location = new System.Drawing.Point(12, Size.Height - 81);
            buttonPrevious.Location = new System.Drawing.Point(48, Size.Height - 81);
            buttonLast.Location = new System.Drawing.Point(156, Size.Height - 81);
            buttonNext.Location = new System.Drawing.Point(120, Size.Height - 81);
            textBoxPage.Location = new System.Drawing.Point(84, Size.Height - 75);
            buttonClearAll.Location = new System.Drawing.Point(Size.Width - 128, 11);
        }

        private void ShowRegistry()
        {
            dataGridViewLogging.Rows.Clear();

            try
            {
                logs = controller.ShowLogs(filter, sorting, currentPage, pageSize);
                foreach (var log in logs)
                {
                    dataGridViewLogging.Rows.Add(log);
                }
                UpdateNavigationButtons();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }   
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
                { "Operation", " " },
                { "FullName", " " },
                { "Number", " " },
                { "Email", " " },
                { "Organization", " " },
                { "StructuralDivision", " " },
                { "Post", " " },
                { "WorkNumber", " " },
                { "WorkEmail", " " },
                { "Login", " " },
                { "Date", " " },
                { "NameObject", " " },
                { "IdObject", " " },
                { "DescriptionObject", " " },
                { "FileNames", " " }
            };
        }

        private int CalculateLastPage()
        {
            int totalItems = controller.ShowLogs(filter, sorting, 1, int.MaxValue).Count;
            int lastPage = totalItems / pageSize;
            if (totalItems % pageSize != 0)
            {
                lastPage++;
            }
            return lastPage;
        }

        private bool IsLastPage()
        {
            int totalItems = controller.ShowLogs(filter, sorting, 1, int.MaxValue).Count;
            int lastItemIndex = (currentPage - 1) * pageSize + pageSize;
            return lastItemIndex >= totalItems;
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            groupBoxFilter.Visible = false;
            try
            {
                var bytes = controller.ExportLogsToExcel(filter, sorting);
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel файлы (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Сохранить файл Excel";
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    File.WriteAllBytes(saveFileDialog.FileName, bytes.Result);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            if (dataGridViewLogging.SelectedRows.Count != dataGridViewLogging.Rows.Count)
            {
                foreach (DataGridViewRow row in dataGridViewLogging.Rows)
                {
                    row.Selected = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridViewLogging.Rows)
                {
                    row.Selected = false;
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewLogging.SelectedRows.Count != 0)
                {
                    foreach (DataGridViewRow row in dataGridViewLogging.SelectedRows)
                    {
                        logIds.Add(row.Cells["IdLog"].Value.ToString());
                    }
                    controller.DeleteLogs(string.Join(",", logIds));
                }
                else
                {
                    MessageBox.Show("Выделите записи перед удалением!");
                }
                ShowRegistry();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
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

        private void buttonUseFilter_Click(object sender, EventArgs e)
        {
            filterDic[labelNameFilter.Text] = textBoxFilter.Text;
            textBoxFilter.Text = "";
            currentPage = 1;
            SetFilter();
            ShowRegistry();
            groupBoxFilter.Visible = false;
        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            filterDic[labelNameFilter.Text] = " ";
            textBoxFilter.Text = "";
            currentPage = 1;
            SetFilter();
            ShowRegistry();
            groupBoxFilter.Visible = false;
        }

        private void comboBoxCountItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBoxFilter.Visible = false;
            pageSize = int.Parse(comboBoxCountItems.SelectedItem.ToString());
            currentPage = 1;
            ShowRegistry();
        }

        private void dataGridViewLogging_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            groupBoxFilter.Visible = false;
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex == -1 && e.ColumnIndex >= 0)
                {
                    Rectangle headerRect = dataGridViewLogging.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    int groupBoxY = headerRect.Y + groupBoxFilter.Height / 2; ;
                    int groupBoxX;
                    if (e.ColumnIndex == dataGridViewLogging.Columns.Count - 1)
                    {
                        groupBoxX = headerRect.X - headerRect.Width + 10;

                    }
                    else
                    {
                        groupBoxX = headerRect.X + headerRect.Width - 10;
                    }
                    groupBoxFilter.Location = new Point(groupBoxX, groupBoxY);
                    groupBoxFilter.Visible = true;
                    labelNameFilter.Text = dataGridViewLogging.Columns[e.ColumnIndex].Name;
                    textBoxFilter.Text = filterDic[labelNameFilter.Text] == " " ? "" : textBoxFilter.Text = filterDic[labelNameFilter.Text];
                }
            }
            else
            {
                string columnName = dataGridViewLogging.Columns[e.ColumnIndex].Name;
                SortDirection currentDirection = GetSortDirection(columnName);
                SortDirection nextDirection = GetNextSortDirection(currentDirection);
                sorting += $"{columnName}={nextDirection};";
                currentPage = 1;
                ShowRegistry();
            }
        }

        private void LoggingView_MouseClick(object sender, MouseEventArgs e)
        {
            groupBoxFilter.Visible = false;
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
            sorting = "IdLog=Ascending;";
            currentPage = 1;
            groupBoxFilter.Visible = false;
            ShowRegistry();
        }

        private void dataGridViewLogging_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
