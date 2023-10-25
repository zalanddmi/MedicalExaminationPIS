using MedicalExamination.Controllers;
using MedicalExamination.Services;
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
using System.IO;

namespace MedicalExamination.Views
{
    public partial class AnimalsView : Form
    {
        private List<string[]> animals;
        private int currentPage;
        private int pageSize;
        private Dictionary<string, string> filterDic;
        private string filter;
        private string sorting;
        private static string[] privilege;
        private string[] columnNames;
        private AnimalsController controller;
        public AnimalsView()
        {
            InitializeComponent();
            controller = new AnimalsController();
            privilege = UserSession.Privileges["Animal"].Split(';');
            if (privilege[1] == "None")
            {
                buttonShowCardToAdd.Enabled = false;
                buttonShowCardToAdd.Visible = false;
            }
            labelNameFilter.Visible = false;
            currentPage = 1;
            sorting = "IdAnimal=Ascending;";
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
            ShowRegistry();
        }
        private void ShowRegistry()
        {
            dataGridView1.Rows.Clear();
            animals = new AnimalsController().ShowAnimals(filter, sorting, currentPage, pageSize);
            foreach (var animal in animals)
            {
                dataGridView1.Rows.Add(animal[0],animal[1], animal[2], animal[3], animal[4], animal[5], animal[6], animal[7], animal[8], animal[9]);
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
                { "RegNumber", " " },
                { "Category", " " },
                { "Sex", " " },
                { "YearBirthday", " " },
                { "NumberElectronicChip", " " },
                { "Name", " " },
                { "SignsAnimal", " " },
                { "SignsOwner", " " },
                { "Locality", " " }
            };
        }

        private void buttonShowCardToAdd_Click(object sender, EventArgs e)
        {
            groupBoxFilter.Visible = false;
            AnimalsCardView animalCardView = new AnimalsCardView("Add");
            animalCardView.ShowDialog();
            ShowRegistry();
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
            int totalItems = new AnimalsController().ShowAnimals(filter, sorting, 1, int.MaxValue).Count;
            int lastPage = totalItems / pageSize;
            if (totalItems % pageSize != 0)
            {
                lastPage++;
            }
            return lastPage;
        }
        private bool IsLastPage()
        {
            int totalItems = new AnimalsController().ShowAnimals(filter, sorting, 1, int.MaxValue).Count;
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
            if (labelNameFilter.Text != "NameAnimal")
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
            if (labelNameFilter.Text != "NameAnimal")
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

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            groupBoxFilter.Visible = false;
            var bytes = controller.ExportAnimalsToExcel(filter, sorting);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel файлы (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Сохранить файл Excel";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                File.WriteAllBytes(saveFileDialog.FileName, bytes.Result);
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
            sorting = "IdAnimal=Ascending;";
            currentPage = 1;
            groupBoxFilter.Visible = false;
            ShowRegistry();
        }

        private enum SortDirection
        {
            Ascending,
            Descending
        }

        private void AnimalsView_MouseClick(object sender, MouseEventArgs e)
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
                AnimalsCardView animalCardView = new AnimalsCardView("View", animalId);
                animalCardView.ShowDialog();
            }
            groupBoxFilter.Visible = false;
            
        }

        private void изменитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var animalId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            AnimalsCardView animalCardView = new AnimalsCardView("Edit", animalId);
            animalCardView.ShowDialog();
            ShowRegistry();
        }

        private void удалитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var animalId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            new AnimalsController().DeleteAnimal(animalId);
            ShowRegistry();
        }
    }
}
