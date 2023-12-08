using MedicalExamination.Controllers;
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
    public partial class ReportCardView : Form
    {
        private StatisticsController statisticsController;
        private ReportsController reportsController;
        private List<Organization> organizations;
        public ReportCardView(string cardState)
        {
            InitializeComponent();
            statisticsController = new StatisticsController();
            reportsController = new ReportsController();
            organizations = reportsController.GetOrganizations();
            FillComboBoxes();
        }

        public ReportCardView(string cardState, int id)
        {
            InitializeComponent();
            statisticsController = new StatisticsController();
            reportsController = new ReportsController();
            FillComboBoxes();
        }
        private void FillComboBoxes()
        {
            comboBoxOrganization.DataSource = new BindingSource(organizations, null);
            comboBoxOrganization.DisplayMember = "Name";
            comboBoxOrganization.ValueMember = "IdOrganization";
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (dateTimePickerFrom.Value.Date > dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Введите корректно дату");
            }
            else
            {
                string from = dateTimePickerFrom.Value.ToShortDateString();
                string to = dateTimePickerTo.Value.ToShortDateString();
                int id = Convert.ToInt32(comboBoxOrganization.SelectedValue);

                var statistics = reportsController.GetStatisticsForOrganization(from, to, id);
                foreach (var statLoc in statistics.StatistictsLocalities)
                {
                    foreach (var line in statLoc.Item3)
                    {
                        var values = new string[] { statLoc.Item2, line.Item1, line.Item2.ToString(), line.Item3.ToString() };
                        dataGridView1.Rows.Add(values);
                    }
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = statLoc.Item2;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = statLoc.Item1;
                }
                textBoxTotalCount.Text = statistics.TotalCost.ToString();
            }
        }
    }
}
