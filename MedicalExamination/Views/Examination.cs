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

namespace MedicalExamination.Views
{
    public partial class Examination : Form
    {
        private string Function;
        private string ChoosedExamination;
        public Examination(string function)
        {
            InitializeComponent();
            Function = function;
            SetParametersAndValues();
        }
        public Examination(string function, string choosedExamination)
        {
            InitializeComponent();
            Function = function;
            ChoosedExamination = choosedExamination;
            SetParametersAndValues();
        }

        private void Отмена_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SetParameters(bool value)
        {
            textBoxConditionAnimal.ReadOnly = value;
            textBoxDamage.ReadOnly = value;
            textBoxDiagnosis.ReadOnly = value;
            textBoxManipulations.ReadOnly = value;
            textBoxNameSpecialist.ReadOnly = value;
            textBoxPostSpecialist.ReadOnly = value;
            textBoxSkin.ReadOnly = value;
            textBoxTemperature.ReadOnly = value;
            textBoxWool.ReadOnly = value;
            textBoxTreatment.ReadOnly = value;
            textBoxPeculiaritiesBehavior.ReadOnly = value;
            comboBoxOrganization.Visible = !value;
            comboBoxMunicipalContract.Visible = !value;
            textBoxOrganization.ReadOnly = value;
            textBoxOrganization.Visible = value;
            textBoxMunicipalContract.ReadOnly = value;
            textBoxMunicipalContract.Visible = value;
            radioButtonYes.Visible = !value;
            radioButtonNo.Visible = !value;
            textBoxForm.ReadOnly = value;
            textBoxForm.Visible = value;
        }

        private void ОК_Click(object sender, EventArgs e)
        {
            switch (Function)
            {
                case "View":
                    Close();
                    break;
                case "Add":
                    var examinationData = new List<string>
                    {
                    textBoxConditionAnimal.Text,
                    textBoxDamage.Text,
                    textBoxDiagnosis.Text,
                    textBoxManipulations.Text,
                    textBoxNameSpecialist.Text,
                    textBoxPostSpecialist.Text,
                    textBoxSkin.Text,
                    textBoxTemperature.Text,
                    textBoxWool.Text,
                    textBoxTreatment.Text,
                    textBoxPeculiaritiesBehavior.Text,
                    radioButtonNo.Checked ? "Да" : "Нет",
                    comboBoxOrganization.SelectedValue.ToString(),
                    comboBoxMunicipalContract.SelectedValue.ToString()
                    };
                    new ExaminationController().AddExamination(examinationData.ToArray());
                    Close();
                    break;
            }
        }
        private void SetParametersAndValues()
        {
            switch (Function)
            {
                case "View":
                    SetParameters(true);
                    var examinationCardToView = new ExaminationController().ShowExaminationCardToView(ChoosedExamination);
                    textBoxPeculiaritiesBehavior.Text = examinationCardToView[0];
                    textBoxConditionAnimal.Text = examinationCardToView[1];
                    textBoxTemperature.Text = examinationCardToView[2];
                    textBoxSkin.Text = examinationCardToView[3];
                    textBoxWool.Text = examinationCardToView[4];
                    textBoxDamage.Text = examinationCardToView[5];
                    textBoxForm.Text= examinationCardToView[6];
                    textBoxDiagnosis.Text = examinationCardToView[7];
                    textBoxManipulations.Text = examinationCardToView[8];
                    textBoxTreatment.Text = examinationCardToView[9];
                    dateTimePickerDateExamination.Text= examinationCardToView[10];
                    textBoxNameSpecialist.Text = examinationCardToView[13];
                    textBoxPostSpecialist.Text = examinationCardToView[14];
                    textBoxOrganization.Text = examinationCardToView[11];
                    textBoxMunicipalContract.Text = examinationCardToView[15];



                    break;
                case "Add":
                    SetParameters(false);
                    comboBoxOrganization.DataSource = new BindingSource(
                        TestData.Organizations, null);
                    comboBoxOrganization.DisplayMember = "Name";
                    comboBoxOrganization.ValueMember = "IdOrganization";
                    comboBoxMunicipalContract.DataSource = new BindingSource(
                        TestData.Organizations, null);
                    comboBoxMunicipalContract.DisplayMember = "Name";
                    comboBoxMunicipalContract.ValueMember = "IdMunicipalContract";
                    break;
            }
        }

        private void Examination_Load(object sender, EventArgs e)
        {

        }
    }
}
