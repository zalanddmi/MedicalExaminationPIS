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
        }

        private void SetParametersAndValues()
        {
            SetParameters(false);
            var contracts = controller.GetContracts();
            if (contracts == null)
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
            textBoxMunicipalContract.ReadOnly = value;
            textBoxMunicipalContract.Visible = value;
            radioButtonYes.Visible = !value;
            radioButtonNo.Visible = !value;

            // скрыл, так как не понял для чего они, если все равно не нужны
            textBoxNameSpecialist.Visible = value;
            textBoxPostSpecialist.Visible = value;
            labelNameSpecialist.Visible = value;
            labelPostSpecialist.Visible = value;
        }

        private void ОК_Click(object sender, EventArgs e)
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
        }
        
        private void Отмена_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
