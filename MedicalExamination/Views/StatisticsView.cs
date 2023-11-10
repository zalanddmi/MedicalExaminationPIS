using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalExamination.Controllers;
using MedicalExamination.Models;

namespace MedicalExamination.Views
{
    public partial class StatisticsView : Form
    {
        private StatisticsController statisticsController;

        public StatisticsView()
        {
            InitializeComponent();
            statisticsController = new StatisticsController();
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

                var statistics = statisticsController.GetStatistics(from, to);
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
