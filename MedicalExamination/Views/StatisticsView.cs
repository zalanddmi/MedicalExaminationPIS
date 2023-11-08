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
    public partial class StatisticsView : Form
    {
        StatisticsController statisticsController;
        public StatisticsView()
        {
            InitializeComponent();
            statisticsController = new StatisticsController();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var statistics = statisticsController.GetStatistics(dateTimePickerFrom.Value.Date, dateTimePickerTo.Value.Date);
            foreach (var statLoc in statistics.StatistictsLocalities)
            {
                foreach (var line in statLoc.Lines)
                {
                    var values = new string[] {statLoc.Locality.Name, line.Diagnosis, line.Count.ToString(), line.Price.ToString()};
                    dataGridView1.Rows.Add(values);
                }
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = statLoc.Locality.Name;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = statLoc.Cost;
            }
            textBoxTotalCount.Text = statistics.TotalCost.ToString();
        }
    }
}
