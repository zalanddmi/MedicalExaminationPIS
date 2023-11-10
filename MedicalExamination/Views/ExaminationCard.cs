using MedicalExamination.Controllers;
using MedicalExamination.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalExamination.Models;
using MedicalExamination.ViewModels;

namespace MedicalExamination.Views
{
    public partial class ExaminationCard : Form
    {
        private int animalId;

        private ExaminationController controller;

        public ExaminationCard(int animalId)
        {
            InitializeComponent();
            controller = new ExaminationController();
            this.animalId = animalId;
            SetParametersAndValues();
            SetTextBoxHandlers();
        }

        private void SetParametersAndValues()
        {
            SetParameters(false);
            var contracts = controller.GetContracts();
            if (contracts == null || contracts.Count == 0)
            {
                MessageBox.Show("Контракты на осмотры отсутствуют!");
                Close();
            }
            comboBoxMunicipalContract.DataSource = new BindingSource(contracts, null);
            comboBoxMunicipalContract.DisplayMember = "Number";
            comboBoxMunicipalContract.ValueMember = "IdMunicipalContract";
        }


        private void SetParameters(bool value)
        {
            textBoxConditionAnimal.ReadOnly = value;
            textBoxDamage.ReadOnly = value;
            textBoxDiagnosis.ReadOnly = value;
            textBoxManipulations.ReadOnly = value;
            textBoxSkin.ReadOnly = value;
            textBoxTemperature.ReadOnly = value;
            textBoxWool.ReadOnly = value;
            textBoxTreatment.ReadOnly = value;
            textBoxPeculiaritiesBehavior.ReadOnly = value;
            comboBoxMunicipalContract.Visible = !value;
            radioButtonYes.Visible = !value;
            radioButtonNo.Visible = !value;

        }
        private void SetTextBoxHandlers()
        {
            foreach (var textBox in this.Controls.OfType<TextBox>())
            {
                textBox.Leave += TextBoxLeave;
                textBox.Enter += TextBoxEnter;
            }
        }
        private void ОК_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    var examinationData = new ExaminationView
                    (
                        textBoxPeculiaritiesBehavior.Text,
                        textBoxConditionAnimal.Text,
                        textBoxTemperature.Text,
                        textBoxSkin.Text,
                        textBoxWool.Text,
                        textBoxDamage.Text,
                        radioButtonNo.Checked,
                        textBoxDiagnosis.Text,
                        textBoxManipulations.Text,
                        textBoxTreatment.Text,
                        dateTimePickerDateExamination.Value,
                        animalId,
                        (MunicipalContract)comboBoxMunicipalContract.SelectedItem
                    );
                    controller.AddExamination(examinationData);
                    Close();
                    return;
                }
                MessageBox.Show("Некоторые поля некорретно заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception error)
            { 
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidData()
        {
            foreach (var textBox in this.Controls.OfType<TextBox>())
            {
                if (textBox.TextLength == 0)
                {
                    return false;
                }
            }  
            return true;
        }
        private void Отмена_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void TextBoxLeave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.TextLength == 0)
            {
                textBox.Text = "Заполните поле!";
                textBox.ForeColor = Color.Blue;
                textBox.BackColor = Color.Pink;
            }
        }
        private void TextBoxEnter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Заполните поле!")
            {
                textBox.Text = String.Empty;
                textBox.ForeColor = Color.Black;
                textBox.BackColor = Color.White;
            }
        }
    }
}
