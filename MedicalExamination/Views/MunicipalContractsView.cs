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

namespace MedicalExamination.Views
{
    public partial class MunicipalContractsView : Form
    {
        private List<string[]> municipalcontracts;
        private int currentPage;
        private int pageSize;
        private Dictionary<string, string> filterDic;
        private string filter;
        private string sorting;
        private static string[] privilege;
        private string[] columnNames;

        public MunicipalContractsView()
        {
            InitializeComponent();
            //privilege = new PrivilegeService().SetPrivilegeForUser()["Organization"].Split(';');
            //if (privilege[1] == "None")
            //{
            //    buttonShowCardToAdd.Enabled = false;
            //    buttonShowCardToAdd.Visible = false;
            //}
            labelNameFilter.Visible = false;
            currentPage = 1;
            sorting = "IdMunicipalContract=Ascending;";
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
            municipalcontracts = new MunicipalContractsController().ShowMunicipalContracts(filter, sorting, currentPage, pageSize);
            foreach (var municipalcontract in municipalcontracts)
            {
                dataGridView1.Rows.Add(municipalcontract);
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
            int totalItems = new MunicipalContractsController().ShowMunicipalContracts(filter, sorting, 1, int.MaxValue).Count;
            int lastItemIndex = (currentPage - 1) * pageSize + pageSize;
            return lastItemIndex >= totalItems;
        }

        private int CalculateLastPage()
        {
            int totalItems = new MunicipalContractsController().ShowMunicipalContracts(filter, sorting, 1, int.MaxValue).Count;
            int lastPage = totalItems / pageSize;
            if (totalItems % pageSize != 0)
            {
                lastPage++;
            }
            return lastPage;
        }

        private enum SortDirection
        {
            Ascending,
            Descending
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
                { "Number", " " },
                { "DateConclusion", " " },
                { "DateAction", " " },
                { "Executor", " " },
                { "Customer", " " }               
            };
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

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            groupBoxFilter.Visible = false;
            new MunicipalContractsController().ExportMunicipalContractsToExcel(filter, sorting, columnNames);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {                                                         
                groupBoxFilter.Visible = false;
                var choosedmunicipalcontract = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                MunicipalContractCardView municipalContractCardView = new MunicipalContractCardView();
                municipalContractCardView.ShowDialog();
            }
            
        }
    }
}