using MedicalExamination.Controllers;
using MedicalExamination.Models;
using MedicalExamination.ViewModels;
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
        private ReportView card;
        private string cardState;
        public ReportCardView(string cardState)
        {
            InitializeComponent();
            statisticsController = new StatisticsController();
            reportsController = new ReportsController();
            organizations = reportsController.GetOrganizations();
            this.cardState = cardState;
            SetParametersAndValues();
            FillComboBoxes();
        }

        public ReportCardView(string cardState, int id)
        {
            InitializeComponent();
            statisticsController = new StatisticsController();
            reportsController = new ReportsController();
            organizations = reportsController.GetOrganizations();
            this.cardState = cardState;
            card = reportsController.GetReportCard(id);
            SetParametersAndValues();
            FillComboBoxes();
        }
        private void SetParametersAndValues()
        {
            switch (cardState)
            {
                case "View":       
                    comboBoxStatus.Visible = false;
                    FillFields();

                    buttonSave.Visible = false;
                    buttonCreate.Visible = false;
                    break;
                case "Add":
                    foreach (var textBox in this.Controls.OfType<TextBox>())
                    {
                        textBox.Visible = false;
                    }
                    labelCreator.Visible = false;
                    labelStatusDate.Visible = false;
                    break;
                case "Edit":
                    FillFields();
                    buttonCreate.Visible = false;
                    textBoxStatus.Visible = false;
                    break;
            }
        }
        
        private void FillFields()
        {
            textBoxFrom.Text = card.StartDate.ToShortDateString();
            textBoxTo.Text = card.EndDate.ToShortDateString();
            textBoxCreator.Text = card.Creator;
            textBoxOrganization.Text = card.Organization;
            textBoxStatus.Text = card.Status;
            textBoxStatusDate.Text = card.StatusDate.ToLongDateString();

            foreach (var row in card.File)
            {
                dataGridView1.Rows.Add(row);
            }
        }
        private void FillComboBoxes()
        {
            comboBoxOrganization.DataSource = new BindingSource(organizations, null);
            comboBoxOrganization.DisplayMember = "Name";
            comboBoxOrganization.ValueMember = "IdOrganization";

            comboBoxStatus.Items.AddRange(reportsController.GetStatusForUser().ToArray());
            comboBoxStatus.SelectedIndex = 0;
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
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = "Итог";
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = statLoc.Item1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (cardState)
            {
                case "View":
                    Close();
                    break;
                case "Add":
                    var from = dateTimePickerFrom.Value.ToShortDateString();
                    var to = dateTimePickerTo.Value.ToShortDateString();
                    var id = Convert.ToInt32(comboBoxOrganization.SelectedValue);
                    reportsController.SaveReport(from, to, id, comboBoxStatus.Text);
                    Close();
                    break;
                case "Edit":
                    card.Status = comboBoxStatus.Text;
                    reportsController.UpdateReport(card);
                    Close();
                    break;
                default:
                    break;
            }
        }
    }
}
